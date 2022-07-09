using FluentAssertions;
using NUnit.Framework;
using solutions._2015.day1;

namespace solutions_tests._2015;

public class day1Tests
{
    private Day1 _day1;

    public day1Tests()
    {
        _day1 = new Day1();
    }

    [TestCase("(())", 0)]
    [TestCase("()()", 0)]
    [TestCase("(((", 3)]
    [TestCase("(()(()(", 3)]
    [TestCase("))(((((", 3)]
    [TestCase("())", -1)]
    [TestCase("))(", -1)]
    [TestCase(")))", -3)]
    [TestCase(")())())", -3)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        _day1.Part_1(input).Should().Be(expected);
    }
    
    
    
    [TestCase(")", 1)]
    [TestCase("()())", 5)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        _day1.Part_2(input).Should().Be(expected);
    }
}