# ADR-001 Front-End: Reuse, Buy or Build 

- Status: proposed
- Deciders: stuart.brown@equalexperts.com
- Date: 17th April 2023
 
## Context
The new service will be built to conform with GDS standards, specifically the front end will be built using the GDS Design System.
 
## Decision Drivers
- Implementation time and costs
- Easy to configure, change and maintain
- Progressive enhancement (making the front end work using HTML only first, then with styling and then using JavaScript)
 
## Considered Options
1. Reuse the existing system's front end stack (Sencha Ext JS)
2. Buy and configure UX Forms (A managed service)
3. Buy and configure GDS Forms (A managed service)
4. Build using a modern development platform (ASP.NET Core MVC)
5. Build using an extensible platform (PowerApps Portals)
 
## Decision Outcome
Chosen option 2: "UX Forms". UX Forms offers a quoted 80% cost reduction and 50% implementation time over build options. Its capability has been proven in existing GDS transactional services (Patent Office), and is provided as a managed platform with analytics and an uptime SLA of 99.95%.

## Discounted Options
1. Reuse the existing system's front end stack (Sencha Ext JS) - discounted in favour of a more modern platform. 
2. n/a
3. Buy and configure GDS Forms (A managed service) - discounted due to lack of integration (form submissions are emailed) and lack of form branching / flow capabilities.
4. Build using a modern development platform (ASP.NET Core MVC) - discounted due to development time and effort when compared to a managed service approach, along with the lack of ease of making changes and maintenance once live.
5. Build using an extensible platform (PowerApps Portals) - Discounted due to difficulty implementing GDS design system styling.
