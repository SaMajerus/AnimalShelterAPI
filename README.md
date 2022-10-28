# Pierre's Bakery -- Sweet & Savory Treats web application

#### By Sam Majerus

#### A web application that Pierre uses to manage his Menu of 'Sweet & Savory Treats' at his Bakery. 
<br>

## Technologies Used

* C# (C-sharp)
* .NET 5 
* Markdown
* ASP.NET Core
  * ASP.NET Core - MVC 
  * ASP.NET Core - Identity
  * ASP.NET Core - Swashbuckle (for Swagger UI) 
* MySQL
* SQL Database (DB) 
* Entity Framework Core  (also known as 'EF Core')
* EF Core - DB Migrations
* Razor
* ViewBag
<!-- * Layout files 
* CSHTML5  -->
* JSON
* Git Bash (Used in: Local Cmd-line Terminal, navigation of local directories)
* GitHub (Remote repositories)
* GitHub template repository (MSTest)
* OpenAPI - Swagger
<br><br>


## Description

The User is greeted with a Splash page. From here, the User can navigate to one of 4 places: a list of Treats, a list of Flavors, an Order form, or a 'Create Account or Log-In' page. Anonymous visitors have read permissions for the whole site. Only users with Accounts created have Create/Read/Update/Delete (CRUD) permissions.   
In the works:   an Admin account is the only one with full CRUD permissions.   Thus, normal user account for customers only has CRUD permissions for Orders they submit whilst Signed In.  Anonymous visitors have Read permissions for the site, as before. <br><br>


<!-- Resources I found to be helpful whilst developing this application-- 
* [Configuring a Primary Key - Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#configuring-a-primary-key)
* [Help with an 'Internal Server Error' that occurs when population of a SelectList dropdown element fails](https://stackoverflow.com/questions/26585495/there-is-no-viewdata-item-of-type-ienumerableselectlistitem-that-has-the-key) <br><br><br> -->


## Setup/Installation Requirements

* All that's required to run this application -- at minimum -- is: a decently-performing laptop, and a reliable Internet connection. (The latter is really only required for 'Cloning from GitHub' this time around, however.) 

* To Clone the program from the GitHub repo to your local machine:

  * 1.) Click the green button labelled 'Code'. Under the 'HTTPS' tab, there are 3 Options. This program will work best with Option 1, so move on to Step 2. <br> 

  * 2.) Copy the link. Then, in Git BASH, navigate to the folder you want to put the files in. This can be your Desktop directory, or a different subfolder, whatever you prefer. Next, still in the Git BASH console, type the following (with the copied-link in place of 'HTTPS') and hit ENTER: 'git clone HTTPS' Several lines of text will come up in the console -- that's the files being copied into whichever directory/folder you're in currently. Then, do the following once your prompt line reappears: While still in the console window, type 'pwd' and press ENTER. This will display your current file path. Copy that by highlighting it and pressing 'Ctrl-C', and then pasting it in an easily-accessible word processor like Notepad for reference. Next, open File Explorer, and navigate to through your files according to that File Path you just copy-pasted for reference. Once you've done this, move on to Step 3. <br>

  * 3.) To ensure that you can find this folder again in the Steps that follow, please do the following: right-click the containing folder (in which the newly-copied files are stored) and select the option that says 'Pin to Quick Access'.  Move on to Step 4. <br>

  * 4.) Open VS Code. Then, click on the page icon at the top of the left-hand toolbar. Then click 'Open Folder'. When the Windows File Explorer window appears, navigate to and select the containing folder you pinned in the previous step. Once you've selected the folder and clicked the button to open the folder in VS Code, move on to Step 5. <br>

  * 5.) Open a New Terminal (shortcut is Ctrl+Shift+`). Then, in the command line, navigate to the "SweetNSavory" subdirectory by typing  'cd SweetNSavory'  then pressing ENTER.   
  Next, type  'dotnet restore'  and press ENTER. This ensures that everything required to run the program is updated and ready to go.   (Your command prompt will show up again once the operation is complete; DO NOT kill the terminal or close VS Code.) <br>
  Once that's done, move on to the next Section.     (DO NOT Navigate to any other directories between now and then!!  Otherwise, the Program will not run.) <br>


* Setting up the 'appsettings.json' file 
Whilst viewing the 'SweetNSavory' directory  (~/SweetNSavory), enter the command 'code appsettings.json' into the terminal. Then, in the empty file that opens (and has the name 'appsettings.json'), copy/paste the following into it.  

<!-- {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=sam_majerus;uid=YOUR-SQL-USERNAME;pwd=YOUR-SQL-PASSWORD;"
  }
} -->

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=pierres_bky_sweets_n_savories;uid=YOUR-SQL-USERNAME;pwd=YOUR-SQL-PASSWORD;"
  }
}
```

Replace 'YOUR-SQL-USERNAME' and 'YOUR-SQL-PASSWORD' with your MySQL username and password, respectively, and then save the file by pressing 'Ctrl-S'. 
<br>


* Setting up the Database    
  A super convenient feature of EF Core is that in order to use a MySQL database, we don't have to import an SQL file to MySQL Workbench. 
  Instead--
    * While still viewing the 'SweetNSavory' directory, enter this command:  'dotnet ef database update'.  
  Once the resulting process is completed by EF Core, the database is set up and ready to go. 
<br>


* Running the Program 
  
  * In your GIT BASH command line, enter this command:  'dotnet run' .   The files will be compiled and then the application will be started. 
  In the terminal, once the last line of text reads    ''Ctrl-C to end the Application'',  go to your browser and enter the following address into the search bar:   'http://localhost:5000/swagger/index.html'.   Once done loading, the Swagger UI will appear.  

  The localhost server application will shut down once the user presses 'Ctrl-C' with the terminal selected.  To run the program again after a given session ends, simply reenter  'dotnet run'  as before.
<br><br>


* If you get an error, here are Troubleshooting steps to try (In Order): 
  * 9 times out of 10, an error message will appear if you try to run the program whilst being in the wrong directory location.  
  To make sure you're in the right place, do the following-- 
    * In your Git Bash command line, enter the command  'pwd'.  The Path leading to your current Folder (a.k.a. Directory) location will be printed out.   
    If the last 3 Directories in that Path DO NOT match the following snippet, then you're located in the wrong place. ('CONTAINER' represents your Containing Folder, which is what Contains the Program's Parent/Root folder):       ./CONTAINER/Bky_Sweets-n-Savories.Soln/SweetNSavory 

  * If you're in the Right Place:  try entering the command  'dotnet restore'.  Once its process is completed, try entering  'dotnet run' again. 

  * Still not working?  Save a copy of this document, then move the Program's folder to the Recycle bin and Delete it. Then, try installing it from GitHub again using the above steps. 

  * If it STILL won't work:  Please don't hesitate to reach out via Email.  In addition to uncropped screenshots of the issue (send them as Attachments), please also include your Contact Info (along which method is best for contacting you).   This allows me to better assist you with Troubleshooting.  
<br><br>

 
* Closing the Program 
  * A. Browser tab & VS Code 
    * Close the browser tab. 
    
    * In VS Code, press 'Ctrl-C' to end the Localhost server application.
    * Next, do  'File > Close Folder'  (or 'Ctrl-K F'). When that operation is complete, you may close VS Code. 

<br><br><br>



## Known Bugs
* N/A
<br>


## License

Email me at ladolego@gmail.com for questions, ideas, concerns, or even any issues that you run into. You may also clone or Fork the content in this Repo to fiddle around with it, if you like.

Licensed through MIT. Copyright (c) 10/28/2022, Samuel Majerus.  