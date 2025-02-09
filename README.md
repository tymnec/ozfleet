# ozfleet
Ozfleet Management Software: Empowering Your Fleet's Success


Structure of ozfleet.
OZFleet
│
├── OZFleet.sln
├── OZFleet.Core
│   └── OZFleet.Core.csproj
├── OZFleet.Application
│   └── OZFleet.Application.csproj
├── OZFleet.Infrastructure
│   └── OZFleet.Infrastructure.csproj
└── OZFleet.WebApi
    └── OZFleet.WebApi.csproj

##Project Structure Details:
To clarify the contents of each project (such as what each project consists of), I'll break down the typical project structure for each of your mentioned projects, based on Clean Architecture principles. Here’s an outline of what each project generally contains:

### 1. **OZFleet.Application**  
This project contains the **Application Layer** of the solution. It handles business logic, use cases, and service abstractions. It typically contains:
- **Use Cases/Commands**: Defines application-specific logic (e.g., Register Fleet, Assign Vehicle).
- **Interfaces**: Interfaces for repositories or services that interact with external systems (e.g., ICarRepository, IEmployeeService).
- **DTOs (Data Transfer Objects)**: Objects for data transfer, often used to map between the domain and API layers.
- **Application Services**: Orchestrates business operations and coordinates between the Core and Infrastructure layers.

Example Files:
- `OZFleet.Application.csproj` (Main project file)
- `UseCases/` (Folder containing application use cases like `RegisterFleet.cs`)
- `Interfaces/` (Folder containing interfaces like `ICarService.cs`)

### 2. **OZFleet.Core**  
This project is the **Core Domain Layer** of your Clean Architecture solution. It holds all the core business models and domain logic. This is where the primary entities, aggregates, and domain services reside. It typically contains:
- **Entities**: Core domain objects (e.g., `Fleet`, `Vehicle`, `Driver`).
- **Aggregates**: Collections of entities bound together (e.g., `Fleet` might aggregate multiple `Vehicle` entities).
- **Value Objects**: Immutable objects that define concepts (e.g., `Address`, `Coordinates`).
- **Domain Services**: Services that encapsulate business logic (e.g., `FleetAssignmentService`).
- **Interfaces for Repositories**: Abstractions for data access (e.g., `IFleetRepository`, `IVehicleRepository`).

Example Files:
- `OZFleet.Core.csproj` (Main project file)
- `Entities/` (Folder containing domain entities like `Fleet.cs`, `Vehicle.cs`)
- `Services/` (Folder containing domain services like `FleetAssignmentService.cs`)

### 3. **OZFleet.Infrastructure**  
This project is responsible for the **Infrastructure Layer**. It contains implementations of the interfaces defined in the Application and Core layers. This is where the code interacts with external systems like databases, file storage, and APIs. It typically contains:
- **Repositories**: Concrete implementations of repository interfaces defined in the Core layer (e.g., `SqlFleetRepository`).
- **Data Access**: Interaction with databases using ORM like Entity Framework or direct SQL queries.
- **External Services**: Integration with external APIs or third-party services (e.g., payment gateways, external fleet management systems).
- **Configuration/Dependency Injection**: Setup for dependency injection to bind interfaces to implementations.

Example Files:
- `OZFleet.Infrastructure.csproj` (Main project file)
- `Repositories/` (Folder containing concrete repository implementations like `SqlFleetRepository.cs`)
- `Services/` (Folder containing services interacting with external systems like `PaymentGatewayService.cs`)
- `Configurations/` (Folder for database or external system configuration)

### 4. **OZFleet.WebApi**  
This is the **Web API Layer**, responsible for exposing the functionality of your system over HTTP. It typically contains:
- **Controllers**: API controllers that handle HTTP requests (e.g., `FleetController`, `VehicleController`).
- **DTOs**: Data transfer objects for API communication, to map the request/response data.
- **Middleware**: Custom middlewares for things like logging, exception handling, and authentication.
- **Dependency Injection**: Configuration to wire up dependencies for controllers and services.

Example Files:
- `OZFleet.WebApi.csproj` (Main project file)
- `Controllers/` (Folder containing controllers like `FleetController.cs`)
- `Models/` (Folder containing API request/response models like `FleetDto.cs`)
- `Middleware/` (Folder containing custom middleware classes like `LoggingMiddleware.cs`)

### 5. **Other Files/Directories**  
Apart from these main projects, there will be other directories and files for configuration and metadata, such as:
- **obj/**: Contains intermediate object files, used during the build process.
- **bin/**: Contains the compiled output files (like DLLs) after the build.
- **README.md**: A file containing documentation for the project.
- **LICENSE**: A file that specifies the legal licensing terms of the project.

### Summary Table of Contents:

| **Project**              | **Contains**                                                                 | **Example Files**                                                      |
|--------------------------|-------------------------------------------------------------------------------|------------------------------------------------------------------------|
| `OZFleet.Application`     | Business logic, application services, use cases, DTOs, interfaces             | `UseCases/`, `Interfaces/`, `OZFleet.Application.csproj`               |
| `OZFleet.Core`            | Domain models, entities, aggregates, domain services, interfaces for repos   | `Entities/`, `Services/`, `OZFleet.Core.csproj`                        |
| `OZFleet.Infrastructure`  | Implementations of data access, external integrations, repositories           | `Repositories/`, `Services/`, `OZFleet.Infrastructure.csproj`          |
| `OZFleet.WebApi`          | API controllers, routes, middleware, dependency injection for web services    | `Controllers/`, `Models/`, `OZFleet.WebApi.csproj`                     |
| `LICENSE`                 | Licensing information                                                         | `LICENSE`                                                              |
| `README.md`               | Project documentation                                                        | `README.md`                                                            |

This structure follows Clean Architecture principles, with clear separation between the different layers of the application (e.g., Core, Application, Infrastructure, and Web API). Each layer is decoupled from the others, making the application more maintainable and testable.