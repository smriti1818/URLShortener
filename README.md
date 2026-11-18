# URL Shortener

A URL Shortener application built using React.js, ASP.NET Core Web API, Entity Framework Core, and SQL Server.

## Technology Stack

- Backend: ASP.NET Core Web API (.NET 11)
- Frontend: React.js (planned)
- Database: SQL Server
- ORM: Entity Framework Core
- API Documentation: Swagger / OpenAPI

## Current Features

- Generate unique short codes for long URLs.
- Store URL mappings in SQL Server.
- Redirect short URLs to their original URLs.
- Validate submitted URLs.
- Expose APIs through Swagger.

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/Urls/shorten | Generate a short URL |
| GET | /{shortCode} | Redirect to the original URL |

## Database Setup

1. Create a SQL Server database named URLShortenerDB.
2. Configure the DefaultConnection connection string in appsettings.Development.json.
3. Run database migrations:

   dotnet ef database update

## Run the Backend

   dotnet run

Open Swagger:

   https://localhost:<port>/swagger

## Project Structure

- Controllers: API endpoints
- DTOs: Request models
- Data: Entity Framework DbContext
- Models: Database entities
- Services: Business logic
- Migrations: Database schema migrations

## Future Enhancements

- React frontend integration
- URL click analytics
- Collision handling and retry logic
- Unit and integration tests
