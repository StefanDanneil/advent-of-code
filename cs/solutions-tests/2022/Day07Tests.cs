using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using solutions._2022;

namespace solutions_tests._2022;

public class Day07Tests
{
    private const string TestInput = """
        $ cd /
        $ ls
        dir a
        14848514 b.txt
        8504156 c.dat
        dir d
        $ cd a
        $ ls
        dir e
        29116 f
        2557 g
        62596 h.lst
        $ cd e
        $ ls
        584 i
        $ cd ..
        $ cd ..
        $ cd d
        $ ls
        4060174 j
        8033020 d.log
        5626152 d.ext
        7214296 k
        """;
    
    [TestCase(TestInput, 95437)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day07.Part_1(input).Should().Be(expected);
    }

    [Test]
    public void it_sets_the_correct_size_of_directories()
    {
        var directories = Day07.GetDirectories(TestInput.Split('\n')).ToList();
        
        directories.First(d => d.Name == "/").Size.Should().Be(48381165);
        directories.First(d => d.Name == "e").Size.Should().Be(584);
        directories.First(d => d.Name == "a").Size.Should().Be(94853);
        directories.First(d => d.Name == "d").Size.Should().Be(24933642);
    }
    
    [TestCase(TestInput, 24933642)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day07.Part_2(input).Should().Be(expected);
    }
}
