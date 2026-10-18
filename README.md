# Phone Book - Tutorial CRUD Application
This is a hands-on backend project learning exercise focused on implementing CRUD (Create, Read, Update, Delete) operations, REST APIs, working with databases and understand how the frontend, backend and database communicate with each other

## License
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

## Table of Contents

- [Project Goals](#project-goals)
- [Technology Stack](#technology-stack)
- [Application Structure](#application-structure)
- [Features](#features)
- [Getting Started](#getting-started)
- [Database and Migrations](#database-and-migrations)
- [Development Journey](#development-journey)
- [Lessons learnt](#lessons-learnt)
- [Dev Logs](#dev-logs)
- [Future Improvements](#future-improvements)
- [Author](#author)

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

## Features

### Authentication

- [ ] Create and Register a user.
- [ ] Allow users to log in.

### Planned CRUD Operation

- [ ] Create a contact.
- [ ] View all Contacts.
- [ ] View contacts by ID.
- [ ] Update a contact.
- [ ] Delete a contact.

### Additional Features
- [ ] Associate contacts with users through a foreign key.
- [ ] Validate user input.
- [ ] Handle API and database errors.

## Getting Started

### Prerequisites

- Windows 10 or later 
- .NET SDK 
- SQL Server LocalDB
- SQL Server Management Studios
- Code editor like Visual Studio or Visual Studio Code.
- Git and GitHub account for version control.

### Setup

1. Clone the repository to your local machine using Git.
```
git clone https://github.com/bophelo-t-jdit/Phone_Book.git
```

2. Open the solution in Visual Studio or Visual Studio Code.

3. Restore NuGet packages and build the solution.

4. Configure the database connection string in `appsettings.json` or `.env` of the backend API project.

5. Apply database migrations to create the database schema using Entity Framework Core.
```
dotnet ef database update --project Phone_Book.API --startup-project Phone_Book.API
```
6. Run API Project to start the backend server.

7. Run the console application in a powershell or CMD Windowto interact with the backend API.

8. Run both Console and Backend API in separate terminal windows simultaneously.

```
NOTE:
- Replace projects path or commands should the project differ in any way.
- Do not commit your .env sensitive information like connection strings or passwords to the repository.
- Do not forget to add your .env file to .gitignore to avoid accidental commits of sensitive information.
- Do not hardcode your sensitive information or secrets either.
```

## Environment Variables

To run this project, you will need to add the following environment variables to your .env file

`PHONE_BOOK_CONNECT="<ConectionString>"`


## Database and Migrations

Entity Framework Core migration are used to manage changes to the database schema and migrations.

The workflow is:

1. Update an entity model `Models`
2. Create a new migration using the command: (Backend Project, E.g. Phone_Book.API)
```
dotnet ef migrations add Migrations Name --project Backend Project --startup-project Backend Project
```
3. Review generated migration (Migration file `Migrations/`).
4. Apply the migration to the local database using:
```
dotnet ef database update --project Backend Project --startup-project Backend Project
```
5. Test the application against the updated schema

Migration files are committed to version control so the database schema can be recreated in another development environment.

## Development Journey

This section records the actual progress of the project, including implementation decisions, mistakes, fixes and lessons learned.

### Milestone 1: Project Setup

<b>Objective</b>: Create the console application and backend API.

- Created the solution and projects.

- Selected the .NET and C# development environment.

- Established the project folder structure.

#### What was learnt

- I can add more than one solution in one solution:
```
Main Solution/
|--- Project 1/
|--- Project 2/
|--- .gitignore
|--- README.md
```

### Milestone 2: Local SQL Server connection

<b>Objective</b>: Connect the backend to the SQL Server Local DB.

- Configured the local database connection string.

- Installed the EF Core SQL Server provider.

- Configured the database context in Program.cs.

- Resolved any .env configuration or parsing issues.

#### What was learnt

- I store the db connection string in the .env file as it is a secret.

- The difference between SQL Server LocalDB and SSMS.

- How a connection string identifies a database.

- How EF Core obtains a database connection.

### Milestone 4: CRUD API
<b>Objective</b>: Implement the contact endpoints.

- [Record the endpoints implemented.]

- [Document request and response examples.]

- [Record errors encountered and how they were fixed.]

#### What was learnt

- [Add lessons here.]

### Milestone 5: Console Client
<b>Objective</b>: Connect the console application to the API.

- [Record HTTP client implementation.]

- [Document how JSON requests and responses are handled.]

- [Record testing results.]

#### What was learnt

- [Add lessons here.]

## Lessons learnt
Record concepts and mistakes worth remembering.

## Dev Logs

- [18 October 2026](#18/10/26)

---

<b>18 October 2026</b>

<b>Change</b>: Connected the ASP.NET Core API to SQL Server LocalDB.

<b>What was done</b>

- Installed Microsoft.EntityFrameworkCore.SqlServer.

- Configured the connection string through a local .env file.

- Registered PhoneBookDbContext with dependency injection.

<b>Problem: </b>DotNetEnv raised a parsing exception because the connection string contained nested double quotes.

<b>Fix/es: </b>Removed the unnecessary nested quotes and simplified the connection string.

<b>What was learnt</b>

- .env files have their own parsing rules.

- ASP.NET Core does not automatically load .env files.

- UseSqlServer() configures EF Core to use SQL Server.

- Starting the API does not, by itself, prove that a database query succeeds.

<b>Result: </b>The API started successfully. Database connectivity was to be verified separately.

## Future Improvements

- Potential improvements once the basic CRUD functionality is complete:

- Add stronger validation and error handling.

- Add automated tests.

- Add filtering and searching for contacts.

- Implement user authentication and authorization if needed.

- Add logging and structured error responses.

<b>Status</b>: In development

## Author

- [@bophelo-t-jdit](https://github.com/bophelo-t-jdit)
