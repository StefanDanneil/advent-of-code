using FluentAssertions;
using NUnit.Framework;
using solutions._2025;

namespace solutions_tests._2025;

public class Day04Tests
{
    [TestCase("""
              ..@@.@@@@.
              @@@.@.@.@@
              @@@@@.@.@@
              @.@@@@..@.
              @@.@@@@.@@
              .@@@@@@@.@
              .@.@.@.@@@
              @.@@@.@@@@
              .@@@@@@@@.
              @.@.@@@.@.
              """, 13)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day04.Part_1(input).Should().Be(expected);
    }

    [TestCase("""
              ..@@.@@@@.
              @@@.@.@.@@
              @@@@@.@.@@
              @.@@@@..@.
              @@.@@@@.@@
              .@@@@@@@.@
              .@.@.@.@@@
              @.@@@.@@@@
              .@@@@@@@@.
              @.@.@@@.@.
              """, 43)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day04.Part_2(input).Should().Be(expected);
    }
}
