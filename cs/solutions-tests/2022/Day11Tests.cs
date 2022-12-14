using FluentAssertions;
using NUnit.Framework;
using solutions._2022;
using solutions._2022.Day11;

namespace solutions_tests._2022;

public class Day11Tests
{
    private const string TestInput = """
        Monkey 0:
          Starting items: 79, 98
          Operation: new = old * 19
          Test: divisible by 23
            If true: throw to monkey 2
            If false: throw to monkey 3

        Monkey 1:
          Starting items: 54, 65, 75, 74
          Operation: new = old + 6
          Test: divisible by 19
            If true: throw to monkey 2
            If false: throw to monkey 0

        Monkey 2:
          Starting items: 79, 60, 97
          Operation: new = old * old
          Test: divisible by 13
            If true: throw to monkey 1
            If false: throw to monkey 3

        Monkey 3:
          Starting items: 74
          Operation: new = old + 3
          Test: divisible by 17
            If true: throw to monkey 0
            If false: throw to monkey 1
        """;
    
    [TestCase(TestInput, 10605)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day11.Part_1(input).Should().Be(expected);
    }

    [TestCase(TestInput, 2713310158)]
    public void it_solves_part_2_according_to_examples(string input, long expected)
    {
        Day11.Part_2(input).Should().Be(expected);
    }
}
