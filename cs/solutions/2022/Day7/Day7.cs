namespace solutions._2022;

public static class Day7
{
    public class Directory
    {
        public Directory(string name, Directory? parent = null)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; init; }
        public int Size { get; private set; }
        public Directory? Parent { get; init; }
        public readonly Dictionary<string, Directory> Children = new();
        public readonly Dictionary<string, int> Files = new();

        private void SetSize()
        {
            var size = 0;
            
            foreach (var (_, child) in Children)
            {
                size += child.Size;
            }
            
            foreach (var (_, value) in Files)
            {
                size += value;
            }

            Size = size;
        }

        public void SetSizeRecursively()
        {
            if (Children.Count != 0)
            {
                foreach (var (_, value) in Children)
                {
                    value.SetSizeRecursively();
                }
            }
                
            SetSize();
        }
    }
    
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var directories = GetDirectories(input.Split('\n'));

        return directories.Where(d => d.Size <= 100000).Select(d => d.Size).Sum();
    }

    public static IEnumerable<Directory> GetDirectories(IEnumerable<string> lines)
    {
        var directories = new List<Directory>();
        // start out with root as current directory
        var currentDirectory = new Directory("/");

        directories.Add(currentDirectory);
        
        foreach (var line in lines.Skip(1)) // skip first line as we already inserted the root
        {
            var input = line.Split(' ');
            
            switch (input[0])
            {
                case "$":
                    if (input[1] == "cd")
                    {
                        if (input[2] == "..")
                        {
                            if (currentDirectory.Parent is not null)
                                currentDirectory = currentDirectory.Parent;
                        }
                        else
                        {
                            if (!currentDirectory.Children.TryGetValue(input[2], out var directoryToCdInto))
                                throw new DirectoryNotFoundException($"Could not find directory {input[2]}");
                            currentDirectory = directoryToCdInto;
                        }
                    }
                    break;
                case "dir":
                    var newDirectory = new Directory(input[1], currentDirectory);
                    directories.Add(newDirectory);
                    currentDirectory.Children.TryAdd(input[1], newDirectory);
                    break;
                default:
                    currentDirectory.Files.TryAdd(input[1], int.Parse(input[0]));
                    break;
            }
        }
        
        directories.First().SetSizeRecursively(); // find size of directories after tree is done
        return directories;
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var directories = GetDirectories(input.Split('\n')).ToList();
        var remainingDiskSpace = 70000000 - directories.First().Size; // minus root folder size

        return directories.Where(d => d.Size >= 30000000 - remainingDiskSpace)
            .OrderBy(d => d.Size)
            .First().Size;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day7/input.txt");
    }
}
