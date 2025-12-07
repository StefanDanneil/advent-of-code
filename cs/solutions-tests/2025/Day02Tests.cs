using FluentAssertions;
using NUnit.Framework;
using solutions._2025;

namespace solutions_tests._2025;

public class Day02Tests
{
    [Test]
    public void it_solves_part_1_according_to_examples()
    {
        Day02.Part_1("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124").Should().Be(1227775554);
    }

    [Test]
    public void it_solves_part_2_according_to_examples()
    {
        Day02.Part_2("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124").Should().Be(4174379265);
    }
}
