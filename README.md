# Build a TodoList with ASP.NET Core API

## TodoList Api Addresses
[ASP.NET Core API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio) is an open-source, cross-platform web API framework developed by Microsoft. It is built on top of the .NET Core runtime and can run on various platforms such as Windows, macOS, and Linux.
<br>
You can import the MSSQL database: `TodoApp.bacpac`
<br>

The project runs on "[localhost:?/swagger/index.html](https://localhost:7002/swagger/index.html)".
```
    info: Microsoft.Hosting.Lifetime[14]
        Now listening on: https://localhost:7002
```

## Used Packages

- Some packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the `Tools > NuGet Package Manager > Package Manager Console`.

- [Microsoft.EntityFrameworkCore.SqlServer 7.0.8](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.8)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 7.0.8
```
- [Microsoft.EntityFrameworkCore.Design	7.0.8](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/7.0.8)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.Design -Version 7.0.8
```
- [Microsoft.EntityFrameworkCore.Tools 7.0.8](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/7.0.8)
```
    PM>  NuGet\Install-Package Microsoft.EntityFrameworkCore.Tools -Version 7.0.8
```

The `Add-Migration` command is used to create or apply changes to database tables using the Code First approach supported by Entity Framework Core. This command detects the changes made in your model and saves them as a migration. Migrations allow you to evolve your application's database over time.
Write the following command to the `Tools > NuGet Package Manager > Package Manager Console`.
```
    PM>  Add-Migration InitCreate
``` 
We write our other command to update the database.
```
    PM>  Update-Database
```

---- 

If an error like the following occurs:
```
    ClientConnectionId:c0c7f465-92a0-4810-80cd-0e7250f876ef
    Error Number:-2146893019,State:0,Class:20
    A connection was successfully established with the server, but then an error occurred during the login process. 
    (provider: SSL Provider, error: 0 - Sertifika zinciri güvenilmeyen bir yetkili tarafından verildi.)
```
Try adding `TrustServerCertificate=True;` to your connection string in `Todos\appsettings.json`. [[source]](https://learn.microsoft.com/en-us/answers/questions/663116/a-connection-was-successfully-established-with-the)
```json
"ConnectionStrings": {
    "DefaultConnection": "Data Source=DESKTOP-R6K64T9\\SQLEXPRESS;Initial Catalog=TodoApp;Integrated Security=True;TrustServerCertificate=True;"
  },
```

----
## TodoList API Test [Images](https://github.com/AtakanTurgut/TodoList_ASP.NETCoreAPI/tree/main/pictures)

### 1. Create Todo:  POST | https://localhost:7002/api/todos
![](/pictures/createTodo.PNG) 

### 2. Get All Todos:  GET | https://localhost:7002/api/todos
![](/pictures/getAllTodos.PNG)

### 3. Get By Id:  GET | https://localhost:7002/api/todos/{{Id}}
![](/pictures/getById.PNG)

### 4. Update Todo:  PUT | https://localhost:7002/api/todos/{{Id}}
![](/pictures/updateTodo.PNG)

### 5. Delete Todo:  DELETE | https://localhost:7002/api/todos/{{Id}}
![](/pictures/deleteTodo.PNG)
