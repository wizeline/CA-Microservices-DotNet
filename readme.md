# Code Accelerators .NET Microservice

Code Accelerators: Microservices - .NET

## Overall

### Description

This initiative aims to expedite the development of applications in their initial stages by providing project templates in various programming languages. These templates will adhere to a hexagonal architecture, enabling efficient and straightforward implementation and customization. This architectural approach promotes greater modularity and maintainability, adhering to best software development practices.

### Purpose

This project is a template for developers who are working on a project using microservices. The goal is to accelerate the development by providing a base solution using clean architecture and also help to standardize the architecture among all the microservices of the app. These two goals are oriented to save time in the development process. The project is built with .NET 8 and containerized using Docker.

## Specification

### Content

- Clean architecture: The project follows the principles of clean architecture, such as separation of concerns, dependency injection, and use of abstractions. The project is organized into four layers: presentation, application, domain, and infrastructure. Each layer has its own responsibilities and dependencies, which are clearly defined and isolated.
- Docker support: The project is designed to run on Docker containers, which provide a consistent and portable environment for deployment. The project includes a Dockerfile and a docker-compose file to build and run the microservice with all the required dependencies.

- Swagger: The project uses Swagger to document and test the API endpoints of the microservice. The project uses the Swashbuckle.AspNetCore library to generate and serve the Swagger UI and the OpenAPI specification.

# Git
- Source control: [Gitflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) 
- [Commit conventions](https://www.conventionalcommits.org/en/v1.0.0/#specification)

### Architecture
This microservice follows a hexagonal architecture, also known as clean architecture. This architectural style promotes separation of concerns, loose coupling, and testability. Here's a breakdown of the key components:

**Presentation Layer:** This layer handles user interactions and formatting of data for display. It interacts with the application layer but remains independent of the specific technology or logic used.

**Application Layer:** This layer implements the core business logic of the microservice. It interacts with the infraestructure layer but is independent of the technology or framework used.

**Domain Layer:** This layer represents the core business concepts and rules of the application. It's independent of any infrastructure or technology.

**Infrastructure Layer:** This layer provides the implementation details for persistence and other technical concerns. It depends on the chosen technology stack (e.g., database).

**Docker:** The project utilizes Docker containers for packaging and deployment, ensuring a consistent and portable environment.

**Swagger:** The project leverages Swagger for API documentation and testing, enhancing development experience and easier integration with other applications.


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
