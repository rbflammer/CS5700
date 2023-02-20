This project was created in Visual Studio Community 2022.

To run the project, first run within Visual Studio.
Once the project is running and observers are set up, run the file hw2.win.intel (if on a Windows system).
The project will then start recieving data and update the observers accordingly.

Unit Tests are also run in Visual Studio.


The user interface for the project is fairly simple. Within the first form, the buttons labeled "..." 
are for browsing the computer for the correct input files. Each button corresponds to its adjacent text field.

The main form is used for creating and setting up observers. To create a particular observer, click the "Create"
button below the corresponding ListView. A form will then be shown where the name of the new observer can be entered.
Each observer must have a name, so if no name is entered or the create button is not clicked an observer will not 
be created.

To subscribe a racer (or multiple racers) to an observer, select the observer then the desired racers on the rightmost 
listview. Then, click the "<" button. The newly subscribed racers in will now appear in the middle ListView.

To unsubscribe from a racer (or multiple), select an observer then select all the desired racers in the middle listview.
Then click the ">" button. Those racers will be unsubscibed from, and moved to the rightmost ListView.