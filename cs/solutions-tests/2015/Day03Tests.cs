using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day03Tests
{
    [TestCase(">", 2)]
    [TestCase("^>v<", 4)]
    [TestCase("^v^v^v^v^v", 2)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day03.Part_1(input).Should().Be(expected);
    }
    
    
    
    [TestCase("^v", 3)]
    [TestCase("^>v<", 3)]
    [TestCase("^v^v^v^v^v", 11)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day03.Part_2(input).Should().Be(expected);
    }
}
