using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public sealed class LocationService {
    private static readonly LocationService instance = new LocationService();

    private LocationService(){}
    private static Dictionary<string, Location> locations = new Dictionary<string, Location>();

    public static LocationService Instance { get {return instance; }}

    public Location GetLocation(string guid) {
        if (guid == null) throw new ArgumentNullException("guid");

        if (locations.TryGetValue(guid, out Location location))
        {
            return location;
        }
        return null;
    }

    public Dictionary<string, Location> GetAllLocations () {
        return locations;
    }

    public void SetLocation(string guid, Location location) {
        if (guid == null) throw new ArgumentNullException("guid");
        if (location == null) throw new ArgumentNullException("location");

        locations[guid] = location;
    }

    public void DeleteLocation(string guid) {
        if (guid == null) throw new ArgumentNullException("guid");

        locations.Remove(guid);
    }
}
