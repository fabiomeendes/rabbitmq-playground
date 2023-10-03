using MessagingEvents.Shared;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace RabbitMQClient.Marketing.API.Subscribers
{
    public class CustomerDeletedSubscriber : IHostedService
	{
        private readonly IModel _channel;

        const string CUSTOMER_CREATED_QUEUE = "customer-deleted";

        public CustomerDeletedSubscriber()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("curso-rabbitmq-client-consumer");

            _channel = connection.CreateModel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);

                var @event = JsonSerializer.Deserialize<int>(contentString);

                Console.WriteLine($"Message received: {contentString}");

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(CUSTOMER_CREATED_QUEUE, false, consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

