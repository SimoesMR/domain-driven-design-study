# Domain Drive Design Project in C#
This project is an application developed in C# using the principles of Domain-Driven Design (DDD). The goal is to provide a solid foundation for scalable, organized, and maintainable applications.

# 📖 Overview
This project was developed with the following main objectives:
Clear separation of responsibilities following DDD concepts.
CPF validation and system function-related queries.
Scalability and flexibility to meet new requirements.
Support for programming best practices such as SOLID and Clean Code.

# 💻 Technologies Used

The main technologies and frameworks used in the project include:
.NET 7
Entity Framework Core
AutoMapper
FluentValidation
Swagger (for API documentation)

# 🗂 Project Structure

The project structure follows the recommended pattern for DDD:

src/
├── Domain/         # Entities, Value Objects, and Repository Interfaces
├── Application/    # Use Cases, Application Services, and DTOs
├── Infrastructure/ # Repository Implementations, Database Configurations
├── API/            # Controllers, Middleware Configurations, and Routes
└── Tests/          # Unit and Integration Tests

Main Components
Domain: Responsible for representing business rules and domain concepts.
Application: Orchestrates use cases and handles communication between the domain and infrastructure.
Infrastructure: Implements technical details such as data persistence and external API integration.
API: Entry point for system communication.

