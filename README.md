# Data Visualizer
This application tries to visualize the architecture of software projects and the changes that have occurred. It does this by trying to find components from the project documentation site and from UML of the code. The deployed code can be found at  "http://dataviz553.azurewebsites.net/". This currently runs on the Graylog project that can be found in Github (https://github.com/Graylog2/graylog2-server).

## User Guide
Currently, there is no location on the client side to select the project to visualize. This is planned for in future work. The user will input a Github repository name and a documentation website.

To use the current version, there are instructions on the website for how the visualization works. The dependency group allows you to click on any circle and it will zoom in to see the classes that belong to the component. While zoomed, click on any other circle to move to that circles classes. To zoom out, click on the same circle again or outside of any circle to see all components.

The dependency wheel shows the components and their connections to other components. To visualize a specific component and its connections, hover the cursor over the bar next to the component name (see red box in figure below).

![Dependency Wheel](/images/DependencyWheel.png)

## Minimum system requirements
Requirements for modifying and executing the code.

1. Modifying Code - Requirements to modify source code.
        1. Any C# editor (**Recommendation**: Visual Studio 2017 Community Edition or higher).
1. Executing Code.
        1. Visual Studio - allows code to run locally and in debug mode because it installs IIS Express.
        1. Without Visual Studio, Will need to install IIS locally and set up a local web server to run code.
                
## Errors
There are two different error location and types. Either from the client as Javascript errors or the server side as C# exceptions. Exceptions on the server side are not swallowed so they will appear as HTTP error codes. Any errors can be reported in this repository as issues.

### DataVisualization project

##### Remote Environment
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

##### Local Environment
To execute locally, you must install Visual Studio for easiest execution. Recommended version is Visual Studio 2017 Community but also should work on Visual Studio 2015 Community (**NOTE**: some code is untested in VS2015).

1. Clone the Github project.
1. Open the DataVisualization.sln file in Visual Studio.
    1. To run in debug, go to Debug menu item and select start debugging (F5 for shortcut)
        1. This will open a browser with a localhost address running the code
    1. Can also right click on "index.html" and then "View in Browser". This will not start Visual Studio debugging.

### WebScraper
The semantic parser component, the WebScraper, is currently implemented as a java class. It has been compiled into an executable jar file that can be launched from the command console on any system with a recent version of the java runtime environment installed.

To run the standalone component example, open a console window in the folder containing the executable jar file and type:

WebScraper&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;By default, parses Graylog v2.2 documentation

WebScraper hostname&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Parses documentation at the website: hostname

**Note**: This prototype component has been configured heavily to work with the page structure of the Graylog website. Further work will be needed to make it compatible with a larger collection of websites.

