Title: CompanyOutings

Summary:
The CompanyOutings console application uses a List<> of Event items instead of a database as a backend to store data.
An Event item is made up of an EventType enum, Attendance, EventDate, CostPP (Cost Per Person), EventCost.


The UI options allow the user to:
Add an Outing - Presents a workflow to create a new Outing.
List all Outings - Presents the contents of the List<>.
View Reports - Presents a Reports workflow where the user is able to filter the List<> by any attribute, then filter by any attribute either ascending or descending. 
			   Total Events and Cost are displayed with each report. (I'm pretty proud of this piece).

						
There are helper class in a class library that sets console colors, brands the app, input cleanup, and other quality of life items.
All Inputs have the first letter capitolized in the helper method (hall = Hall).
Commas and white spaces are removed from text.
Every user interaction is enclosed in a loop that keeps the user at that prompt until a valid response is input.

Project Makeup:
Program.cs - Main
ProgramUI.cs - Called by the Program and allows for user interaction.
Event.cs - Defines the Event object.
EventRepo.cs - Provides the interaction with the Event class.
Reports.cs - Provides all the List<> manipulation to generate reports for the user.
ToolBox.cs - Helper class in the ChallengeTools project with QOL methods.



Unit Tests reside in the CompanyOutingsUnitTests Solution.

Note: I approached the UI interaction much differently just to try a different approach. I think that the numeric menus are the way to go.