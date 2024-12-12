using FluentAssertions;
using NUnit.Framework;
using solutions._2024;

namespace solutions_tests._2024;

public class Day03Tests
{
    [TestCase("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day03.Part_1(input).Should().Be(expected);
    }

    [TestCase("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day03.Part_2(input).Should().Be(expected);
    }
}
