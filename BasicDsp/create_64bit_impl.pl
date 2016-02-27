#!/usr/bin/env perl
# Copy & replace of the 32bit implementation

use strict;
use warnings;

my @files = ("DataVector32Native.cs", "Interfaces32.cs", "DataVector32.cs");
my @temps;
foreach my $org (@files) {
    my $dest = "$org.tmp";
    $dest =~ s/32/64/g;
    open FILE32, "<", "$org" or die "Failed to open $org";
    open FILE64, ">", "$dest" or die "Failed to create $dest";
    print FILE64 "// Auto generated code, change $org and run create_64bit_impl.pl.pl\n";
    while (<FILE32>) {
        my $line = $_;
        chomp $line;
        $line =~ s/32/64/g;
        $line =~ s/float/double/g;
        print FILE64 "$line\n";
    }
    close FILE32;
    close FILE64;
    push @temps, $dest;
}

foreach my $temp (@temps) {
    my $final_name = $temp;
    $final_name =~ s/\.tmp$//;
    if (-f $final_name) {
        unlink $final_name;
    }

    rename "$temp", "$final_name";
}