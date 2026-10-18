# Phone Book - Tutorial CRUD Application
This is a hands-on backend project learning exercise focused on implementing CRUD (Create, Read, Update, Delete) operations, REST APIs, working with databases and understand how the frontend, backend and database communicate with each other


## Table of Contents

- [Project Goals](#project-goals)
- [Technology Stack](#technology-stack)
- [Application Structure](#application-structure)

## Project Goals

The goals of the project are:

- Practise CRUD operations using C#.

- Build a backend API with ASP.NET Core.

- Connect the backend to a local SQL Server database.

- Use Entity Framework Core to interact with the database.

- Understand foreign keys and relationships between entities.

- Learn how to manage database schema changes with migrations.

- Practise Git and GitHub version control.

- Document the development process and lessons learned.

## Technology Stack

<table>
  <thead>
    <tr>
      <th>Technology</th>
      <th>Purpose</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>C#</td>
      <td>Application programming language</td>
    </tr>
    <tr>
      <td>.NET</td>
      <td>Application development platform</td>
    </tr>
     <tr>
      <td>ASP.NET Core Web API</td>
      <td>Backend API</td>
    </tr>
    <tr>
      <td>SQL Server LocalDB</td>
      <td>Relational Database</td>
    </tr>
    <tr>
      <td>Entity Framework Core</td>
      <td>Database Access and ORM</td>
    </tr>
    <tr>
      <td>ADO .NET SQL Server Provider</td>
      <td>Backend connects to SQL Server through EF Core</td>
    </tr>
    <tr>
      <td>Git</td>
      <td>Version Control</td>
    </tr>
    <tr>
      <td>GitHub</td>
      <td>Source Code hosting and project documentation</td>
    </tr>
  </tbody>
</table>

## Application Structure

The application is divided into two main components: 
- Console application
- Backend API. 

The console application serves as the user interface, while the backend API handles data processing and database interactions.

```text
Phone_Book/
├-- Phone_Book.Cli/       # Console application
├── Phone_Book.API/       # Backend API
│   ├── Models/           # Entity models
│   ├── Data/             # Database context
│   ├── Migrations/       # Database schema changes
│   └── Program.cs        # Application configuration
├── .gitignore
└── README.md
```

The console application communicates with the backend through HTTP requests. The backend uses Entity Framework Core to communicate with SQL Server.
