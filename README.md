# NoferApi

## Description
An API that provides aviation related data, such as Airport information.

## Prerequisites
Ensure you have the following installed before running the project:
- Dotnet 8 SDK
- Docker

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/swn14/NoferApi.git
   ```

2. Navigate to the project directory:
   ```sh
   cd NoferApi
   ```

3. Build the project:
   ```sh
   dotnet build
   ```

## Configuration
Modify the `appsettings.json` file to match your environment. If required, create an `appsettings.Development.json` file for local development.

## Running the Application

### Running Locally
To start the local Postgres database, use:
```sh
docker compose -f docker-compose.yml up -d
```

To start the application, use:
```sh
dotnet run
```

## Testing
To run tests:
```sh
dotnet test
```