using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day7Tests
{

    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "d", 72, TestName = "It sets wire d correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "e", 507, TestName = "It sets wire e correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "f", 492, TestName = "It sets wire f correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "g", 114, TestName = "It sets wire g correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "h", 65412, TestName = "It sets wire h correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "i", 65079, TestName = "It sets wire i correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "x", 123, TestName = "It sets wire x correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i", "y", 456, TestName = "It sets wire y correctly")]
    [TestCase("123 -> x\n456 -> y\nx AND y -> d\nx OR y -> e\nx LSHIFT 2 -> f\ny RSHIFT 2 -> g\nNOT x -> h\nNOT y -> i\nx -> j", "j", 123, TestName = "It sets wire j correctly")]
    public void it_solves_part_1_according_to_examples(string input, string wire, int expected)
    {
        Day7.Part_1(input, wire).Should().Be(expected);
        Day7.Part_1(input, wire).Should().Be(expected);
        Day7.Part_1(input, wire).Should().Be(expected);
        Day7.Part_1(input, wire).Should().Be(expected);
        Day7.Part_1(input, wire).Should().Be(expected);
        Day7.Part_1(input, wire).Should().Be(expected);
        Day7.Part_1(input, wire).Should().Be(expected);
        Day7.Part_1(input, wire).Should().Be(expected);
    }
}
