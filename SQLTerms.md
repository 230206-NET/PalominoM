###Relational database
A relational database is a collection of data items with pre-defined relationships between them. 
###SQL
##SQL Sublanguages:
#DDL
   Data Definition Language, DDL commands are used to change and modify the structure of the table.
#DML
  Data Manipulation Language. DML commands are used to manage and modify the database.
##DQL
  Data Query Language. DQL is used to fetch data from the database.
#DCL
  Data Control Language. DCL commands mainly deals with rights, permissions, and other controls of the database. 
#TCL
  Transaction Control Language. Mainly these TCL commands deal with the transactions in a database.  
  TCL commands are only used with DML commands like INSERT, UPDATE, and DELETE  because these commands are not automatically committed in a database.
#Primary Key
  -  It's a unique identifier. A column in a relational database table that's distinctive for each record. It can only have one.
#Foreign Key
  - A column or combination of columns that is used to establish and enforce a link between the data in two tables to control the 
    data that can be stored in the foreign key table.
#Candidate Key
  - A specific type of field in a relational database that can identify each unique record independently of any other data.
#Composite Key
  - A composite key in SQL can be defined as a combination of multiple columns, and these columns are used to identify all the rows that are involved uniquely. 
    Even though a single column can’t identify any row uniquely, a combination of over one column can uniquely identify any record. 
##tell me about normalization
  - Normalization is the process of organizing the data in the database
  - It makes table easier to understand, easier to enhance and extend, and protecs them from: insertion anomalies, update anomalies, deletion anomalies.
#1nf
  - Using row order to convey information is not permitted
  - Mixing data types withing the same column is not permitted 
  - Having a table without a primary key is not permitted 
  - Repeating groups are not permited 
#2nf
  - Each non-key attribute must depend on the primary key.
#3nf
  - Every non-key attribute in a table should depend on the key, the whole key, and nothing but the key. 
#Referential Integrity
  - relationship between tables. Like how a tables relate to each other through foreign keys. Making sure it is a valid key.  
##Which keyword do I use to...
#Create new table
    CREATE TABLE
#create a new record in a table
    INSERT INTO table() VALUES ();
#modify table structure
    ALTER table table_name ADD column_name COLUMN definition;
    ALTER table table_name MODIFY(column_definition);
#delete table
    DROP TABLE
#modify existing row in a table
    UPDATE table_name SET [column 1= value 1 , column n=value n] WHERE condition;
#delete a row
    DELETE FROM table_name WHERE condition
    TRUNCATE table table_name;
#drop all rows in a table w/o deleting the table
   DELETE FROM table_name
#What are some SQL dialects/vendors we have?
  Transact, PL/SQL(Oracle), PL/pgSQL , MySQL, SQLite
#which one do we use?
  - 
#What are constraints?
  - Used to specify rules for the data in a table. Constraints are used to limit the type of data that can go into a table. 
  This ensures the accuracy and reliability of the data in the table.
#Give me some examples and what they do
  -
#Tell me about some common SQL data types (https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-types-transact-sql?view=sql-server-ver16)
  - Exact numerics
  - Unicode character strings
  - Approximate numerics
  - Binary strings
  - Date and time
  - Other data types
  - Character strings
#What is ADO.NET?
  - ADO.NET is the data access component for the .NET Framework.
  - Provides consistent access to data sources such as SQL Server and XML, and to data sources exposed through OLE DB and ODBC.
#How do I connect to DB on ado.net?
  - get connectionstring from Azure portal. You can connect from the portal directly by updating password or by doing Server login in 
  DB and inputing username and password. 
#how do I execute a command on ado.net?
  - Create SQLcommand object
  - ExecuteNonQuery( ) , ExecuteReader( ) , and ExecuteScalar( ).  You choose one of these methods, depending on the type of command you are executing. 
  - For example, ExecuteReader( ) returns a DataReader and provides read-only access to query results. 
#how do I write a query to avoid sql injection?
  - @id, put paremeters
#what's the difference between executereader, executenonquery, executescalar?
  - ExecuteReader( ) returns a DataReader and provides read-only access to query results
#what is connectionstring
  - A string that specifies information about a data source and the means of connecting to it.
#tell me about multiplicity and some examples
#tell me about identity keyword
  - An identity column is a numeric column in a table that is automatically populated with an integer value each time a row is inserted. 
