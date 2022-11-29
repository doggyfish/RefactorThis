# Refactor This - Candidate Notes

## How much time I spent on this exercise
6Hours
## Here's What I Fixed/Refactored/Added (in order of implementation, highest priority first)
separation of concerns, create service class for Prodcut and ProductOption 
move related logic from products to services
remove prodcuts and options class, move all constructor logic into services as functions
remove product and option constructor logic, move them to services as well. keep model pure.
rewrite some product loading logic for better performance, fix potential bugs
add interface and baseservice to services
Inject services dependency into controllers 
flatten serivces logic based on CRUD operations, remove un-needed property IsNew
add api result for contoller to return collections and match output requirements
added generic repository, move service logic to it, inject into service, register new dependencies, 
move connection to appsetting, remove unneeded helper class

## Further Improvements I Would Make If I Had More Time (in order of implementation, highest priority first)
Add unit of work to repository or use framework like EntityFramework
Add Dtos to transfer data from api to ui
Add mapping to map between Dtos to entities, Automapper or similar
data caching in controller
server side validation
exception handling and error logging
add factory pattern for better dependencies injection control
further separate service logic into BF/BR/DA Layer
move foldered struction to separate projects
security/role checking in BF layer
update db schema to add clustered and non-clustered indexes for better performance
add foreign key for cascade deleting
refactor DA to automatically reflect Entities for DB operations or use framework like EntityFramework
services calls into BF for better security, then BR for business logc then repo with unit of work into DA for db operations.
data caching in DA layer

## Here's What I Would Like to Talk About At The Interview