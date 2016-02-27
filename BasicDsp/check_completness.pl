#!/usr/bin/env perl
# Checks if the functions in facade32.rs have all been all made available to C#.

use strict;
use warnings;

sub parse_facade {
    open FACADE32, "<", "RustDrop/facade32.rs" or die $!;
    my @methods = ();
    while (<FACADE32>) {
        my $line = $_;
        chomp $line;
        if ($line =~ /^(\/\/)?\s*pub extern fn (\w+32)/) {
           push @methods, $2; 
        }
    }
    close FACADE32;
    return @methods;
}

sub parse_native {
    my ($file) = @_;
    open CSHARP, "<", "$file" or die $!;
    my @methods = ();
    while (<CSHARP>) {
        my $line = $_;
        chomp $line;
        if ($line =~ /EntryPoint\s*=\s*\"(.+?)\"/) {
           push @methods, $1;           
        }
    }
    close CSHARP;
    return @methods;
}

my @rust = parse_facade();
my @csharp32 = parse_native("DataVector32Native.cs");
my $found = 0;
my $missing = 0;
for my $def (@rust) {
    if (grep(/^$def$/, @csharp32)) {
        $found++;
    }
    else {
        print "missing: $def\n";
        $missing++;
    }
}

print "found: $found, missing: $missing\n";