# Cash Flow API

## Introduction

The Cash Flow API is a simple web application built using .NET 8 to provide cash flow data over a specified date range. The application follows a layered architecture with dependency injection, making it modular and maintainable.

## Technologies Used

- .NET 8
- Entity Framework Core
- AutoMapper
- Microsoft SQL Server (hosted on somee.com)
- Swagger for API documentation

## Project Structure

1. **Controller**

   - `CashFlowController`: Contains a single HTTP GET endpoint to retrieve cash flow data.

2. **Services**

   - `ICashFlowService`: Interface defining the `GetCashFlow` method.
   - `CashFlowService`: Implements `ICashFlowService` and contains business logic.

3. **Repositories**

- `ICashFlowRepository`: Interface defining the `GetCashFlowAsync` method.
- `CashFlowRepository`: Implements `ICashFlowRepository` and handles database operations.

2. **Data Context**

   - `CashFlowDataContext`: Inherits from `DbContext` and manages database interactions.

3. **Models**

   - `CashFlowRequestDto`: Represents the request parameters for cash flow retrieval.
   - `CashFlowResponseDto`: Represents the response data structure.
   - `CashFlowDao`: Represents the database entity.

## Database

- The database is hosted remotely on [somee.com](https://somee.com) and uses Microsoft SQL Server.
- Connection details are available in `appsettings.json`.
- Contains a single table represented by the `CashFlowDao` class.
- Assumption: Each date entry is unique, eliminating the need for grouping by date.

## Usage

1. Update the connection string in `appsettings.json` if needed.
2. Build and run the application:
   ```bash
   dotnet build
   dotnet run
   ```
3. Access the API at [http://localhost:5000](http://localhost:5000).

## Endpoints

- **GET /api/CashFlow**
  - Retrieves cash flow data based on the provided date range.
  - Parameters:
    - `From` (required): Start date.
    - `To` (required): End date.

## Limitations

- No logging or exception handling middleware implemented.

## Future Improvements

- Add logging and exception handling middleware.
- Enhance validation for request parameters.
