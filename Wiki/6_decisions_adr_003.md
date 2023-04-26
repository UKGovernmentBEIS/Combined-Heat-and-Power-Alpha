# ADR-003 Integration API

- Status: proposed
- Deciders: stuart.brown@equalexperts.com
- Date: 17th April 2023
 
## Context
Given the proposed front end service and the back office system implementations are managed services, there is a need to integrate the two. What method is best to achieve this?
 
## Decision Drivers
- Implementation time and costs
- Easy to configure, change and maintain
 
## Considered Options
1. Dataverse Dataflows & Cloud Flows
2. Build using a modern development platform (ASP.NET Core MVC)
 
## Decision Outcome
Chosen option 2: "Build". Building a Proxy/Facade Web API using an Open API 3 specification contract first approach, scaffolding using that contract and then using a code generator such as the XrmToolbox plugin https://github.com/yagasoft/DynamicsCrm-Template-based-Code-Generator-Plugin will result in reduced development and delivery effort and time. 

## Discounted Options
1. Dataverse Dataflows & Cloud Flows - discounted due to scale of data model and anticipated complexity in implementation.
