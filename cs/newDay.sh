#!/bin/bash

determineNextDay () {
  array=($(ls ./solutions/"$YEAR"))
  highestNumber=1;
  
  for i in "${array[@]}"
  do : 
    dayNumber=${i:3:3}
     if (( $dayNumber > $highestNumber )); then
        highestNumber=$dayNumber   
     fi
  done  
  [[ $highestNumber = 1 ]] && output=1 || output=$((highestNumber + 1))
  echo $output
}

if test -z "$1"
then
  echo "No year was provided. Example usage: $(tput setaf 3) sh newDay 2022"
  exit 1
fi

YEAR="$1"
DAY_NAME=Day"$(determineNextDay)"
TEST_FILE_NAME="$DAY_NAME"Tests

mkdir solutions/"$YEAR"/"$DAY_NAME"
cd solutions/"$YEAR"/"$DAY_NAME" || exit 1

touch input.txt
touch "$DAY_NAME".cs

cat > "$DAY_NAME".cs << EOF
namespace solutions._$YEAR;

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
        return File.ReadAllText("./$YEAR/$DAY_NAME/input.txt");
    }
}
EOF

cd ../../..

cd solutions-tests/"$YEAR" || exit 1

touch "$DAY_NAME"Tests.cs

cat > "$DAY_NAME"Tests.cs << EOF
using FluentAssertions;
using NUnit.Framework;
using solutions._$YEAR;

namespace solutions_tests._$YEAR;

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