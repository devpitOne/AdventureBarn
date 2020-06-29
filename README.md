# AdventureBarn

Inspired by Microsoft's own AdventureWorks, this is a code-first EF 6 MVC application for tracking products and suppliers. It consists of 4 projects:
AdventureBarn.Contracts - The high level models
AdventureBarn.DataAccess - The database context and DAL repositories
AdventureBarn.Tests - A small unit tests project focused on testing controllers
AdventureBarn.WorkSite - The MVC solution that uses it all

#Database
As a code-first solution AdventureBarn carries its database with it. It is currently set to development configuration, meaning it will drop and recreate its database each time it changes. 
To aim it at an SQL instance, change the AdventureBarnContext connection string in the WorkSite Web.config

#CRUD functions
The WorkSite provides controllers based on a generic parent which allow for creation, retrieval, update and deletion of addresses, products and suppliers.

#Data Validation and Exception Handling
Data Validation is handled in-model, via property attributes in the Contracts project interacting with the MVC framework.
Exception Handling is covered in three layers. The web config provides custom error pages, the global asax captures and logs any general exceptions the generic controller and its children capture and log any MVC process errors.
Logging is handled via log4net. Currently it is set up to log to a local file.

#Tiers
The application functions in the following tiers:
-Data, at the database layer the repositories and dbContext handle database operations
-Presentation is handled through a traditional MVC View layer with multiple views allowing granular control of screens 
-Logic is handled in the traditional MVC Controller pattern
-Business Objects exist in Contracts available across multiple projects, though the MVC layer also has its own local models.
