namespace solutions._2015;

public static class Day09
{
    public static int Part_1(string? input = null)
    {
        var locations = SetupLocationsFromInput(input);
        var distances = GetDistancesFromLocations(locations);
        return distances.Min();
    }

    public static int Part_2(string? input = null)
    {
        var locations = SetupLocationsFromInput(input);
        var distances = GetDistancesFromLocations(locations, "MAX");
        return distances.Max();
    }

    private static Dictionary<string, Location> SetupLocationsFromInput(string? input)
    {
        input = input ?? GetInput();
        var instructions = input.Split('\n');
        var locations = new Dictionary<string, Location>();

        foreach (var instruction in instructions)
        {
            var distance = int.Parse(instruction.Split('=')[1].Trim());
            var from = instruction.Split("to")[0].Trim();
            var to = instruction.Split("to")[1].Trim().Split(' ')[0].Trim();

            if (!locations.ContainsKey(from))
            {
                locations[from] = new Location(from);
            }
            
            if (!locations.ContainsKey(to))
            {
                locations[to] = new Location(to);
            }
            
            locations[from].AddConnection(locations[to], distance);
            locations[to].AddConnection(locations[from], distance);
        }

        return locations;
    }

    private static IEnumerable<int> GetDistancesFromLocations(Dictionary<string, Location> locations, string minOrMax = "MIN")
    {
        var distances = new List<int>();

        foreach (var (locationName, location) in locations)
        {
            var currentLocation = location;
            var totalDistance = 0;
            
            var visited = new List<string>()
            {
                locationName
            };

            while (visited.Count < locations.Count)
            {
                var availableConnections =
                    currentLocation.GetConnections()
                        .Where(c => !visited.Contains(c.Key.Name));

                var chosenConnection = minOrMax == "MAX" 
                    ? availableConnections.MaxBy(c => c.Value) 
                    : availableConnections.MinBy(c => c.Value);
            
                totalDistance += chosenConnection.Value;
                currentLocation = chosenConnection.Key;
                visited.Add(currentLocation.Name);
            }
            
            distances.Add(totalDistance);
        }

        return distances;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day09/input.txt");
    }
}
