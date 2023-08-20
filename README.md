
# Hi, there 🙌

**here is what I have done on the day-13 of A2SV, .NET Learning Path.**

### Title: a Blog API with Clean Architecture
In the last four days, I've been working hard to make BlogAPP even better. It's a place where users can write and share their blogs, and others will give comments. I've delved deep into clean architecture, a method that keeps things tidy and manageable. This approach ensures the app stays organized and allows for easy updates in the future.
 
#### In my journey with this BlogApp, I've explored several important concepts:
1. **MediatR:**
MediatR is a library that simplifies communication between different parts of an application by implementing the Mediator pattern. It provides a way to decouple components and manage messages (commands and queries) sent between them. This promotes loose coupling and modularity, making it easier to extend and maintain the application.
I used MediatR to :

 - handle requests like creating a new blog post or retrieving a list of blog posts. Commands and queries are encapsulated as messages, and MediatR ensures that they are sent to the appropriate handlers.
 - thin controller: to keep the logic within the controller as minimal as possible. Instead of placing extensive business logic and data manipulation directly in the controller,  delegate the majority of its responsibilities to other components in the application.

2. **CQRS (Command Query Responsibility Segregation):**
   CQRS is a design pattern that separates the responsibilities of reading data (queries) and writing data (commands) into separate parts. In a CQRS architecture, the data model used for reading is often different from the one used for writing, allowing each to be optimized for its specific purpose. This separation can lead to improved performance, scalability, and maintainability. It's particularly useful in complex systems where the read and write operations have different requirements.

3. **AutoMapper:**
   AutoMapper is a library that simplifies the process of mapping data from one object to another. It's especially helpful when transforming data between DTOs (Data Transfer Objects) and domain objects. It automates the tedious task of manually assigning properties between objects with similar structures. AutoMapper reduces repetitive code, improves readability, and promotes clean coding practices.
 I used AutoMapper  to map data between domain models(Entities) and DTOs. For example, when retrieving a blog post from the database, AutoMapper can automatically map the database entity to a DTO that's sent as a response to the client.

4. **Data Validation:**
Instead of directly using the datas that come from the user, It should be validated first. Otherwise the invalid data may results breage of the system. Considering this, I used Fluent validation package to validate the Incoming data from the user.
   Fluent Validation, is a powerful .NET package, empowers  to  examine and validate user-generated data. 
  5. **Exception Handling:**
  During the process of handling requests, there are times when something unexpected might happen, causing errors to occur. To prevent these errors from causing disruptions, I implemented  Custom Exception Middleware. This  helps manage and handle those unexpected situations more effectively. I was playing around It.
 5. **PostgreSQL**
PostgreSQL is a strong type of database that works with SQL. This database is really good at handling data and making connections between different Entities. In this project, I used PostgreSQL, and I had a positive experience using it.
---
### Packages:
- AutoMapper
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Npgsql.EntityFrameworkCore.PostgreSQL
- Newtonsoft.Json
- FluentValidation.DependencyInjectionExtensions
<h3 align="left">Tools:</h3>  
<p align="left" >
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="200" height="100"/> 
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="200" height="100"/>
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/postgresql/postgresql-original-wordmark.svg" alt="postgresql" width="200"  height="100"/> 
<img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="200" height="100"/>

<img src="https://www.vectorlogo.zone/logos/getpostman/getpostman-icon.svg" alt="postman" width="100" height="100"/>
</p>

