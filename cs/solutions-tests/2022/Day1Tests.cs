using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day1Tests
{
    private const string TestInput = """
        1000
        2000
        3000

        4000

        5000
        6000

        7000
        8000
        9000

        10000
        """;
    
    [TestCase("""
        1000
        2000
        3000
        """, 6000)]
    [TestCase("4000", 4000)]
    [TestCase("""
        5000
        6000
        """, 11000)]
    [TestCase("""
    7000
    8000
    9000
    """, 24000)]
    [TestCase(TestInput, 24000)]
    [TestCase("10000", 10000)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day1.Part_1(input).Should().Be(expected);
    }

    [TestCase(TestInput, 45000)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day1.Part_2(input).Should().Be(expected);
    }
}
