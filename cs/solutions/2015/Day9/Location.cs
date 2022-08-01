namespace solutions._2015;

public class Location
{
    private readonly Dictionary<Location, int> _connections;
    public readonly string Name;

    public Location(string name)
    {
        Name = name;
        _connections = new Dictionary<Location, int>();
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