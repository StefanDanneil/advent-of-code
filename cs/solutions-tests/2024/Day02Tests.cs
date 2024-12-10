using FluentAssertions;
using NUnit.Framework;
using solutions._2024;

namespace solutions_tests._2024;

public class Day02Tests
{
    [TestCase("""
              7 6 4 2 1
              1 2 7 8 9
              9 7 6 2 1
              1 3 2 4 5
              8 6 4 4 1
              1 3 6 7 9
              """, 2)]
    [TestCase("54 52 53 56 57 58", 0)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day02.Part_1(input).Should().Be(expected);
    }
    

    [TestCase("""
              7 6 4 2 1
              1 2 7 8 9
              9 7 6 2 1
              1 3 2 4 5
              8 6 4 4 1
              1 3 6 7 9
              """, 4)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day02.Part_2(input).Should().Be(expected);
    }
}
