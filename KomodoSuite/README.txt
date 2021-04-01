Title: KomodoSuite

Summary:
Console App that turns the Badges. Barbecue, Cafe, Claims, and CompanyOutings projects into a "suite"


The UI options allow the user to:
Pick which console app they want to run.
	Badges
	Barbecue
	Cafe
	Claims
	CompanyOutings



Project Makeup:
Program.cs - Main
ProgramUI.cs - Called by the Program and allows for user interaction.
ToolBox.cs - Helper class in the ChallengeTools project with QOL methods.
Badges Project
Barbecue Project
Cafe Project
Claims Project
CompanyOutings Project


Note: With Seed Data populating the console apps for testing, each time a console application is run the Seed Data will also run adding more items to the test data.
	For example you enter the Badge console app, exit, and reenter the badge console app you will see duplicate seed data. This is expected while testing.
	The production applications will not have Seed Data.

