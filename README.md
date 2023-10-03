# rabbitmq-playground

This repository serves as a playground for exploring RabbitMQ and MassTransit concepts. It's designed to help you understand and experiment with message queueing using RabbitMQ in a .NET environment.

## Overview

We are using the Publish-Subscribe pattern to facilitate communication between the Customers.API and Marketing.API components of our system. This pattern allows for decoupled, efficient, and scalable communication between different parts of an application.

## Getting Started

To get started with this project, follow these steps:

### Prerequisites

Before you begin, ensure you have the following prerequisites installed:

- .NET SDK (version 7.0.203 or higher)
- RabbitMQ.Client (version 6.5.0)
- MassTransit.RabbitMQ (version 8.0.16)

### Running the Application

- Select the Customers.API project as the startup project in your development environment (e.g., Visual Studio, Visual Studio Code, Rider).
- In parallel, open another terminal or command prompt and navigate to the project directory. Run the Marketing.API project from the command line:
```shell
dotnet run
```
- With both the Customers.API and Marketing.API running, you can interact with the system via Swagger. Open a web browser and navigate to the Swagger UI for Customers.API.
- Use Swagger to send requests in JSON format to the Customers.API. These requests will be published to RabbitMQ.
- In your terminal where Marketing.API is running, you will see the responses received by the Subscriber (Marketing).

### Additional Notes
- When using the RabbitMQ.Client library, ensure that you have appropriately created the necessary exchanges, queues, and bindings in the RabbitMQ management interface. Proper configuration of these components is essential for the correct functioning of the Publish-Subscribe pattern.
- Make sure RabbitMQ is properly configured and running. You may need to adjust the connection settings in the appsettings.json file of both API projects.
- Explore the code in this repository to gain insights into how RabbitMQ and MassTransit are implemented in a .NET application.
