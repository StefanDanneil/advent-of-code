using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day5Tests
{
    [TestCase("""
            [D]    
        [N] [C]    
        [Z] [M] [P]
         1   2   3 

        move 1 from 2 to 1
        move 3 from 1 to 3
        move 2 from 2 to 1
        move 1 from 1 to 2
        """, "CMZ")]
    public void it_solves_part_1_according_to_examples(string input, string expected)
    {
        Day5.Part_1(input).Should().Be(expected);
    }

    [TestCase("""
            [D]    
        [N] [C]    
        [Z] [M] [P]
         1   2   3 
        """)]
    public void it_parses_the_starting_stacks_correctly(string input)
    {
        var column1 = new List<char> { 'N', 'Z' };
        var column2 = new List<char> { 'D', 'C', 'M' };
        var column3 = new List<char> { 'P' };
        
        var expected = new List<List<char>>
        {
            column1, column2, column3
        };

        Day5.ParseStacks(input).Should().BeEquivalentTo(expected);
    }

    [TestCase("""
            [D]    
        [N] [C]    
        [Z] [M] [P]
         1   2   3 

        move 1 from 2 to 1
        move 3 from 1 to 3
        move 2 from 2 to 1
        move 1 from 1 to 2
        """, "MCD")]
    public void it_solves_part_2_according_to_examples(string input, string expected)
    {
        Day5.Part_2(input).Should().Be(expected);
    }
}
