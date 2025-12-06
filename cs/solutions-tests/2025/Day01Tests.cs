using FluentAssertions;
using NUnit.Framework;
using solutions._2025;

namespace solutions_tests._2025;

public class Day01Tests
{
    [TestCase("""
              L68
              L30
              R48
              L5
              R60
              L55
              L1
              L99
              R14
              L82
              """ , 3)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day01.Part_1(input).Should().Be(expected);
    }

    [TestCase("""
              L68
              L30
              R48
              L5
              R60
              L55
              L1
              L99
              R14
              L82
              """, 6)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day01.Part_2(input).Should().Be(expected);
    }
}
