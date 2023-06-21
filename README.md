# stockexchange-mobileapp
The project proposes an application compatible with both Windows and Android devices, about real-time international stock market indices. The data regarding the analyzed indicators were extracted from Yahoo Finance and imported through a JSON file. The application is divided into six pages, available through the menu located in the top left corner, as follows: Home Page, Financial Analysis, Statistical Analysis, Comparative Analysis, About the Application, and About the Stock Exchange.

# Implementation:
The implemented project contains a series of Content Pages, Classes, and Required Resources for functionality. Retrieving stock values was done through network access via HTTP connection and manipulation of an extracted JSON file, with the values being stored using SQLite. The created pages utilize image resources, various controls, both common ones (DatePicker, Entry, Switch, Slider, etc.) and list controls (Picker, ListView).

# Description of created classes:

    - Class "Bursa" - contains the definition of stock exchange objects used in the application.
    - Class "ValoriBursa" - contains the method used for importing data from Yahoo Finance. Here, the HTTP connection is created to access the page, and each object from the retrieved JSON is saved in a list of "Bursa" objects.
    - Class "BazaDateBursa" - contains a series of methods for data manipulation using SQLite. Here, the connection to the local database and the table that will store the "Bursa" objects are created. I have also implemented a series of appropriately named methods for operations within the database (adding "Bursa" objects, deleting records, retrieving records, etc.).
    - Class "Constants" - contains a list of company symbols used in the project. This class is used in the "ValoriBursa" class and attached to the link from which the information is retrieved to determine the companies included in the JSON file.
    - Class "Formular" - contains the definition of form objects used within the "About the Application" page.
    - Class "BazaDateFormular" - here, the connection to the local database, the table that will store the "Formular" objects, and a method that allows adding a response are created. This method is called when the "Submit" button is pressed.
    - Class "ChartView" - necessary for graphical representation of data (using the Microcharts and SkiaSharp packages).
    - Class "MauiProgram" - automatically created for any MAUI application, where I added the builder for the SkiaSharp package.