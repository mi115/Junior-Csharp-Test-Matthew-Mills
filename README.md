# Junior C# Test

## Task Definition

A basic solution is provided in this repository, with some core NuGet Packages already installed:

- MySQL.Data
- Dapper
- Xunit for unit tests

If you would prefer to use any alternative packages, please feel free to do so.

Structure your code as you wish. Use as many projects as you wish.

Some configuration is already provided, e.g. database connection string to the test database & database class to provide a MySqlConnection. This will instantiate a connection to a MySQL 8 cloud instance. This database will be running continuously. Note that the username / password provided only grants `SELECT` privileges. This should be sufficient to complete the exercise. Please study the database using a database client of your choice.

Using the database provided, create a desktop application which does the following:

### Browse Orders

1. Allow the user to fetch order details for an existing order number. It should be possible to select the order number from a list of existing numbers.

	- Display following details for a selected order number:
		- orders details (number, date, sale_price, deposit) 
		- customers details (number, forename, surname, phone)
		- branches details (name and postcode)


2. Think about how to handle any exceptions that might occur and how to provide error information to the user.


3. If you have time, add an optional filter to only display orders that were entered after a specific date.


### Unit tests

4. If you have time, please feel free to add some unit tests to cover your code. A basic test harness for unit testing is set up.


### Submit

When you have completed your task, please submit your code either as a ZIP archive or provide a link to your checked in source code in your personal Github repository or similar service.
