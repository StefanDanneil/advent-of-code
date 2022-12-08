using System;
using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day8Tests
{
    [TestCase("""
        30373
        25512
        65332
        33549
        35390
        """, 21)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day8.Part_1(input).Should().Be(expected);
    }

    [TestCase("""
        30373
        25512
        65332
        33549
        35390
        """, 8)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day8.Part_2(input).Should().Be(expected);
    }
}
