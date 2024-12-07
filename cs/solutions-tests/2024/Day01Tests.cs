using FluentAssertions;
using NUnit.Framework;
using solutions._2024;

namespace solutions_tests._2024;

public class Day01Tests
{
    [TestCase(
        """
        3   4
        4   3
        2   5
        1   3
        3   9
        3   3
        """, 11)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day01.Part_1(input).Should().Be(expected);
    }

    [TestCase(
        """
        3   4
        4   3
        2   5
        1   3
        3   9
        3   3
        """, 31)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day01.Part_2(input).Should().Be(expected);
    }
}
