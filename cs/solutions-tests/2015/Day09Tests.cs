using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day09Tests
{
    [TestCase("London to Dublin = 464\nLondon to Belfast = 518\nDublin to Belfast = 141", 605)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day09.Part_1(input).Should().Be(expected);
    }

    [TestCase("London to Dublin = 464\nLondon to Belfast = 518\nDublin to Belfast = 141", 982)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day09.Part_2(input).Should().Be(expected);
    }
}
