# Database decision 

## Context and Problem Statement    

The advanced media library require data storage that is scalable, maintainable, and secure. 

## Considered Options

* SQL Server 

* MySQL

* PostgreSQL  

## Decision Outcome  

* PostgreSQL 

## Consequences    

* PostgreSQL is a mature database solution that has long term support, a great documentation, and would integrate well with our other decisions. 

## Pros 

* Good documentation as it's open source 

* A lot of services offer free hosting for PostgreSQL 

* Works well with C# and EF Core 

* Allow the flexibility of having JSON data if needed 

* Is a relational database which is well suited for our implementation 

## Cons 

* Hosting a scalable database is expensive

* The initial setup through entity framework can be quite complex.