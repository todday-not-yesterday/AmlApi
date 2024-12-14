# Software Application Architecture 

## Context and Problem Statement     

The Advanced media library are looking to further expand an ever growing customer base to factilitate nation wide access, therefore we have been tasked with creating an architecture design that allows for seamless scalability, intuitive user interface, and implements existing architectures that have proven real world success. Furthermore, we would need to consider non-functional requirements as part of our solution. 

## Considered Options   

* Service oriented architecture

* Three-tier architecture   

* Two-tier architecture   

* Microservice architecture   

## Decision Outcome   

* a combination of Three-tier and Microservice architecture  

## Consequences     

* Through the combination of three-tier and microservice architecture, the overall complexity will be increased. However, this is okay as the benifits of flexibility, maintainability, and scalability outweigh the increased complexity.

## Pros

* Scalability: with this architecture each tier can scale on its own as required.   

* Because this project will be team based, it would allow us to work in different components at the same time without conflicting with each other.   

* It offers exceptional security as there is no direct link between the presentation and data tiers.

* This architecture allows for components to be loosely coupled, giving us the advantage of reusing components. For example, the reuse of UI components and API endpoints. 

* This archeticture gives us the capability of ensuring non-functional requirments are met through out the solution.

## Cons  

* Due to the three-tier architecture having different layers, performance can be impacted negatively.

* Three tier is typically more expensive as there are more layers to host and maintain. 