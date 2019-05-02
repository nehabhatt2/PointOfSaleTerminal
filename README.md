# PointOfSaleTerminal
Problem
Implement a solution to the following problem.
You do not need to provide any form of persistence in this program. Your project should contain some way of running automated tests to prove it
works.
The program should be an API. You can opt to put a user interface on it or not, but we will only be looking at the API portion.
We are looking for clean, well-factored, OO code.
Requirements
Consider a grocery market where items have prices per unit but also volume prices. For example, doughnuts may be $1.25 each or 3 for $3
dollars. There could only be a single volume discount specified per product.
Implement a point-of-sale scanning API that accepts an arbitrary ordering of products (similar to what would happen when actually at a checkout
line) then returns the correct total price for an entire shopping cart based on the per unit prices or the volume prices as applicable.
Here are the products listed by code and the prices to use (there is no sales tax):
Product code Price
A $1.25 each or 3 for $3.00
B $4.25
C $1.00 or $5 for a six pack
D $0.75
Interface
The interface at the top level PointOfSaleTerminal service object should look something like this. You are free to design/implement the rest of the
code however you wish, including how you specify the prices in the system:
PointOfSaleTerminal terminal = new PointOfSaleTerminal();
terminal.SetPricing(...);
terminal.Scan("A");
terminal.Scan("C");
... etc.
decimal result = terminal.CalculateTotal();
Tests
Here are the minimal inputs you should use for your test cases. These test cases must be shown to work in your program:
Scan these items in this order: ABCDABA; Verify the total price is $13.25.
Scan these items in this order: CCCCCCC; Verify the total price is $6.00.
Scan these items in this order: ABCD; Verify the total price is $7.25
