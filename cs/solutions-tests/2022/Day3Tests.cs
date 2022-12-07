using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day3Tests
{
    [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [TestCase("PmmdzqPrVvPwwTWBwg", 42)]
    [TestCase("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [TestCase("ttgJtRGJQctTZtZT", 20)]
    [TestCase("CrZsJsPPZsGzwwsLwLmpwMDw", 19)]
    [TestCase("""
        vJrwpWtwJgWrhcsFMMfFFhFp
        jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
        PmmdzqPrVvPwwTWBwg
        wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
        ttgJtRGJQctTZtZT
        CrZsJsPPZsGzwwsLwLmpwMDw
        """, 157)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day3.Part_1(input).Should().Be(expected);
    }

    
    [TestCase("""
        vJrwpWtwJgWrhcsFMMfFFhFp
        jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
        PmmdzqPrVvPwwTWBwg
        """, 18)]
    [TestCase("""
        wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
        ttgJtRGJQctTZtZT
        CrZsJsPPZsGzwwsLwLmpwMDw
        """, 52)]
    [TestCase("""
        vJrwpWtwJgWrhcsFMMfFFhFp
        jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
        PmmdzqPrVvPwwTWBwg
        wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
        ttgJtRGJQctTZtZT
        CrZsJsPPZsGzwwsLwLmpwMDw
        """, 70)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day3.Part_2(input).Should().Be(expected);
    }
}
