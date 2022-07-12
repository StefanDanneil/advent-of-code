using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day6Tests
{
    private readonly Day6 _day;

    public Day6Tests()
    {
        _day = new Day6();
    }

    [TestCase("turn on 0,0 through 999,999", 1000000)]
    [TestCase("toggle 0,0 through 999,0", 1000)]
    [TestCase("turn off 499,499 through 500,500", 0)]
    [TestCase("turn on 0,0 through 999,999\nturn off 499,499 through 500,500", 999996)]
    [TestCase("turn on 499,499 through 500,500", 4)]
    [TestCase("turn on 500,500 through 499,499", 4)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        _day.Part_1(input).Should().Be(expected);
    }
    
    
    
    [TestCase("turn on 0,0 through 0,0", 1)]
    [TestCase("toggle 0,0 through 999,999", 2000000)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        _day.Part_2(input).Should().Be(expected);
    }
}
