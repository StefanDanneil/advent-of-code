using FluentAssertions;
using NUnit.Framework;
using solutions._2025;

namespace solutions_tests._2025;

public class Day01Tests
{
    [TestCase("", 0)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day01.Part_1(input).Should().Be(expected);
    }

    [TestCase("", 0)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day01.Part_2(input).Should().Be(expected);
    }
}
