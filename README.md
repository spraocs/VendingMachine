# VendingMachine

**Problem Description:**

Virtual Vending Machine

Create a virtual vendening machine.

The vending machine contains a list of products, with a corresponding amount and quantity available.
Users put in (virtual) money and purchase an item.
After they have purchased an item, they can use the remaining money to purchase another item or have the change returned to them.
Once they are done, they should see a list of the items they have purchased.
Some basic business rules:

Users cannot purchase a product if there is no quantity remaining
Users can only purchase a product if they have put in funds equal to or greater than the cost of the product
Users should receive the correct change back after the transaction
The product quantity should be reduced by the amount of quantity purchased of an item.

# Description of the solution provided:

The application consists of the models - VendingMachineDto, ItemTypeDto, ItemDto. VendingMachineDto is the main model that represents the Vending machine and its operations. 
It is created as a singleton. 

I started off with the basic and simple representation of items and vending machine. The ItemType was later added. It is the item type that the user selects. 
when the user selects an item, the item at the beginning is removed, representing how the item is moved inside the Vending Machine and stock levels etc. 
Moreover, new item types can be added and removed as needed. 

Additionally, messaging can be included when the items are out of stock. An email can be sent to the admin to allow them restock items as needed. 
Messaging can be included in the application to alert the admin if any other issues occur.  

I could not add the Entity framework and presistence to database because of the time constraint. An admin screen can also be added to allow the items to be added to the Machine when items are out of stock.
A transaction table can be added to track the purchases that can provide reports of daily purchase totals. 

# Technical Track:

.NET Core C# is used for the creating the API. I have chosen to go with the Back-end track that default included API Docs. The reason for this is I think that backend is track is what determines the strength of an application in the long-run. 
The back-end track provides the scope to think in terms of performance, scalability and the feature rich implementation of the solution that enables the application to be used in a wide variety of situations.
For example, I have used the capacity limits for the items and item types. These can vary for different vending machines. 

Currently the application performs the basic operations needed. when the above modifications are completed, the API can be used by a wide variety of Vending machines.


