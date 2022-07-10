using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class day1Tests
{
    private readonly Day1 day;

    public day1Tests()
    {
        day = new Day1();
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
        day.Part_1(input).Should().Be(expected);
    }
    
    
    
    [TestCase(")", 1)]
    [TestCase("()())", 5)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        day.Part_2(input).Should().Be(expected);
    }
}