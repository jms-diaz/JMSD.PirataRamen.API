# JMSD.PirataRamen.API

**JMSD.PirataRamen.API** is the backend server for the Pirata Ramen Overload website, a food website dedicated to providing information about various ramen dishes, sides, appetizers, drinks, and desserts. This API is built using .NET 7, Dapper, and SQL Server.

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Running the API](#running-the-api)
- [API Endpoints](#api-endpoints)
- [License](#license)

## Features

- CRUD operations for Product and Category entities
- Organized using Repository and Service layers
- SQL Server integration with Dapper for data access

## Requirements

- .NET 7 SDK
- SQL Server
- Visual Studio 2022 or later / Visual Studio Code

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/jms-diaz/JMSD.PirataRamen.API.git
    cd JMSD.PirataRamen.API
    ```

2. Restore the .NET packages:
    ```sh
    dotnet restore
    ```

## Database Setup

1. Open SQL Server Management Studio (SSMS) or any SQL client connected to your SQL Server instance.

2. Execute the script provided to set up the database and tables.

## Configuration

1. Configure your database connection string in `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=PirataRamen;User Id=your_username;Password=your_password;"
      }
    }
    ```

## Running the API

1. Build the project:
    ```sh
    dotnet build
    ```

2. Run the project:
    ```sh
    dotnet run
    ```

## API Endpoints

The following endpoints are available in the API:

### Products

- **GET /api/products**: Retrieve all products
- **GET /api/products/{id}**: Retrieve a product by ID
- **POST /api/products**: Create a new product
- **PUT /api/products/{id}**: Update an existing product
- **DELETE /api/products/{id}**: Delete a product by ID

### Categories

- **GET /api/categories**: Retrieve all categories
- **GET /api/categories/{id}**: Retrieve a category by ID
- **POST /api/categories**: Create a new category
- **PUT /api/categories/{id}**: Update an existing category
- **DELETE /api/categories/{id}**: Delete a category by ID

## License

This project is licensed under the MIT License.
