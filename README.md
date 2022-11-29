# refactor-this
The attached project is a poorly written API in C#.

Please evaluate this project and refactor it to bring it up to standard with what a modern day API codebase would look like. 

When you make changes, please enter a description of these changes along with their justification in the "Here's What I Fixed/Refactored/Added" section of the  "RefactorThis - CandidateNotes" text file. 

We hope that you will take this opportunity to showcase the best of your programming ability, however, we recognise that your time is precious, so you do not have to implement everything you can think of. Please timebox the actual implementation to as many hours as you see fit (atleast a couple of hours) and list the changes that you would have implemented, given more time, in the  "Further Improvements I Would Make If I Had More Time" section of the "RefactorThis - CandidateNotes" text file. 

If there are parts that need to change but you don't quite know how to, or you think should be handled elsewhere, 
please note these and anything else that you'd like to discuss in the "Here's what I would like to talk about at the interview:" section of the "RefactorThis - CandidateNotes" text file.

Please consider all aspects of good software engineering when implementing your solution.

## Restrictions
* The project must remain in C# .NET Core.
* The project must continue to use a Kestrel webserver.
* You can only add new libraries/packages through Nuget.
* The database must remain a SQLite database with its current setup. You are encouraged to modify the schema with justification.

## Tips
* Just because an algorithm, method or pattern is used in this project, doesn't make it correct. Some things should be removed or changed. Tell us what they are.
* You may need to rewrite sections of this project to do an excellent job on this task. Feel free to be as bold as you like when working on this task.
* Make sure to follow C# conventions. If your personal coding style of C# differs from the standard Allman style, feel free to use it as long as you are consistent and the code is readable.
* When you identify a particular issue in multiple parts of the codebase, to save time, implement the fix for a single instance and make a note of the rest of the instances and their fixes in the "Further Improvements I Would Make If I Had More Time" section of the "RefactorThis - CandidateNotes" text file.    

## Assessment
Some of the areas you may be assessed on are:

* Code Style and Maintainability
* RESTful Architecture
* Application Correctness
* Ability to spot problems and bugs
* Exception and Error Handling
* General Database Operations
* Modern Software Engineering best practices, principles, processes.

## Getting started for applicants

There should be these endpoints:

1. `GET /products` - gets all products.
2. `GET /products?name={name}` - finds all products matching the specified name.
3. `GET /products/{id}` - gets the product that matches the specified ID - ID is a GUID.
4. `POST /products` - creates a new product.
5. `PUT /products/{id}` - updates a product.
6. `DELETE /products/{id}` - deletes a product and its options.
7. `GET /products/{id}/options` - finds all options for a specified product.
8. `GET /products/{id}/options/{optionId}` - finds the specified product option for the specified product.
9. `POST /products/{id}/options` - adds a new product option to the specified product.
10. `PUT /products/{id}/options/{optionId}` - updates the specified product option.
11. `DELETE /products/{id}/options/{optionId}` - deletes the specified product option.

All models are specified in the `/Models` folder, but should conform to:

**Product:**
```
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description",
  "Price": 123.45,
  "DeliveryPrice": 12.34
}
```

**Products:**
```
{
  "Items": [
    {
      // product
    },
    {
      // product
    }
  ]
}
```

**Product Option:**
```
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "ProductId": "abcd4567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description"
}
```

**Product Options:**
```
{
  "Items": [
    {
      // product option
    },
    {
      // product option
    }
  ]
}
```
