Title: Claims

Summary:
The Claims console application uses a List<> of InsClaim items instead of a database as a backend to store data.
A InsClaim item is made up of an ID, ClaimType enum, Description, ClaimAmount, DateOfIncident, DateOfClaim, IsValid, IsClaimOpen, ClaimCreationDate.


The UI options allow the user to 
See All Claims - Presents all the InsClaims in the List<>.
See All Open Claims - Presents a filtered list of InsClaiims based on the bool IsClaimOpen.
Work Next Open Claim - Retreives the InsClaim with the lowest ID and the bool IsClaimOpen = true. The user is allowed to edit the claim and mark it as "Closed" (IsClaimOpen=false)
Create New Claim - Presents the user a workflow to create a new claim. The user is not able to set IsValid, IsClaimOpen, or ClaimCreationDate.

						
There are helper class that sets console colors, brands the app, input cleanup, and other quality of life items.
All Inputs have the first letter capitolized in the helper method (hall = Hall)
Commas and white spaces are removed from text.
Every user interaction is enclosed in a loop that keeps the user at that prompt until a valid response is input.

Project Makeup:
Program.cs - Main
ProgramUI.cs - Called by the Program and allows for user interaction.
InsClaim.cs - Defines the InsClaim object
InsClaimRepo.cs - Provides the interaction with the InsClaim class
ClaimTools.cs - Helper class with QOL methods.



Unit Tests reside in the ClaimsUnitTests Solution.
