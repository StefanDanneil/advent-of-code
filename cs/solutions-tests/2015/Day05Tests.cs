using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day05Tests
{
    [TestCase("ugknbfddgicrmopn", 1)]
    [TestCase("aaa", 1)]
    [TestCase("jchzalrnumimnmhp", 0)]
    [TestCase("haegwjzuvuyypxyu", 0)]
    [TestCase("dvszwmarrgswjxmb", 0)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day05.Part_1(input).Should().Be(expected);
    }
    
    
    
    [TestCase("qjhvhtzxzqqjkmpb", 1)]
    [TestCase("xxyxx", 1)]
    [TestCase("uurcxstgmygtbstg", 0)]
    [TestCase("ieodomkazucvgmuy", 0)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day05.Part_2(input).Should().Be(expected);
    }
}
