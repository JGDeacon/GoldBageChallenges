Title: Cafe

Summary:
The Cafe console application uses a List<> of Menu items instead of a database as a backend to store data.
A Menu item is made up of a MealNumber (ID), Name, Description, Price, and a list of Ingredients.


The UI options allow the user to 
Add Menu Item - Whish walks the user through prompts to collect the needed information to create a Menu item
Delete Menu Item - Which Will remove the Menu item fomr the List<> of Menu items
View Menu Items - Which presents the user a list of Menu items and details for each one

						
There are helper methods that sets console colors, brands the app, input cleanup, and other quality of life items.
All Inputs have the first letter capitolized in the helper method (hall = Hall)
Commas and white spaces are removed from text.
Every user interaction is enclosed in a loop that keeps the user at that prompt until a valid response is input.

Project Makeup:
Program.cs - Main
ProgramUI.cs - Called by the Program and allows for user interaction.
Menu.cs - Defines the Menu object
MenuRepo.cs - Provides the interaction with the Menu class
Ingredients.cs - Defines the Ingredient object(s) which are used for the Menu item.


Unit Tests reside in the CafeUnitTests Solution.
