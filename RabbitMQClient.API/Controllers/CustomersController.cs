using MessagingEvents.Shared;
using MessagingEvents.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQClient.Customers.API.Bus;

namespace RabbitMQClient.Customers.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        const string ROUTING_KEY_CREATED = "customer-created";
        const string ROUTING_KEY_DELETED = "customer-deleted";

        private readonly IBusService _bus;

        public CustomersController(IBusService bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Post(CustomerInputModel model)
        {
            var @event = new CustomerCreated(model.Id, model.FullName, model.Email, model.PhoneNumber, model.BirthDate);

            _bus.Publish(ROUTING_KEY_CREATED, @event);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _bus.Publish(ROUTING_KEY_DELETED, id);

            return NoContent();
        }
    }
}

