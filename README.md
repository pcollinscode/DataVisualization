# Data Visualizer
This application tries to visualize the architecture of software projects and the changes that have occurred. It does this by trying to find components from the project documentation site and from UML of the code. The deployed code can be found at  "http://dataviz553.azurewebsites.net/". This currently runs on the Graylog project that can be found in Github (https://github.com/Graylog2/graylog2-server).

### DataVisualization project

##### Remote Execution
The project is set up to be published to Azure as a Web Application.
The publish settings are included in the root of the DataVisualization folder as "dataviz553.PublishSettings".
This will deploy the code to "http://dataviz553.azurewebsites.net/".

1. To deploy, open the Visual Studio solution file "DataVisualization.sln".
1. Then right-click on the project in the solution explorer.
1. Select publish.
    1. If using Visual Studio 2017, this will open a Publish window.
        1. Click "Publish" on the left side nav menu
        1. On the dropdown, select "dataviz553 - Web Deploy"
        1. Click the publish button (**NOTE**: If it asks for a password, you need to open the "dataviz553.PublishSettings" file and copy the userPWD)
    1. If using Visual Studio 2015, this will open a Publish dialog box. Follow the dialog steps using the "dataviz553 - Web Deploy" publish profile

##### Local Execution
To execute locally, you must install Visual Studio for easiest execution. Recommended version is Visual Studio 2017 Community but also should work on Visual Studio 2015 Community (**NOTE**: some code is untested).

1. Clone the Github project.
1. Open the DataVisualization.sln file in Visual Studio.
    1. To run in debug, go to Debug menu item and select start debugging (F5 for shortcut)
        1. This will open a browser with a localhost address running the code
    1. Can also right click on "index.html" and then "View in Browser". This will not start Visual Studio debugging.

### Website Scraper
Put in description of how to run the scraper here
