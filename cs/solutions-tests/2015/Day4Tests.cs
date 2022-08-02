using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day4Tests
{
    [TestCase("abcdef", 609043)]
    [TestCase("pqrstuv", 1048970)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day4.Part_1(input).Should().Be(expected);
    }
}
