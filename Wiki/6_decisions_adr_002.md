# ADR-002 Back Office Case Management: Reuse, Buy or Build

- Status: proposed
- Deciders: stuart.brown@equalexperts.com
- Date: 17th April 2023
 
## Context
The new service will be split into a public facing web service and private back office case management system for assessors and approvers to progress scheme applications and renewals.
 
## Decision Drivers
- Implementation time and costs
- Easy to configure, change and maintain
- Extensible, with built-in reporting and analytics capabilities
 
## Considered Options
1. Reuse the existing system implementation (Sencha Ext JS)
2. Buy and configure Dynamics 365 Customer Services
3. Buy and configure SalesForce
4. Buy and configure ServiceNow
5. Build using a modern development platform (ASP.NET Core MVC)
 
## Decision Outcome
Chosen option 2: "Dynamics 365 Customer Services". Dynamics is in use in 15-20 services within DESNZ, is highly extensible and has configurable case management capabilities built in. Dynamics 365 systems can be configured and deployed in a fraction of the time a build-from-scratch system can.

## Discounted Options
1. Reuse the existing system implementation (Sencha Ext JS) - discounted in favour of a more modern and extensible platform. 
2. n/a
3. Buy and configure SalesForce - discounted due to lack of department experience and associated training requirements when compared to Dynamics 365..
4. Buy and configure ServiceNow - discounted due to lack of department experience and associated training requirements when compared to Dynamics 365.
5. Build using a modern development platform (ASP.NET Core MVC) - development time and effort when compared to a managed service approach, along with the lack of ease of making changes and maintenance once live.
