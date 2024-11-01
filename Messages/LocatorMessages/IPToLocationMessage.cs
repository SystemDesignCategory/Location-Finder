namespace Messages.LocatorMessages;

public record IPToLocationMessage(Guid RequestId, string IPAddress);