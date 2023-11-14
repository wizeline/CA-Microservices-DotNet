# Code Accelerators .NET Microservice

This project is a template for developers who are working on a project using microservices. The goal is to accelerate the development by providing a base solution using clean architecture and also help to standardize the architecture among all the microservices of the app. These two goals are oriented to save time in the development process. The project is built with .NET 8 and containerized using Docker.

## Features

- Clean architecture: The project follows the principles of clean architecture, such as separation of concerns, dependency inversion, and use of abstractions. The project is organized into four layers: presentation, application, domain, and infrastructure. Each layer has its own responsibilities and dependencies, which are clearly defined and isolated.
- Docker support: The project is designed to run on Docker containers, which provide a consistent and portable environment for deployment. The project includes a Dockerfile and a docker-compose file to build and run the microservice with all the required dependencies.

- Swagger: The project uses Swagger to document and test the API endpoints of the microservice. The project uses the Swashbuckle.AspNetCore library to generate and serve the Swagger UI and the OpenAPI specification.

## Getting Started

To run the project, you need to have the following prerequisites installed:

- .NET 8 SDK
- Docker Desktop

To run the project using Docker, follow these steps:

1. Clone the repository to your local machine.
2. Navigate to the root folder of the project and run the command `docker-compose up -d`. This will build the Docker image and run the microservice along with the required dependencies, such as the database and the message broker.
3. Open a browser and navigate to `http://localhost:5000/swagger` to see the Swagger UI of the microservice. You can use the Swagger UI to explore and test the API endpoints of the microservice.
4. To stop the project, run the command `docker-compose down`.

## Contributing

This project is open for contributions. If you want to contribute to this project, please follow these guidelines:

- Fork the repository and create a new branch for your feature or bug fix.
- Write clean and maintainable code following the coding standards and conventions of the project.
- Write unit tests and integration tests to cover your code changes.
- Run the tests and ensure that they pass.
- Commit your changes and push them to your forked repository.
- Create a pull request with a clear description of your changes and a reference to the issue that you are addressing.
- Wait for the code review and feedback from the maintainers.
