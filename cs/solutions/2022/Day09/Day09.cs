using System.Net;

namespace solutions._2022;

public static class Day09
{
    private class RopePart
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private string Name { get; set; }
        
        private RopePart? Head { get; init; }
        
        private RopePart? Tail { get; set; }

        public void AddKnot(string name)
        {
            if (Tail is null)
            {
                Tail = new RopePart { Head = this, Name = name  };
            }
            else
            {
                Tail.AddKnot(name);
            }
        }

        public RopePart GetTail()
        {
            return Tail is null ? this : Tail.GetTail();
        }
        
        public void Move(string direction)
        {
            switch (direction)
            {
                case "L":
                    X--;
                    break;
                case "U": 
                    Y++;
                    break;
                case "R": 
                    X++;
                    break;
                case "D": 
                    Y--;
                    break;
                default:
                    throw new Exception($"{direction} is not a valid direction");
            };  
            Tail?.FollowHead();
        }
        
        private void FollowHead()
        {
            if (IsTouchingHead())
                return;

            if (Head!.Y == Y) // should move only vertically
            {
                X = Head.X > X ? X + 1 : X - 1;
                Tail?.FollowHead();
                return;
            }
                

            if (Head.X == X) // should move only horizontally
            {
                Y = Head.Y > Y ? Y + 1 : Y - 1;
                Tail?.FollowHead();
                return;
            }

            if (Head.Y > Y) // should move diagonally upwards  
            {
                Y++;
                X = X = Head.X > X ? X + 1 : X - 1;
            }
            else
            {
                Y--;
                X = X = Head.X > X ? X + 1 : X - 1;
            }
            
            Tail?.FollowHead();
        }

        public bool IsTouchingHead()
        {
            if (Head!.X == X && Head.Y == Y)
                return true; // same space

            if (Head.X == X && Head.Y.IsBetween(Y - 1, Y + 1))
                return true; // head either directly above or directly below
            
            
            if (Head.Y == Y && Head.X.IsBetween(X - 1, X + 1))
                return true; // head either directly to the left or right

            if (Head.X == X -1 && Head.Y == Y -1)
                return true; // head directly diagonally down to the left
            
            if (Head.X == X -1 && Head.Y == Y + 1)
                return true; // head directly diagonally up to the left
            
            if (Head.X == X + 1 && Head.Y == Y + 1)
                return true; // head directly diagonally up to the right
            
            if (Head.X == X + 1 && Head.Y == Y - 1)
                return true; // head directly diagonally down to the right

            return false;
        }
    }

    private static bool IsBetween<T>(this T item, T start, T end)
    {
        return Comparer<T>.Default.Compare(item, start) >= 0
               && Comparer<T>.Default.Compare(item, end) <= 0;
    }
    
    public static int Part_1(string? input = null)
    {
        input ??= GetInput();
        var instructions = input.Split('\n').Select(i => i.Split(' '));
        var visitedTailIndexes = new List<string>(){"X0Y0"};
        var head = new RopePart();
        head.AddKnot("T");
        var tail = head.GetTail();

        foreach (var instruction in instructions)
        {
            if (instruction is not [var direction, var value]) throw new Exception("invalid instruction");
            var upper = int.Parse(value);
            
            for (var i = 0; i < upper; i++)
            {
                head.Move(direction);
                visitedTailIndexes.Add($"X{tail.X}Y{tail.Y}");
            }
        }
        
        return visitedTailIndexes.Distinct().Count();
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        input ??= GetInput();
        var instructions = input.Split('\n').Select(i => i.Split(' '));
        var visitedTailIndexes = new List<string>(){"X0Y0"};
        var head = new RopePart();
        head.AddKnot("1");
        head.AddKnot("2");
        head.AddKnot("3");
        head.AddKnot("4");
        head.AddKnot("5");
        head.AddKnot("6");
        head.AddKnot("7");
        head.AddKnot("8");
        head.AddKnot("9");
        var tail = head.GetTail();

        foreach (var instruction in instructions)
        {
            if (instruction is not [var direction, var value]) throw new Exception("invalid instruction");
            var upper = int.Parse(value);
            
            for (var i = 0; i < upper; i++)
            {
                head.Move(direction);
                visitedTailIndexes.Add($"X{tail.X}Y{tail.Y}");
            }
        }
        
        return visitedTailIndexes.Distinct().Count();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day09/input.txt");
    }
}
