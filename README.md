## Clean Architecture
This project demonstrates the application of Clean Architecture principles in a .NET application, providing a modular and scalable structure for developing robust and maintainable applications.​

## Project Structure
The architecture is organized into several distinct layers:​
**Domain:** Contains basic entities and interfaces that define the behavior of the domain.​
**Application:** Includes business logic, such as use cases and service interfaces.​
**Infrastructure:** Provides concrete implementations for interfaces defined in higher layers, such as data access or external services.​
**WebUI:** Represents the user interface, typically an ASP.NET Core web application, that interacts with the end user.​

This separation allows for independent development of each layer and facilitates testing and maintenance of the application.
