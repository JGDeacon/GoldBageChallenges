Title: Barbecue

Summary:
The Barbecue console application uses a List<> of Party items instead of a database as a backend to store data.
An Barbecue item is made up of an ID, Name, Cost, MenuID. Tickets are used to "buy" items.
This application builds on the Menu class of the Cafe project.


The UI options allow the user to:
App Party - Walks the user through adding a party. Error catching rebuilds the party in progess in the IU for the user.
View Parties - Displays a list of parties with a breakdown of how tickets were used to aquire food.
Set Prices - Allows the user to change the price of the 5 different items available for a ticket.


						
There are helper class in a class library that sets console colors, brands the app, input cleanup, and other quality of life items.
The Cafe project needs to be referenced for the Menu items.
All Inputs have the first letter capitolized in the helper method (hall = Hall).
Commas and white spaces are removed from text.
Every user interaction is enclosed in a loop that keeps the user at that prompt until a valid response is input.

Project Makeup:
Program.cs - Main
ProgramUI.cs - Called by the Program and allows for user interaction.
Party.cs - Defines the Party object.
PartyRepo.cs - Provides the interaction with the Party class.
ToolBox.cs - Helper class in the ChallengeTools project with QOL methods.
Menu.cs - By referencing the Cafe project.



Unit Tests reside in the BarbecueUnitTests Solution.
