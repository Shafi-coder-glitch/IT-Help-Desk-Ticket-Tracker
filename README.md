# IT Help Desk Ticket Tracker

## Project Overview

IT Help Desk Ticket Tracker is a C# ASP.NET Core Razor Pages application that helps employees submit IT support tickets and allows IT staff to manage them.

Employees can search for their submitted tickets by name. IT staff can view all tickets, update ticket status, edit ticket information, and delete tickets.

The application uses SQLite and Entity Framework Core to store and manage ticket information.

## Features

- Submit support tickets
- View all support tickets
- Search tickets by employee name
- Update ticket status (Open, In Progress, Closed)
- Edit ticket information
- Delete tickets
- View ticket summary

## Technologies Used

- C#
- ASP.NET Core Razor Pages
- .NET 10
- SQLite
- Entity Framework Core

## Setup Instructions

1. Install the .NET 10 SDK and Entity Framework Core CLI tools.
2. Download or clone this GitHub repository.
3. Open the HelpDeskWebNew project folder.
4. Open a terminal in the project folder.
5. Restore dependencies:

   `dotnet restore`

6. Create the database:

   `dotnet ef database update`

7. Start the application:

   `dotnet run`

8. Open the localhost URL displayed in the terminal.

## Database

The application uses a SQLite database named helpdesk.db.

The Tickets table stores the ticket ID, employee name, problem description, submission date, and status.
