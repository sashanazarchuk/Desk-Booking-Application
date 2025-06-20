 # 🪑 Desk Booking Application

**Desk Booking Application** is a workspace reservation system built with **ASP.NET Core Web API** and **Angular 19**. It enables users to browse, book, and manage office spaces.

---

## 🚀 Features

- 📍 Browse available workspace types
- 🛋️ View workspace details: amenities, photos, and availability
- 📅 View current bookings and occupancy details per workspace
- 📝 Book a workspace with form validation
- 👤 Edit, or cancel your bookings from "My Bookings" page
- 🧠 AI Assistant which helps users interact with their bookings using natural language

---

## 🛠️ Technologies Used

### 🔙 Backend
- [.NET 9 (ASP.NET Core Web API)]
- [PostgreSQL 15+]
- Entity Framework Core
- Clean Architecture (Domain, Application, Infrastructure, API)
- AutoMapper
- FluentValidation
- CQRS


### 🔜 Frontend
- [Angular 19] 
- Angular Material
- Tailwind CSS
- RxJS  

---

## 📁 Project Structure

### Clean Architecture Layout
```plaintext
booking-server/
├── Domain/ 	# Core domain models and business logic
├── Application/ # CQRS handlers, DTOs, validators, mappings, interfaces
├── Infrastructure/ # Data access (EF Core, repositories), services, seeding
├── API/ # Web API controllers, middleware, DI

```
### Angular Frontend Layout
```plaintext
booking-client/src/app/
├── booking-form/   # Components for creating and editing bookings (TS, HTML)
├── bookings-history/components/ # Components for viewing booking history (TS, HTML)
├── core/utils/     # Utility functions (booking, date, workspace)
├── modal/    # Shared modal component (HTML)
├── workspace/components/   # Components for displaying and interacting with workspaces (TS, HTML)
```


## 📦 Getting Started

### 📌 Prerequisites

- [.NET 9 SDK] 
- [Node.js] 
- [PostgreSQL] 



### 🔧 Backend Setup

# Cloning the repository
git clone https://github.com/sashanazarchuk/Application.git

# Go to the backend folder
cd Application/booking-server/API

#Before running the backend, make sure to configure your PostgreSQL connection string in the appsettings.json file located in the booking-server/API folder:

```json
{
  "ConnectionStrings": {
  "sqlConnection": "Server=localhost;Port=5432;Database=YourDatabaseName;User Id=YourUserId;Password=YourPassword;"
  } 
}

```
# # Updating the database
```bash
dotnet ef database update
```
# Run API
```bash
dotnet run
```


### 🚀 Frontend Setup (Angular 19)

Navigate to the frontend folder

```bash
cd booking-client

#Install dependencies
npm install

#Run the Angular development server:
npm start

#Open your browser and go to:
http://localhost:4200

