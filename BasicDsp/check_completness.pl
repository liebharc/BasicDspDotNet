#!/usr/bin/env perl
# Checks if the functions in facade32.rs have all been all made available to C#.

use strict;
use warnings;

sub parse_facade {
    my ($name) = @_;
    open FACADE32, "<", "RustDrop/$name" or die $!;
    my @methods = ();
    while (<FACADE32>) {
        my $line = $_;
        chomp $line;
        if ($line =~ /^(\/\/)?\s*pub extern ("C" )?fn (\w+32)/) {
            if ($2 ne "complex_data32") {
                push @methods, $3; 
            }
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

my @rust = parse_facade("facade32.rs");
push @rust, parse_facade("combined_ops32.rs");
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

for my $def (@csharp32) {
    if (not grep(/^$def$/, @rust)) {
        print "Call into undefined method: $def\n";
        $missing++;
    }
}

print "found: $found, missing: $missing\n";