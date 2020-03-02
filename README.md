# Full Stack Technical Test

This test requires that you use the provided application to build functionality inline with the instructions below. The initial structure of the application is based on ASP.NET Core [React project template](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-3.0&tabs=visual-studio), feel free do add any additional libraries you want to use. 

Please clone the project and create your own repository from it, do not branch from this project. Once you are ready, send a link to the repository you have created so that it can be reviewed.

## Prerequisites

This test requires a SQL Server database, if not already installed, a free version can be downloaded [here](https://www.microsoft.com/en-gb/sql-server/sql-server-editions-express).

## Test Steps

1. Apply entity framework migrations to scaffold database and apply seed data.
2. In the React app, create a table on the page showing a list of people and make a call back to the server to retrieve the data from the database created in the previous steps. The end result should look similar to the following example:
![List Image](ClientApp/public/list.png "Example list image")
4. Add functionality to the persons name so that when it's clicked the user gets a view of the data for that individual as shown below:
![Person Image](ClientApp/public/person.png "Example person image") 
5. Add the necessary functionality so that the information can be changed, saved back to the server and the database.
6. When a successful response has been saved the user should be returned to the original list and the list should be updated with the changes.
7. Finally, add an extra column to the list to show a count of the number of people with a matching skill for each row.

** Extra ** 
Use your skills to add any additional features / functionality you think would be useful in the app.


## Run People API to perform all server side operations
In order to run this react application you will have to run the people.api project simultaneously.
https://localhost:44355

## .Net libraries added
1. AutoMapper
2. MediatR
3. Swagger (For API testing)

## React libraries added
1. Semantic UI (For styling)
2. Jest and Enzyme (For UI unit testing)
3. Lodash (Utility functions for collections/arays)
4. Redux and Redux-Thunk (For maintaining app's state in store)

## Database connection string
Please update database connection string in appsettings.json inside people.api Web API project.

