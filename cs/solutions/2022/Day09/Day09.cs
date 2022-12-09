using System.Net;

namespace solutions._2022;

public static class Day09
{
    private class Head
    {
        public int X { get; private set; }
        public int Y { get; private set; }

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
        }
    }

    private class Tail
    {
        public int X { get; set; } = 0;
        public int Y { get; private set; }
        public void FollowHead(Head head)
        {
            if (IsTouchingHead(head))
                throw new Exception("I should not end up here");

            if (head.Y == Y) // should move only vertically
            {
                X = head.X > X ? X + 1 : X - 1;
                return;
            }
                

            if (head.X == X) // should move only horizontally
            {
                Y = head.Y > Y ? Y + 1 : Y - 1;
                return;
            }

            if (head.Y > Y) // should move diagonally upwards  
            {
                Y++;
                X = X = head.X > X ? X + 1 : X - 1;
            }
            else
            {
                Y--;
                X = X = head.X > X ? X + 1 : X - 1;
            }
        }

        public bool IsTouchingHead(Head head)
        {
            if (head.X == X && head.Y == Y)
                return true; // same space

            if (head.X == X && head.Y.IsBetween(Y - 1, Y + 1))
                return true; // head either directly above or directly below
            
            
            if (head.Y == Y && head.X.IsBetween(X - 1, X + 1))
                    return true; // head either directly to the left or right

            if (head.X == X -1 && head.Y == Y -1)
                return true; // head directly diagonally down to the left
            
            if (head.X == X -1 && head.Y == Y + 1)
                return true; // head directly diagonally up to the left
            
            if (head.X == X + 1 && head.Y == Y + 1)
                return true; // head directly diagonally up to the right
            
            if (head.X == X + 1 && head.Y == Y - 1)
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
        var head = new Head();
        var tail = new Tail();

        foreach (var instruction in instructions)
        {
            if (instruction is not [var direction, var value]) throw new Exception("invalid instruction");
            var upper = int.Parse(value);
            
            for (var i = 0; i < upper; i++)
            {
                head.Move(direction);
                var isTouching = tail.IsTouchingHead(head);
                if (isTouching) continue;
                tail.FollowHead(head);
                visitedTailIndexes.Add($"X{tail.X}Y{tail.Y}");
            }
        }
        
        return visitedTailIndexes.Distinct().Count();
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        throw new NotImplementedException();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day09/input.txt");
    }
}
