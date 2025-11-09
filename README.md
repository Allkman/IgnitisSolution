# ⚡ IgnitisSolution

A .NET 9 Web API project for managing **Power Plants** data — designed with a clean architecture, Entity Framework Core, and Swagger for API testing.


---

## ⚙️ How to Run the Solution

Follow these steps to set up and run the project locally.

### 1. Clone the Repository
```bash
git clone https://github.com/Allkman/IgnitisSolution.git
cd IgnitisSolution
```

### 2. Update the Connection String
Open **`appsettings.Development.json`** and add your local SQL Server connection string.  
Make sure the key matches the one expected in **`StorageContextFactory.cs`**:

```json
{
  "ConnectionStrings": {
    "SQL_CONNECTION_STRING": "Server={Server Name};Database=IgnitisDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> 💡 The connection string is read directly from `appsettings.Development.json` via:
> ```csharp
> var connectionString = configuration.GetConnectionString("SQL_CONNECTION_STRING");
> ```

---

### 3. Initialize the Database
Run the following command in **Package Manager Console** (or terminal):

```bash
Update-Database
```

This will apply migrations and seed the initial data into your local database.

---

### 4. Launch the Application
Run the application using the **http** profile.  
Swagger UI will open automatically because `"launchBrowser": true` is configured in **launchSettings.json**.

You should see the API documentation at:

```
https://localhost:7218/swagger/index.html
```

---

### 5. Test the Endpoint
In Swagger, select GET endpoint and try calling by forming such queries:

```
https://localhost:7218/PowerPlants?Page=2&PageSize=2&Owner=ene
https://localhost:7218/PowerPlants?Page=2&PageSize=5
```
Select POST endpoint to test: 
All/Any required fields missing
Owner name validation
Power number 0-200 inclusive
Additionally: ValidTo date cannot be in the past if business is requesting non-archived power plants

```
https://localhost:7218/PowerPlants
```
### 6. Added xUnit tests to test validation of the DTO 

---

## 🧩 Tech Stack

- **.NET 9 Web API**
- **Entity Framework Core 9**
- **SQL Server (LocalDB)**
- **Swagger / Swashbuckle**
- **Dependency Injection** via `IServiceCollection`
- **Asynchronous programming** throughout

---



### © 2025 AllkmanSolutions
Maintained with ⚡ by the ADev development team. Yes that is me Algirdas as a developer. Cheers :)
