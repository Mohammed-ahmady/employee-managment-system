# Employee Management System

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-blue.svg)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-Latest-green.svg)
![License](https://img.shields.io/badge/License-MIT-yellow.svg)

A robust, secure, and user-friendly web application for managing employee records and departmental information.

## Overview

The Employee Management System is built using ASP.NET Core MVC and Entity Framework Core, providing a comprehensive solution for HR departments to efficiently manage employee data. The application supports CRUD operations for employees and departments with a clean, responsive user interface.

## Features

- **Employee Management**
  - Create, read, update, and delete employee records
  - Sort employees by any field (ID, name, salary, etc.)
  - Search functionality by employee name
  - Validation of employee data

- **Department Integration**
  - Associate employees with departments
  - Manage department information

- **Data Visualization**
  - Tabular representation of employee data
  - Sorting indicators for better user experience

- **Security**
  - Secure storage of connection strings in configuration
  - Protection against common web vulnerabilities

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or later
- [SQL Server](https://www.microsoft.com/sql-server) (Local or Docker)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) / [Visual Studio Code](https://code.visualstudio.com/) / [JetBrains Rider](https://www.jetbrains.com/rider/)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/employee-management-system.git
   cd employee-management-system
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Update the database connection string in `appsettings.json` or use environment-specific configuration.

4. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

## Configuration

The application uses the standard ASP.NET Core configuration system:

- **appsettings.json**: Contains default settings including database connection string
- **appsettings.Development.json**: Development-specific settings (not committed to source control)
- **Environment Variables**: Can override configuration settings in production

### Database Connection

Configure your database connection string in the appropriate configuration file:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=your_database;User=your_username;Password=your_password;"
}
