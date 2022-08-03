using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day10Tests
{
    [TestCase("1", "11")]
    [TestCase("11", "21")]
    [TestCase("21", "1211")]
    [TestCase("1211", "111221")]
    [TestCase("111221", "312211")]
    public void look_and_say_outputs_correctly(string input, string expected)
    {
        Day10.LookAndSay(input).Should().Be(expected);
    }
    
    [TestCase(1, 2)]
    [TestCase(2, 2)]
    [TestCase(3, 4)]
    [TestCase(4, 6)]
    [TestCase(5, 6)]
    public void it_solves_part_1_according_to_examples(int iterations, int expected)
    {
        Day10.Part_1("1", iterations).Should().Be(expected);
    }
}
