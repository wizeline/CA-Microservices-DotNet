# Code Accelerators .NET Microservice

Code Accelerators: Microservices - .NET

## Overall

### Description

This initiative aims to expedite the development of applications in their initial stages by providing project templates in various programming languages. These templates will adhere to a hexagonal architecture, enabling efficient and straightforward implementation and customization. This architectural approach promotes greater modularity and maintainability, adhering to best software development practices.

### Purpose

This project is a template for developers who are working on a project using microservices. The goal is to accelerate the development by providing a base solution using clean architecture and also help to standardize the architecture among all the microservices of the app. These two goals are oriented to save time in the development process. The project is built with .NET 8 and containerized using Docker.

## Specification

### Architecture
This microservice follows a hexagonal architecture, also known as clean architecture. This architectural style promotes separation of concerns, loose coupling, and testability. Here's a breakdown of the key components:

**Presentation Layer:** This layer handles user interactions and formatting of data for display. It interacts with the application layer but remains independent of the specific technology or logic used.

**Application Layer:** This layer implements the core business logic of the microservice. It interacts with the infraestructure layer but is independent of the technology or framework used.

**Domain Layer:** This layer represents the core business concepts and rules of the application. It's independent of any infrastructure or technology.

**Infrastructure Layer:** This layer provides the implementation details for persistence and other technical concerns. It depends on the chosen technology stack (e.g., database).

**Docker:** The project utilizes Docker containers for packaging and deployment, ensuring a consistent and portable environment.

**Swagger:** The project leverages Swagger for API documentation and testing, enhancing development experience and easier integration with other applications.

## Cross-Cutting Concerns in a .NET Microservice

**What are Cross-Cutting Concerns?**

Cross-cutting concerns are functionalities that apply horizontally across an entire application, rather than being specific to any particular business logic. They are essential aspects that cut through various layers of the application and need to be implemented consistently. This project outlines some essential cross-cutting concerns typically implemented in a .NET microservice architecture.

**1. Authentication and Authorization:**

* **Purpose:** Validate user identity and control access to resources based on permissions.
* **Implementation:**
    * This microservice utilizes **Identity Server** for centralized authentication and authorization using Bearer Token authentication.
    * Within the application itself, **Identity Framework 8** is used to manage user claims and authorization checks using bearer tokens with a 1h expiration time.

**2. Caching:**

* **Purpose:** Improve performance by storing frequently accessed data in memory for faster retrieval.
* **Implementation:**
    * This project leverages the built-in **IMemoryCache** service provided by ASP.NET Core.
* **Considerations:**
    * Define appropriate cache invalidation strategies to ensure data consistency.
    * Set cache expiration times to manage stale data and optimize cache utilization.

**3. Logging:**

* **Purpose:** Record application events and errors into the database for monitoring and debugging.
* **Implementation:**
    * This project utilizes **Serilog** for structured logging, configured to write logs to a **Microsoft SQL Server (MSSQL)** database into a **Logs** table.
* **Considerations:**
    * Define different logging levels (e.g., Information, Warning, Error) for granular logging.
    * Configure log sinks in program.cs or appsettings.json to send logs to appropriate destinations (e.g., console, file, etc).

**4. Health Checks:**

* **Purpose:** Verify the overall health and readiness of the microservice.
* **Implementation:**
    * The API layer includes a custom health check named `SampleHealthcheck`. This check verifies the overall health of the service and additionally includes a specific check to ensure the **database connection is alive**.
    * ASP.NET Core built-in health checks can also be implemented for exposing additional service health endpoints.
* **Considerations:**
    * Define health checks that reflect critical functionalities of your microservice.
    * Configure health checks in ``program.cs to be easily accessible by monitoring tools.

**5. Database Connection:**

* **Purpose:** Establish and manage connections to the database for data persistence.
* **Implementation:**
    * This project utilizes **Entity Framework Core 8 (EF Core 8)** for object-relational mapping (ORM) and database access. 
    * Database configurations are defined using **Fluent API** within the **Persistence Layer**. Fluent API provides a code-based way to configure entity mappings and relationships.


### Requirements

- Visual Studio 2022 or higher.
- .NET 8 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Docker Desktop (https://www.docker.com/)
- Database Explorer of your preference.

## Setup

### Install
1. Install the requirements.
2. Clone this repository to your local machine.

## Running

### Local

#### Run

Option 1:
1. Open the project using Visual Studio.
2. In the solution explorer,  right click on the docker-compose project and select *"Set as startup project"*
3. Build the project.
4. Run the project or press F5.


Option 2: 
1. In a command prompt navigate to the root folder of the project and run the command 
```zsh
docker-compose up -d
```
This will build the Docker image and run the microservice along with the required dependencies, such as the database and the message broker.

2. Open a browser and navigate to `http://localhost:5000/swagger` to see the Swagger UI of the microservice. You can use the Swagger UI to explore and test the API endpoints of the microservice.
3. To stop the project, run the command 
```zsh
docker-compose down
```

## Any assistance?

### Team Members

- <liliana.fernandez@wizeline.com> - Product Owner
- <diego.lozano@wizeline.com> - Product Owner
- <alexis.juarez@wizeline.com> - Technical Lead
- <diana.dominguez@wizeline.com> - Software Engineer

### Documentation and Confluence page

[Confluence page](https://wizeline.atlassian.net/wiki/spaces/wiki/pages/3894771727/Microservices)

## Contributing

This project is open for contributions. If you want to contribute to this project, please follow these guidelines:

- Fork the repository and create a new branch for your feature or bug fix.
- Write clean and maintainable code following the coding standards and conventions of the project.
- Write unit tests and integration tests to cover your code changes.
- Run the tests and ensure that they pass.
- Commit your changes and push them to your forked repository.
- Create a pull request with a clear description of your changes and a reference to the issue that you are addressing.
- Wait for the code review and feedback from the maintainers.
