#!/bin/bash

determineNextDay () {
  array=($(ls ./solutions/2015))
  highestNumber=1;
  
  for i in "${array[@]}"
  do : 
    dayNumber=${i:3:3}
     if (( $dayNumber > $highestNumber )); then
        highestNumber=$dayNumber   
     fi
  done  
  echo $((highestNumber + 1))
}

DAY_NAME=Day"$(determineNextDay)"
TEST_FILE_NAME="$DAY_NAME"Tests

mkdir solutions/2015/"$DAY_NAME"
cd solutions/2015/"$DAY_NAME" || exit 1

touch input.txt
touch "$DAY_NAME".cs

cat > "$DAY_NAME".cs << EOF
namespace solutions._2015;

public static class $DAY_NAME
{
    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        throw new NotImplementedException();
    }

    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        throw new NotImplementedException();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/$DAY_NAME/input.txt");
    }
}
EOF

cd ../../..

cd solutions-tests/2015 || exit 1

touch "$DAY_NAME"Tests.cs

cat > "$DAY_NAME"Tests.cs << EOF
using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class $TEST_FILE_NAME
{
    [TestCase("", 0)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        $DAY_NAME.Part_1(input).Should().Be(expected);
    }

    [TestCase("", 0)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        $DAY_NAME.Part_2(input).Should().Be(expected);
    }
}
EOF