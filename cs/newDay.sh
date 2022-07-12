#!/bin/bash

mkdir solutions/2015/$1
cd solutions/2015/$1

touch input.txt
touch $1.cs

cat > $1.cs << EOF
namespace solutions._2015;

public class $1
{

    public int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        throw new NotImplementedException();
    }
    
    public int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        throw new NotImplementedException();
    }

    private string GetInput()
    {
        return File.ReadAllText("./2015/$1/input.txt");
    }
}
EOF

cd ../../..

cd solutions-tests/2015

touch $1Tests.cs

cat > $1Tests.cs << EOF
using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class $1Tests
{
    private readonly $1 _day;

    public $1Tests()
    {
        _day = new $1();
    }

    [TestCase("", 0)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        _day.Part_1(input).Should().Be(expected);
    }
    
    
    
    [TestCase("", 0)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        _day.Part_2(input).Should().Be(expected);
    }
}
EOF