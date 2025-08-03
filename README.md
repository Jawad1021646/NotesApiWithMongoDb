# Notes API with MongoDB

## 📌 What the Project Does

This is a simple **CRUD (Create, Read, Update, Delete)** API for managing notes, built using **ASP.NET Core Minimal APIs** and connected to **MongoDB** for storing data.

The API allows you to:
- Get all notes
- Get a note by ID
- Add a new note
- Update an existing note
- Delete a note

## ⚙️ How to Install and Run

### Requirements:
- Visual Studio 2022
- .NET 6 SDK or higher
- MongoDB installed and running locally (default connection: `mongodb://localhost:27017`)

### Steps:
1. Clone or download this repository
2. Open the solution in **Visual Studio 2022**
3. Update MongoDB connection string in `Program.cs` if needed
4. Press **F5** to run the project
5. Use Swagger UI to test endpoints: `https://localhost:xxxx/swagger`  
   (Replace `xxxx` with your local port)

## 🚀 API Endpoints

| Method | Route         | Description           |
|--------|---------------|-----------------------|
| GET    | /notes        | Get all notes         |
| GET    | /notes/{id}   | Get note by ID        |
| POST   | /notes        | Create a new note     |
| PUT    | /notes/{id}   | Update a note         |
| DELETE | /notes/{id}   | Delete a note         |

---

Made by [Your Name]
