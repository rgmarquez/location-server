public class Location {
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public double Altitude {get; set;}

    public static Location Create(double latitude, double longitude, double altitude) {
        return new Location() {Latitude = latitude, Longitude = longitude, Altitude = altitude};
    }
}
