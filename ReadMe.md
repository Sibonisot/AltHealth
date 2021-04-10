### Welcome to Alt Health Application

### Libraries used
1. [Entity Framework 6.2.0](https://www.nuget.org/packages/EntityFramework) - Object Relational Mapper for database
2. [Doc X](https://www.nuget.org/packages/DocX/1.0.0.22) - Library for manipulating word document content
3. [DocX_doc](https://www.nuget.org/packages/DocX_Doc/1.0.0) - Library for manipulating word document content and converting to word to PDF.
4. [Microsoft.AspNet.WebFormsDependencyInjection.Unity](https://www.nuget.org/packages/Microsoft.AspNet.WebFormsDependencyInjection.Unity/) - Package for Dependency Injection in Webforms
#### Database part
* **Open the sql script to create the database**
  * The script is under AltHealth.Data > Db Scripts > Health script.sql. This script contains schema and data.
  * Run the script against your sql database

### Application Part

* This application is divided into 2 layers
	1. Data Layer
	     * This layer is responsible for all calls to the database.
		 * At any stage when you want to add an API you will just use the calls that are used on this layer for API calls.
	2. Presentation Later
	   * This is a front end later for user inputs.
	   * This layer references Data layer to read data from database.=
### Running the Application
* Once you have done the **Database Part** then you can start buidling the application.
* Build the whole solution
* Change ConnectionString on the following files(I have used data source = (local) so that it is generic to any computer. So to test if (local) will work on your computer try and connect to sql with server name (local) and Authentication: Windows Authentication. If you can't connect then use your normal server name usualy it is your computer name then update the following config files)
  * AltHealth.App > Web.config(line 34) - Rename data source with your computer name
  * AltHealth.Data > App.config(line 21) - Rename data source with your computer name - **This will only be used if you have created a new table or new stored procedure and you want to update the Entity Model. If you not going to do that then you don't need to change it because when the application runs it uses the Web.config on AltHealth.App.**
 

### MAKE SURE YOU SET AltHealth.App as a startup project

# RUN THE APPLICATION


# Useful link for invalid password when sending using gmail account

[Gmail Issuer](https://www.google.com/settings/security/lesssecureapps)