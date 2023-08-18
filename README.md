

# Hi, there 🙌

**here is what I have done on the day-12 of A2SV, .NET Learning Path.**

### Title: Building a Blog API with Clean Architecture Part - IV
On the day-12 of the project, I dedicated my efforts to the application layer. This involved a comprehensive utilization of CQRS, AutoMapper, and MediatR to bring the application layer of the clean architecture to fruition. Through these tools, I was able to effectively implement and enhance this critical layer of the project.

1. **CQRS (Command Query Responsibility Segregation):**
   CQRS is a design pattern that separates the responsibilities of reading data (queries) and writing data (commands) into separate parts. In a CQRS architecture, the data model used for reading is often different from the one used for writing, allowing each to be optimized for its specific purpose. This separation can lead to improved performance, scalability, and maintainability. It's particularly useful in complex systems where the read and write operations have different requirements.

2. **AutoMapper:**
   AutoMapper is a library that simplifies the process of mapping data from one object to another. It's especially helpful when transforming data between DTOs (Data Transfer Objects) and domain objects. It automates the tedious task of manually assigning properties between objects with similar structures. AutoMapper reduces repetitive code, improves readability, and promotes clean coding practices.
 I used AutoMapper  to map data between domain models(Entities) and DTOs. For example, when retrieving a blog post from the database, AutoMapper can automatically map the database entity to a DTO that's sent as a response to the client.

3. **MediatR:**
   MediatR is a library that simplifies communication between different parts of an application by implementing the Mediator pattern. It provides a way to decouple components and manage messages (commands and queries) sent between them. This promotes loose coupling and modularity, making it easier to extend and maintain the application.
I used MediatR to handle requests like creating a new blog post or retrieving a list of blog posts. Commands and queries are encapsulated as messages, and MediatR ensures that they are sent to the appropriate handlers.
---

### Tasks:

1. **Implement the Automapper:**
   -   Set up an AutoMapper Profile and Configuration.
	-   Seamlessly convert Request DTOs to Entity Models.
	-   Ensure data returned follows the desired format of Response DTOs.
	-   Facilitate smooth data flow across application layers.data in the Response DTO's format
2. **CQRS and MediatR**
   -   Separate and implement CQRS command and query requests for Post and Comment functionalities.
	-   Maintain distinct responsibilities for issuing commands and making queries.
	-   Skillfully handle requests for smooth execution.
	-   Utilize MediatR to map and dispatch HTTP requests to appropriate repositories.
	-   Streamline communication flow between layers through MediatR's capabilities.

---
### Packages:
- AutoMapper
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Npgsql.EntityFrameworkCore.PostgreSQL
- 
<h3 align="left">Tools:</h3>  
<p align="left" >
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="300" height="100"/> 
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="300" height="100"/>
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/postgresql/postgresql-original-wordmark.svg" alt="postgresql" width="300"  height="100"/> 
</p>

