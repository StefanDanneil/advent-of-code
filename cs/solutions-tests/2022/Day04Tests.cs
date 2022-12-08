using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day04Tests
{
    [TestCase("11-12, 1-11", 0)]
    [TestCase("1-2, 12-13", 0)]
    [TestCase("2-4,6-8", 0)]
    [TestCase("2-3,4-5", 0)]
    [TestCase("5-7,7-9", 0)]
    [TestCase("2-8,3-7", 1)]
    [TestCase("6-6,4-6", 1)]
    [TestCase("2-6,4-8", 0)]
    [TestCase("""
        2-4,6-8
        2-3,4-5
        5-7,7-9
        2-8,3-7
        6-6,4-6
        2-6,4-8
        """, 2)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day04.Part_1(input).Should().Be(expected);
    }

    [TestCase("""
        2-4,6-8
        2-3,4-5
        5-7,7-9
        2-8,3-7
        6-6,4-6
        2-6,4-8
        """, 4)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day04.Part_2(input).Should().Be(expected);
    }
}
