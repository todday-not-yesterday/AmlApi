# UI decision 

## Context and Problem Statement    

As our architecture follows the idea of having different layers. Having an independent frontend framework that offers great support for the AML requirements and works well with other backend frameworks is needed. 

## Considered Options  

* React 

* Angular 

* Blazor 

## Decision Outcome  

* Angular 

## Consequences    

* Angular is a modern front end framework that is widely used and provides strengths which are most suited to our system.

## Pros 

* Works well as a solution to our performance NFR, as angular has many tools to have no performance issues, such as: server side rendering and run time optimisation. 

* Angular CLI is a powerful tool, and would offer us a lot of different ways to set up our codebase more quickly and efficiently. 

* Angular natively utilises dependency injection, offering faster creation of components and re use of code further supporting solid principles.

* Angular utilises Components allowing us to create more modular and reusable code this also follows the solid principles, and offers great way of tackling our two Non-functional requirements (responsiveness and accessibility) throughout our solution. 

* Angular nativly works with .NET

## Cons 

* Other frameworks can offer better cross platform experience with mobile. Such as: React with react native. 

* Learning curve is high, as it requires the set up of node and npm. Making intiial set up complex.