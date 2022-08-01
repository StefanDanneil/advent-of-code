namespace solutions._2015;

public class Location
{
    private Dictionary<Location, int> _connections = new Dictionary<Location, int>();
    public string Name;

    public Location(string name)
    {
        Name = name;
    }

    public void AddConnection(Location location, int distance)
    {
        if (!_connections.ContainsKey(location))
        {
            _connections[location] = distance;
        }
    }

    public Dictionary<Location, int> GetConnections()
    {
        return _connections;
    }
}

public class Day9
{

    public int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var instructions = input.Split('\n');
        var locations = new Dictionary<string, Location>();
        var distances = new List<int>();
        
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
                var shortestAvailableConnection = 
                    currentLocation.GetConnections()
                        .Where(c => !visited.Contains(c.Key.Name))
                        .MinBy(c => c.Value);
            
                totalDistance += shortestAvailableConnection.Value;
                currentLocation = shortestAvailableConnection.Key;
                visited.Add(currentLocation.Name);
            }
            
            distances.Add(totalDistance);
        }
        
        return distances.Min();
    }

    public int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        var instructions = input.Split('\n');
        var locations = new Dictionary<string, Location>();
        var distances = new List<int>();
        
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
                var shortestAvailableConnection = 
                    currentLocation.GetConnections()
                        .Where(c => !visited.Contains(c.Key.Name))
                        .MaxBy(c => c.Value);
            
                totalDistance += shortestAvailableConnection.Value;
                currentLocation = shortestAvailableConnection.Key;
                visited.Add(currentLocation.Name);
            }
            
            distances.Add(totalDistance);
        }
        
        return distances.Max();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day9/input.txt");
    }
}
