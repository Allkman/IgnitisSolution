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
(https://localhost:7218/swagger/index.html)
```

---

### 5. Test the Endpoint
In Swagger, select endpoint and try calling by adding any date:

```
date=2025-01-01
```

- The `date` parameter is **required**.
- Try different dates to filter Power Plants based on the `ValidFrom` field.

> ⚠️ **Note:** Using tomorrow’s date (future dates) will return an **empty array** — as no Power Plants are valid beyond the current time.
>  
> A future enhancement could include **user-friendly warnings** when an invalid or future date is provided.

---

## 🚀 Future Improvements

Here are a few ideas for expanding the project:

- Add validation or warning messages for invalid dates (e.g., tomorrow’s date).  
- Implement filtering by `Owner` or `Power` ranges.  
- Include pagination and sorting for large datasets.  
- Extend API for data insertion and modification.  
- Add logging and structured monitoring (e.g., Serilog, Application Insights).
- Would also make sense to include Unit test with Moq object, to test PowerPlantService.cs

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
