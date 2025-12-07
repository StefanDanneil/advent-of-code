using FluentAssertions;
using NUnit.Framework;
using solutions._2025;

namespace solutions_tests._2025;

public class Day03Tests
{
    [Test]
    public void it_solves_part_1_according_to_examples()
    {
        Day03.Part_1("""
                     987654321111111
                     811111111111119
                     234234234234278
                     818181911112111
                     """).Should().Be(357);
    }

    [Test]
    public void it_solves_part_2_according_to_examples()
    {
        Day03.Part_2("""
                     987654321111111
                     811111111111119
                     234234234234278
                     818181911112111
                     """).Should().Be(3121910778619);
    }
}
