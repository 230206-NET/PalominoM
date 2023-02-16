## Overview (Due 3/3 Friday)
On this foundations project, you will create a Expense Reimbursement System (ERS)
[Link to Trello](https://trello.com/invite/b/GFkH5p72/ATTI580e192fcd4fb040fb5f8dc293f7c63680F22465/ersp1)

### What is an Expense Reimbursement System?
It is a software designed to pay back employees for the purchases they made with their own money while they are working for a company. Common items include things like airfare, meals, and hotel while traveling for business purposes.

## User Stories
### MVP(Minimum Viable Product) Stories (Required)
- As a user, I should be able to log in to the system
- As a user, I should be able to create a new account in the system
- As an employee, I should be able to submit reimbursement tickets
- As a manager, I should be able to approve or reject submitted reimbursement tickets

### Stretch Goals (Optional)
- As an employee, I should be able to view my previous submitted tickets
- As an employee, I should be able to add reimbursement types to my tickets
- As a manager, I should be able to promote/demote an employee to a manager and vice versa
- As an employee, I should be able to upload and store images associated to their reimbursement tickets
- As a user, I should be able to see and edit my profile

## Other Requirements
- Unit Testing (only for your Models and Business Logic): At least 50% coverage
- Logging to a file using Serilog
- Git Repository on our Github organization 
- Your application must be connected to a SQL database

## Technologies
- C# (Core programming language)
- Azure hosted SQL Server (no locally hosted db)
- ADO.NET (to access and communicate with dbs)
- ASP.NET (to build APIs)
- Git (for source control)
- xUnit (for unit testing)
- Serilog (for logging)

## Phases
### Phase 1: Build a console application with a db attached to it (2/27 Monday)
### Phase 2: Refactor the console application to RESTful API
##### Bonus: Refactor your console app to act as a standalone frontend that sends http requests to your backend api
