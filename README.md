# MVC Bartender Application

The MVC Bartender Application is an ASP.NET Core MVC application that allows patrons to view a cocktail menu and place cocktail orders. Bartenders can view submitted orders in an order queue and mark orders as ready for pickup.

## Technologies Used

- ASP.NET Core MVC
- .NET 8
- C#
- Entity Framework Core
- SQLite
- Bootstrap 5
- Razor Views

## Requirements

Before running the application, make sure the following are installed:

- .NET 8 SDK
- Entity Framework Core CLI tools

You can verify your .NET installation with:

```bash
dotnet --version
```

If the Entity Framework CLI is not installed, install it with:

```bash
dotnet tool install --global dotnet-ef --version 8.*
```

If you are using zsh on macOS and the wildcard causes an error, use quotes:

```bash
dotnet tool install --global dotnet-ef --version "8.*"
```

Verify the installation with:

```bash
dotnet ef --version
```

## Getting Started

### 1. Clone the repository

```bash
git clone <repository-url>
```

Then enter the repository:

```bash
cd MVC-Bartender-Application
```

### 2. Restore dependencies

Run:

```bash
dotnet restore
```

This restores the NuGet packages required by the application.

### 3. Build the application

Run:

```bash
dotnet build
```

The build should complete successfully before continuing.

### 4. Create the database

The local SQLite database file is not stored in GitHub.

Entity Framework migrations are included in the project so the database can be created locally.

Run:

```bash
dotnet ef database update --project MVC-Bartender-Application
```

This creates the SQLite database and applies the existing migrations.

### 5. Run the application

Run:

```bash
dotnet run --project MVC-Bartender-Application
```

The terminal will display the local address where the application is running, for example:

```text
http://localhost:5290
```

Open the address displayed in your terminal in a web browser.

> The exact port may be different on another computer.

## Application Pages

### Home

The homepage provides two options:

- **Order a Cocktail** — opens the cocktail menu.
- **Bartender Order Queue** — opens the bartender's order queue.

### Cocktail Menu

The cocktail menu displays the available cocktails stored in the database.

A patron can select a cocktail and place an order.

### Bartender Order Queue

The order queue displays cocktail orders submitted by patrons.

Bartenders can view pending orders and mark them as ready for pickup.

## Application Flow

```text
Home Page
   |
   +----> Order a Cocktail
   |          |
   |          v
   |     Cocktail Menu
   |          |
   |          v
   |      Place Order
   |          |
   |          v
   |   CocktailOrders Database
   |
   +----> Bartender Order Queue
              |
              v
        View Pending Orders
              |
              v
          Mark Ready
```

## Project Structure

```text
MVC-Bartender-Application/
|
├── Controllers/
|   ├── HomeController.cs
|   └── CocktailOrdersController.cs
|
├── Data/
|   ├── ApplicationDbContext.cs
|   └── DbInitializer.cs
|
├── Migrations/
|
├── Models/
|   ├── Cocktail.cs
|   └── CocktailOrder.cs
|
├── Views/
|   ├── Home/
|   |   └── Index.cshtml
|   |
|   ├── CocktailOrders/
|   |   ├── Menu.cshtml
|   |   └── Queue.cshtml
|   |
|   └── Shared/
|       └── _Layout.cshtml
|
├── wwwroot/
|   └── css/
|       └── site.css
|
├── Program.cs
├── appsettings.json
└── MVC-Bartender-Application.csproj
```

## Database

The application uses SQLite with Entity Framework Core.

The database contains the following main tables:

- `Cocktails`
- `CocktailOrders`

Cocktail data is seeded when the application initializes.

The local `.db` database file is ignored by Git and should be recreated using:

```bash
dotnet ef database update --project MVC-Bartender-Application
```

## Troubleshooting

### Entity Framework command not found

If:

```bash
dotnet ef
```

is not recognized, install the EF CLI:

```bash
dotnet tool install --global dotnet-ef --version "8.*"
```

### Database does not exist

Run:

```bash
dotnet ef database update --project MVC-Bartender-Application
```

### Project does not build

Run:

```bash
dotnet restore
dotnet build
```

Review any build errors before starting the application.

### Bootstrap styling does not appear

The application uses Bootstrap through a CDN, so an internet connection is required for Bootstrap styling to load.

## Quick Start

For someone who already has .NET 8 and Entity Framework installed:

```bash
git clone <repository-url>
cd MVC-Bartender-Application
dotnet restore
dotnet build
dotnet ef database update --project MVC-Bartender-Application
dotnet run --project MVC-Bartender-Application
```
