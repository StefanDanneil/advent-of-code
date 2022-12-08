using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day02Tests
{
    [TestCase("A Y", 8)]
    [TestCase("B X", 1)]
    [TestCase("C Z", 6)]
    [TestCase("""
        A Y
        B X
        C Z
        """, 15)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day02.Part_1(input).Should().Be(expected);
    }

    [TestCase("A Y", 4)]
    [TestCase("B X", 1)]
    [TestCase("C Z", 7)]
    [TestCase("""
        A Y
        B X
        C Z
        """, 12)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day02.Part_2(input).Should().Be(expected);
    }
}
