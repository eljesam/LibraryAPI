# Library Management API

# Overview
This projects is a backend **Library Management System** bult using **ASP.NET Core Web API** and **Clean Architecture** principles.
It provides functionality for managing books, users and loans. With secure authentication using **JWT**.

# Architecture

### 1.API Layer (LibraryAPI.API)
-Exposes RESTful endpoints
-Handles HTTP requests and reponses
-Cotains Controllers and midleware configurations
-Implements JWT authentication

### 2. Applcation Layer (LibraryAPI.Application)
-Contains Interfaces and contracts
-Defines repository abstractions

### 3.Domain Layer (LibraryAPI.Domain)
-Core Business Entities:
 - User
 - Book
 - Loan
-Defines relationships and domain models
-No external dependencies

### 4.Infrastructure Layer (LibraryAPI.Infrastructure)
-Implements repository iinterfaces
-Uses Entity Framework Core
-Handles database access

## Technologies Used
- ASP.NET
- Entity Framework Core
- SQLite
- JWT
- Swagger
- NUnit

## Features

### Books
- CRUD Functions
- Track total and available copies
  
### Users
- Register and retrieve users
- Used for auth and loan management

### Loans
- Borrow books
- Return books
- Automatically updates availability

### Authentication
- JWT based auth
- Secure end points
- Stateless token-based security

## Business Logic

- Abook cannot be borrowed if no copies are available
- Borrowing a book decreases available copies
- Returning a book increases them
- Loans track borrow and return time stamps

##Relationship

1 user => borrows => Many books
1 book => can be borrowed => many users
many users => have => Loans

# Known issues
- Localhost port not connecting
- Assert IsNotNull, returns error\
- Full functionality not tested due to connection not being established.




