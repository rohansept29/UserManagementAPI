# User Profile Management API


## Table of Contents


1. [Introduction](#introduction)
2. [Architecture](#architecture)
3. [Design Decisions](#design-decisions)
4. [Features](#features)
5. [Setup Instructions](#setup-instructions)
6. [Running the Application](#running-the-application)
7. [API Endpoints](#api-endpoints)
8. [Conclusion](#conclusion)


## 1. Introduction


This document provides an overview of the User Profile Management, built using .NET 6 and Angular 13, which allows users to edit and update their profiles securely. 
The API includes endpoints for user authentication and profile management, ensuring that user data is handled efficiently and securely.


## 2. Architecture


The application follows repository pattern, separating concerns to enhance maintainability and scalability. The unit of work serves as a container for all the repositories i.e. UserRepository
and AccountRepository. The repositories consists of all the methods to login, register, fetch and update user profile from the database using DbContext. The repository methods are further 
utilised in the action methods in the controller.




## 3. Design Decisions


- **Technology Stack**: The application is built on Angular 13 .NET 6, which offers improved performance and simplified development along with improved dependency injection.
- **Authentication**: The application uses JWT (JSON Web Tokens) for secure authentication, allowing users to access profile management endpoints securely.
- **Data Transfer Objects (DTOs)**: DTOs are used to transfer data between the API and the client while preventing overposting and ensuring that only relevant data is sent and received.
- **AutoMapper**: AutoMapper is used to simplify object mapping between the DTOs and entity models, reducing boilerplate code and enhancing maintainability.
- **Error Handling**: Global error handling is implemented to provide clear and consistent responses to clients.


## 4. Features


- **User Authentication**: Secure JWT-based authentication for users after login.
- **Profile Editing**: Allows users to update their profiles, including fields like username and/or password. Since email is stored in the JWT and it is being used to make the db calls, it is uneditable.
- **Input Validation**: Validates user inputs to ensure data integrity and security.


## 5. Setup Instructions


### Prerequisites


- .NET 6 SDK
- Angular 13
- Visual Studio 2022 or another compatible IDE
- SQL Server or any other database server of your choice


Database Setup
Create a database in SQL Server (or your preferred database system)
Update the connection string in appsettings.json:


"ConnectionStrings": { "DatabaseConnection": "User Id=postgres;Password=Postie123!;Server=localhost;Port=5432;Database=UserManagement;Include Error Detail=true;" }


Apply migrations to set up the database schema:


dotnet ef database update


6. Running the Application
Run the API

The API will start on https://localhost:7139;http://localhost:5015 by default.

Also, update the api endpoints in the frontend application

7. API Endpoints
HTTP    Method Endpoint                    Description
POST    {baseurl}/api/account/login        Authenticate user and return JWT token
POST    {baseurl}/api/account/register     Registers the user in the database
GET     {baseurl}/api/users/profile        Fetches the user profile
PUT     {baseurl}/api/users/profile        Updates the user profile

8. Conclusion
This documentation provides a comprehensive overview of the User Profile Management API, detailing its architecture, design decisions, and how to set it up locally. By following the instructions provided, users can easily run the application and test its functionality.


If you need further assistance or adjustments, let me know!