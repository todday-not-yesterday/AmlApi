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

* All of the considered options would work well with our requirements. We thought  

## Pros 

* Angular has typescript support which makes it easy to catch errors and refactor 
* Works well as a solution to our performance NFR, as it angular has many tools to have no performance issues, such as: server side rendering and run time optimisation. 

* Angular CLI is a great tool to use, and would offer us a lot of different ways to set up our codebase more quickly and efficiently. 

* It utilise dependency injection into our code which aids solid principles 

* Angular utilises Components allowing us to create more modular and reusable code this also follows the solid principles, and offers great way of tackling our two Non-functional requirements (responsiveness and accessibility) on a specific piece of work. 

* As we are using Dotnet, angular works well with it 

## Cons 

* Other frameworks can offer better cross platform experience with mobile. Such as: React with react native. 

* Learning curve is high and we would need to spend a lot of time learning how to configure it and make it work well. 