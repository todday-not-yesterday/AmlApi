# Database decision 

## Context and Problem Statement    

AML requirements would need a database that is scalable, maintainable, and secure.  

## Considered Options  

* SQL Server 

* MySQL  

* PostgreSQL  

## Decision Outcome  

* PostgreSQL 

## Consequences    

* All of the listed options are mature and would work well with our solution, PostgreSQL has a great community support and would integrate well with our other decisions. 

## Pros 

* Good documentation as it's open source 

* A lot of services offer free hosting for PostgreSQL 

* Works well with C# and EF Core 

* Allow the flexibility of having JSON data if needed 

* Is a relational database which is better suited for our implementation 

## Cons 

* The setup of hosting our database and having it in our API to work with entity framework can be challenging. 