using MassTransit;

namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler (
        IPublishEndpoint publishEndPoint,
        ILogger<OrderCreatedEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {

        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {

            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();

            await publishEndPoint.Publish(orderCreatedIntegrationEvent, cancellationToken);


        }
    }
}
