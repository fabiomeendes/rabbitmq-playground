using MessagingEvents.Shared;
using MessagingEvents.Shared.Services;

namespace MassTransit.Marketing.API.Subscribers
{
    public class CustomerDeletedSubscriber : IConsumer<CustomerDeleted>
    {
        public IServiceProvider ServiceProvider { get;}
        public CustomerDeletedSubscriber(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<CustomerDeleted> context)
        {
            var @event = context.Message;

            using (var scope = ServiceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<INotificationService>();

                await service.SendEmail("e-mail", "Deleted!!!", new Dictionary<string, string> { { "name", @event.Id.ToString() } });
            }
        }
    }
}

