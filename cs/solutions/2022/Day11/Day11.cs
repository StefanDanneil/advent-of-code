namespace solutions._2022.Day11;

public static class Day11
{
    static Dictionary<int, Monkey> tribe = new();
    
    private class Monkey
    {
        private int Id { get; init; }
        private Queue<long> Items { get; } = new();
        private List<string> Operation { get; init; } = new();
        public int ModulusNumberToTest { get; init; }
        
        private int MonkeyIdToPassToIfTrue { get; init; }
        private int MonkeyIdToPassToIfFalse { get; init; }

        public long ItemsInspectedCount { get; private set; } = 0;

        private long Inspect(long item, int lcm = 0)
        {
            var firstNumber = Operation[0] switch
            {
                "old" => item,
                _ => int.Parse(Operation[0])
            };

            var secondNumber = Operation[2] switch
            {
                "old" => item,
                _ => int.Parse(Operation[2])
            };

            var elevatedWorryLevel = Operation[1] switch
            {
                "+" => firstNumber + secondNumber,
                "*" => firstNumber * secondNumber,
                _ => throw new Exception($"Could not determine what operation to use. {Operation[1]} is not supported")
            };
            ItemsInspectedCount++;
            if (lcm != 0)
                return elevatedWorryLevel % lcm;
            
            var reducedWorryLevel = Convert.ToDouble(elevatedWorryLevel) / 3;
            var flooredValue = Convert.ToInt64(Math.Floor(reducedWorryLevel));
            return flooredValue;
        }

        public void TakeTurn(IEnumerable<Monkey> monkeys, int lcm = 0)
        {
            while (Items.Count > 0)
            {
                var currentItem = Items.Dequeue();

                currentItem = Inspect(currentItem, lcm);

                var monkeyIdToPassTo = PassesTest(currentItem) ? MonkeyIdToPassToIfTrue : MonkeyIdToPassToIfFalse;

                monkeys.First(m => m.Id == monkeyIdToPassTo).Items.Enqueue(currentItem);
            }
        }

        private bool PassesTest(long item)
        {
            return item % ModulusNumberToTest == 0;
        }

        public static Monkey Parse(string monkeyString)
        {
            var rows = monkeyString.Split('\n');
            var monkey = new Monkey
            {
                Id = int.Parse(rows[0].Split(' ')[1].Replace(":", "")),                
                Operation = rows[2].Split("= ")[1].Split(' ').Select(i => i.Trim()).ToList(),
                ModulusNumberToTest = int.Parse(rows[3].Split("divisible by")[1]),
                MonkeyIdToPassToIfTrue = int.Parse(rows[4].Split("monkey")[1]),
                MonkeyIdToPassToIfFalse = int.Parse(rows[5].Split("monkey")[1])
            };
            var items = rows[1].Split(':')[1].Split(',').Select(int.Parse);
            foreach (var item in items)
            {
                monkey.Items.Enqueue(item);
            }
            
            return monkey;
        }
    }

    public static long Part_1(string? input = null)
    {
        
        input ??=  GetInput();
        var monkeys = input.Split("\n\n").Select(Monkey.Parse).ToList();

        for (var i = 1; i <= 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.TakeTurn(monkeys);
            }
        }
        
        var topTwoMonkeys = monkeys.OrderByDescending(m => m.ItemsInspectedCount).Take(2).Select(m => m.ItemsInspectedCount).ToArray();

        return topTwoMonkeys[0] * topTwoMonkeys[1];
    }

    public static long Part_2(string? input = null)
    {
        input ??= GetInput();
        var monkeys = input.Split("\n\n").Select(Monkey.Parse).ToList();
        
        for (var i = 1; i <= 10000; i++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.TakeTurn(monkeys, monkeys.Aggregate(1, (a,m) => a * m.ModulusNumberToTest));
            }
        }
        
        var topTwoMonkeys = monkeys.OrderByDescending(m => m.ItemsInspectedCount).Take(2).Select(m => m.ItemsInspectedCount).ToArray();

        return topTwoMonkeys[0] * topTwoMonkeys[1];
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day11/input.txt");
    }
}
