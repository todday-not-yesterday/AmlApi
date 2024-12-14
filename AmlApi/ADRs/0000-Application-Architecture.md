# Software Application Architecture 

## Context and Problem Statement     

The AML system is a big system that is actively looking into expanding to gather more customers across the country, therefore an architecture that allows for seamless scalability, clear to follow, and proven to be working in the real world is needed. Furthermore, we would need to pick an architecture that works well in tackling our main non-functional requirements. 

## Considered Options   

* Three tier architecture   

* Two tier architecture   

* Microservice architecture   

## Decision Outcome   

* Three tier architecture with Microservices 

## Consequences     

* This architecture will increase the complexity of our system, this would be fine for our case as it would offer flexibility and scalability. 

## Pros

* AML requires scalability, with this style each tier can scale on its own as required.   

* Because this project will be team based, it would allow us to work in different components at the same time without conflicting with each other.   

* It offers improved security as we can implement further security measures in the business layer, and the presentation tier can’t connect straight away to the data tier, providing less power for users with bad intentions.   

* This architecture makes the system loosely coupled meaning that components can be reusable with each other, for example, when creating a new UI, some of the databases/APIs can be used again. 

* The separation of layers is also great to tackle each of our Non-functional requirements in the correct places. 

## Cons  

* Separating the concerns into different places can lead to performance issues. Ensuring good connections from each place is needed. 