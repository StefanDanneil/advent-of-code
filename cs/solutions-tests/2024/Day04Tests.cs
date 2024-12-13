using FluentAssertions;
using NUnit.Framework;
using solutions._2024;

namespace solutions_tests._2024;

public class Day04Tests
{
    [TestCase(
        """
        MMMSXXMASM
        MSAMXMSMSA
        AMXSXMAAMM
        MSAMASMSMX
        XMASAMXAMM
        XXAMMXXAMA
        SMSMSASXSS
        SAXAMASAAA
        MAMMMXMMMM
        MXMXAXMASX
        """, 18)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day04.Part_1(input).Should().Be(expected);
    }

    [TestCase("", 0)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day04.Part_2(input).Should().Be(expected);
    }
}
