# UserManagementAPI (ASP.NET Core Web API)

A simple **User Management API** built with **ASP.NET Core Web API (C#)** for a college assignment.  
It demonstrates:

- CRUD operations (Create, Read, Update, Delete)
- Model validation using **Data Annotations**
- A **service layer** with **dependency injection**
- Custom **logging middleware**
- An in-memory list as a database substitute

---

## How to run

### Prerequisites
- .NET SDK 8.0+

### Run the API

```bash
cd UserManagementAPI
dotnet run
```

The API will start and listen on the URLs shown in the console output.

---

## API endpoints

All endpoints are under `/api/users`.

- **GET** `/api/users`  
  Returns all users.

- **GET** `/api/users/{id}`  
  Returns a single user by id.  
  - `404 Not Found` if the user doesn’t exist.

- **POST** `/api/users`  
  Creates a new user.  
  - Returns `201 Created` with the created user.
  - Returns `400 Bad Request` if validation fails.

  Example JSON body:

```json
{
  "name": "Charlie Patel",
  "email": "charlie@example.com",
  "age": 21
}
```

- **PUT** `/api/users/{id}`  
  Updates an existing user (by id).  
  - Returns `204 No Content` if updated.
  - Returns `404 Not Found` if the user doesn’t exist.
  - Returns `400 Bad Request` if validation fails.

- **DELETE** `/api/users/{id}`  
  Deletes a user (by id).  
  - Returns `204 No Content` if deleted.
  - Returns `404 Not Found` if the user doesn’t exist.

---

## Validation (Data Annotations)

The `User` model uses Data Annotations:

- `Name` is **required**
- `Email` is **required** and must be a **valid email format**
- `Age` must be within **1 to 120**

If invalid input is sent to `POST` or `PUT`, ASP.NET Core returns a **400 Bad Request** with details in the response body.

---

## Middleware logging

The custom middleware (`Middleware/LoggingMiddleware.cs`) logs:

- Request method (GET/POST/PUT/DELETE)
- Request path (e.g., `/api/users/1`)
- Response status code (e.g., `200`, `201`, `204`, `400`, `404`)

This appears in the console output while the API runs.

---

## Project structure

```
UserManagementAPI
│
├── Controllers
│   └── UsersController.cs
│
├── Models
│   └── User.cs
│
├── Middleware
│   └── LoggingMiddleware.cs
│
├── Services
│   ├── IUserService.cs
│   └── UserService.cs
│
├── Program.cs
├── appsettings.json
├── README.md
└── UserManagementAPI.csproj
```

