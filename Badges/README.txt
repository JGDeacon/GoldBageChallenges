Title: Badges Project

Summary:
The Badges console app uses a dictionary instead of a database as a backend to store data.
The Badge is comprised of an int key that identifies the badge and a string that lists door access.
The UI options allow the user to 
Add a Badge - adds a new badge to the dictionary
Update a Badge - changes the string values for a badge
Clear Badge Access - clear the string values
List All Badges - presents a list of badge ID's and string values
Search Badges By Door - Lets the user pass in a string that is used to search all the dictionary values
						and returns a list of matches.
						
There is a helper class that sets console colors, brands the app, input cleanup, and other quality of life items.
All Inputs have the first letter capitolized in the helper method (hall = Hall)
Commas and white spaces are removed from text inputs.
Every user interaction is enclosed in a loop that keeps the user at that prompt until a valid response is input.

Project Makeup:
Program.cs - Main
ProgramUI.cs - Called by the Program and allows for user interaction.
Badge.cs - Defines the badge object
BadgeRepo.cs - Provides the interaction with the Badge class
BadgeTool.cs - Contains the QOL methods for the ProgramUI class

Unit Tests reside in the BadgesUnitTests Solution.
