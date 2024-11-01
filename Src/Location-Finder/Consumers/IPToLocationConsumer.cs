using Location_Finder.Feature;
using MassTransit;
using Messages.LocatorMessages;

namespace Location_Finder.Consumers;

public class IPToLocationConsumer(LocationService locationService) : IConsumer<IPToLocationMessage>
{
    private readonly LocationService _locationService = locationService;
    public async Task Consume(ConsumeContext<IPToLocationMessage> context)
    {
        var ipLocation = await _locationService.GetLocation(context.Message.IPAddress);
        if (ipLocation != null)
            await context.Publish(new LocationFetchedMessage(
                context.Message.RequestId,
                context.Message.IPAddress,
                ipLocation.Location.Country,
                ipLocation.Location.City
                ));
    }
}
