namespace Location_Finder;

public class AppSettings
{
    public required LocatorProviders LocatorProviders { get; set; }
    public required Connection Connection { get; set; }
    public required RabbitMQConfiguration RabbitMqConfiguration { get; set; }
}

public class LocatorProviders
{
    public IPGeoProvider IPGeoProvider { get; set; }
}

public class IPGeoProvider
{
    public required string URL { get; set; }
    public required string ApiKey { get; set; }
}

public class Connection
{
    public required string Host { get; set; }
    public required string DatabaseName { get; set; }
}

public class RabbitMQConfiguration
{
    public required string Host { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}
