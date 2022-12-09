using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day09Tests
{
    [TestCase("""
        R 4
        U 4
        L 3
        D 1
        R 4
        D 1
        L 5
        R 2
        """, 13)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day09.Part_1(input).Should().Be(expected);
    }

    [TestCase("""
        R 4
        U 4
        L 3
        D 1
        R 4
        D 1
        L 5
        R 2
        """, 1)]
    [TestCase("""
        R 5
        U 8
        L 8
        D 3
        R 17
        D 10
        L 25
        U 20
        """, 36)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day09.Part_2(input).Should().Be(expected);
    }
}
