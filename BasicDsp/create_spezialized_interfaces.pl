#!/usr/bin/env perl
# Creates the specialized vector interfaces by copy & paste from the more the generic ones.

use strict;
use warnings;

if (not -e "AutoGenerated") {
    mkdir "AutoGenerated";
}

sub parse_generic_interface {
    open GENERIC32, "<", "GenericInterfaces32.cs" or die $!;
    my %result;
    my $interface;
    my $methods = [];
    my $in_interface = 0;
    while (<GENERIC32>) {
        my $line = $_;
        chomp $line;
        if ($line =~ /public interface (.+)/) {
            $interface = $1;
        } elsif ($line =~ /\{/) {
            $in_interface = 1;
        } elsif ($line =~ /\}/ and scalar(@$methods) > 0) {
            $in_interface = 0;
            $result{$interface} = $methods;
            $methods = [];
        } elsif ($line =~ /\}/) {
            # Do nothing
        } elsif ($in_interface) {
            push @$methods, $line;
        }
    }
    close GENERIC32;
    return %result;
}

my %generic = parse_generic_interface();
# We expect the following keys: 
# IGenericVectorOperations32
# IComplexVectorOperations32
# IFrequencyDomainVectorOperations32
# IDataVector32
# ITimeDomainVectorOperations32
# IRealVectorOperations32

open SPEC32, ">", "AutoGenerated/SpecializedInterfaces32.cs.tmp" or die $!;
print SPEC32 "// Auto generated code, change GenericInterfaces32.cs and run create_specialized_interfaces.pl.pl\n";
print SPEC32 "using System;\n";
print SPEC32 "// ReSharper disable UnusedMember.Global\n";
print SPEC32 "namespace BasicDsp\n";
print SPEC32 "{\n";

open IMPL32, ">", "AutoGenerated/DataVector32Specialized.cs.tmp" or die $!;
print IMPL32 "// Auto generated code, change GenericInterfaces32.cs and run create_specialized_interfaces.pl.pl\n";
print IMPL32 "using System;\n";
print IMPL32 "using System.Linq;\n";
print IMPL32 "// ReSharper disable UnusedMember.Global\n";
print IMPL32 "// ReSharper disable MemberCanBePrivate.Global\n";  
print IMPL32 "namespace BasicDsp\n";
print IMPL32 "{\n";
print IMPL32 "    partial class DataVector32 :\n";
print IMPL32 "        IRealTimeDomainVector32,\n";
print IMPL32 "        IRealFrequencyDomainVector32,\n";
print IMPL32 "        IComplexTimeDomainVector32,\n";
print IMPL32 "        IComplexFrequencyDomainVector32\n";
print IMPL32 "    {\n";

sub to_real {
    my ($name) = @_;
    if ($name eq "IComplexTimeDomainVector32") {
        return "IRealTimeDomainVector32";
    }
    
    return "IRealFrequencyDomainVector32";
}

sub to_complex {
    my ($name) = @_;
    if ($name eq "IRealTimeDomainVector32") {
        return "IComplexTimeDomainVector32";
    }
    
    return "IComplexFrequencyDomainVector32";
}

sub to_time {
    my ($name) = @_;
    if ($name eq "IRealFrequencyDomainVector32") {
        return "IRealTimeDomainVector32";
    }
    
    return "IComplexTimeDomainVector32";
}

sub to_freq {
    my ($name) = @_;
    if ($name eq "IRealTimeDomainVector32") {
        return "IRealFrequencyDomainVector32";
    }
    
    return "IComplexFrequencyDomainVector32";
}

sub process_annotations {
    my ($line, $name) = @_;
    if ($line =~ m{/\*REALCOMPLEX\*/}) {
        my $real_line = $line;
        my $complex_line = $line;
        my $real = to_real($name);
        my $complex = to_complex($name);
        $real_line =~ s/DataVector32/$real/g;
        $complex_line =~ s/DataVector32/$complex/g;
        return ($real_line, $complex_line);
    }
    elsif ($line =~ m{/\*COMPLEXTIME\*/}) {
        my $complex_time = to_time(to_complex($name));
        $line =~ s/DataVector32/$complex_time/g;
        return ($line);
    }
    elsif ($line =~ m{/\*REALTIME\*/}) {
        my $real_time = to_time(to_real($name));
        $line =~ s/DataVector32/$real_time/g;
        return ($line);
    }
    elsif ($line =~ m{/\*COMPLEXFREQ\*/}) {
        my $complex_freq = to_freq(to_complex($name));
        $line =~ s/DataVector32/$complex_freq/g;
        return ($line);
    }
    elsif ($line =~ m{/\*REAL\*/}) {
        my $real = to_real($name);
        $line =~ s/DataVector32/$real/g;
        return ($line);
    }
    elsif ($line =~ m{/\*COMPLEX\*/}) {
        my $complex = to_complex($name);
        $line =~ s/DataVector32/$complex/g;
        return ($line);
    }
    elsif ($line =~ m{/\*TIME\*/}) {
        my $time = to_time($name);
        $line =~ s/DataVector32/$time/g;
        return ($line);
    }
    elsif ($line =~ m{/\*FREQ\*/}) {
        my $freq = to_freq($name);
        $line =~ s/DataVector32/$freq/g;
        return ($line);
    }
    else {
        $line =~ s/DataVector32/$name/g;
        return ($line);
    }
}

sub generate_implementation {
    my ($interface, $interface_line, $processed) = @_;
    if (not $interface_line) {
        return;
    }
    
    my $explicit = $processed;
    $explicit =~ s/(^.*?\s+)(\S*?\(.*);$/$1$interface.$2/;
    $interface_line =~ /\s+(\S*?)\(/;
    my $method = $1;
    $interface_line =~ /\((.*)\)/;
    my $parameters = $1;
    $interface_line =~ /^\s*(\S+)/;
    my $return_type = $1;
    if (not $method) {
        print STDERR "WARNING: Skipping $interface_line\n";
        return;
    }
    
    print IMPL32 "$explicit\n";
    print IMPL32 "        {\n";
    
    if ($return_type eq "void") {
        print IMPL32 "            $method(";
    } else {
        print IMPL32 "            return $method(";
    }
    
    my @all_params = split(",", $parameters);
    my $i = 0;
    foreach my $parameter (@all_params) {
        $parameter =~ s{/.*/}{}; # Remove our own annotations
        $parameter =~ /\s*(\S+)\s+(\S+)\s*/;
        my $type = $1;
        my $name = $2;
        if ($type eq "DataVector32") {
            print IMPL32 "(DataVector32)$name";
        } elsif ($type eq "DataVector32[]") {
            print IMPL32 "$name.OfType<DataVector32>().ToArray()";
        } else {
            print IMPL32 "$name";
        }
        
        if ($i < scalar(@all_params) - 1) {
            print IMPL32 ", ";
        }
        
        $i++;
    }
    
    print IMPL32 ");\n";
    print IMPL32 "        }\n\n";
}

sub create_specific_interface {
    my ($name, $interfaces_ref, $interface_definitions_ref) = @_;
    print SPEC32 "   public interface $name : IDataVector32, IDisposable\n";
    print SPEC32 "      {\n";
    foreach my $interface (@$interfaces_ref) {
        my $methods_ref = $interface_definitions_ref->{$interface};
        my @methods = @$methods_ref;
        foreach my $line (@methods) {
            my @processed = process_annotations($line, $name);
            foreach my $result (@processed) {
                print SPEC32 "$result\n";
                generate_implementation($name, $line, $result);
            }
        }
    }
    print SPEC32 "      }\n";
}

create_specific_interface("IRealTimeDomainVector32", ["IGenericVectorOperations32", "IRealVectorOperations32", "ITimeDomainVectorOperations32"], \%generic);
create_specific_interface("IComplexTimeDomainVector32", ["IGenericVectorOperations32", "IComplexVectorOperations32", "ITimeDomainVectorOperations32"], \%generic);
create_specific_interface("IRealFrequencyDomainVector32", ["IGenericVectorOperations32", "IRealVectorOperations32", "IFrequencyDomainVectorOperations32"], \%generic);
create_specific_interface("IComplexFrequencyDomainVector32", ["IGenericVectorOperations32", "IComplexVectorOperations32", "IFrequencyDomainVectorOperations32"], \%generic);

print SPEC32 "}\n";
close SPEC32;

print IMPL32 "    }\n";
print IMPL32 "}\n";
close IMPL32;

if (-f "AutoGenerated/SpecializedInterfaces32.cs") {
    unlink "AutoGenerated/SpecializedInterfaces32.cs";
}

rename "AutoGenerated/SpecializedInterfaces32.cs.tmp", "AutoGenerated/SpecializedInterfaces32.cs";

if (-f "AutoGenerated/DataVector32Specialized.cs") {
    unlink "AutoGenerated/DataVector32Specialized.cs";
}

rename "AutoGenerated/DataVector32Specialized.cs.tmp", "AutoGenerated/DataVector32Specialized.cs";
