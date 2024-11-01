namespace Messages.LocatorMessages;

public record LocationFetchedMessage(Guid RequestId, string IPAddress, string Country, string City);