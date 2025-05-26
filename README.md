# Task Management App
#Frontend


## Description


A simple task management application built with ReactJS. It allows users to add, delete, mark as complete, and filter tasks.


## Features


- Add new tasks with a title, description, and due date.
![image](https://github.com/user-attachments/assets/7ff57db6-9414-49c0-b1e9-9c36b9b766be)

- pie chart and bar chart.
- Mark tasks as completed.
- Delete tasks.
- Filter tasks by All, Completed, or Pending.
- Persists tasks using local storage.

![image](https://github.com/user-attachments/assets/8a6ca96e-006f-4df4-9542-a7d0b499eb1a)




## Technologies Used


- ReactJS
- Bootstrap
- useReducer (for state management)

#Backend

## NET 8 Web API project

- Created a new ASP .NET Core 8 project (TaskManagementApi)

- Configured HTTPS redirection and minimal hosting model

## Entity Framework Core + SQL Server

- Integrated EF Core with a LocalDB connection string in appsettings.json

- Defined ApplicationDbContext and registered it via AddDbContext

## TaskItem data model

- Created Models/TaskItem.cs with properties:

- Title (string)

- Description (string)

- Completed 

- FromDate & ToDate as DateOnly (mapped to SQL date)

- Dropped the original Priority property

  
![image](https://github.com/user-attachments/assets/50c9de68-12cb-429c-873a-e23ba1453694)


## Database migrations

- Scaffolded and applied an initial migration (InitialCreate)

- Added a second migration to drop Priority and convert dates to date

- Used dotnet ef database update to sync schema

## CRUD API endpoints

- Implemented Controllers/TasksController.cs with:

- GET /api/tasks → returns all tasks

- GET /api/tasks/{id} → returns single task

- POST /api/tasks → create new task

- PUT /api/tasks/{id} → update existing task

- DELETE /api/tasks/{id} → remove task

## CORS 

- Configured a CORS policy to allow http://localhost:3000 (React dev server)




