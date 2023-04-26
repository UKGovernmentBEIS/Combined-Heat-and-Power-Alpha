# ADR-005 Migration Strategy 

- Status: proposed
- Deciders: stuart.brown@equalexperts.com
- Date: 17th April 2023
 
## Context
Moving users from the legacy system to the new system requires a migration strategy that provides minimal downtime and meets the needs of all stakeholders. During the discovery phase the strangler fig pattern of gradually implementing capabilities until all have been completed, after which the legacy system can be decommissioned. This assumed the use of the original data storage method (MariaDB). With Dataverse as the proposed data storage method does this decision still hold?
 
## Decision Drivers
- Minimal system unavailability
- Simple strategy
- Stakeholder requirements
 
## Considered Options
1. Strangler Fig (feature by feature migration, no user migration)
2. Big Bang (all features completed in new system, all users migrated at once)
3. Canary Release (all features completed in new system, users migrated in batches)
 
## Decision Outcome
Chosen option 3: "Canary Release". All features implemented before users are migrated in batches. The new system is then carefully monitored for issues, using both business and operational metrics. A strategy for the actual migration used per user should be determined, but could take the form of a pull from the dataverse of all data for a particular scheme, triggered manually from a back office form.

## Discounted Options
1. Strangler Fig - discounted due to having a lack of control over the existing system, making gradual feature replacement more time consuming, potentially resulting in a complex interim solution.
2. Big Bang - discounted with regards to migrating all users at one, but within the context of Strangler Fig approach of feature replacement the Big Bang approach of having the new system in place with all features is recommended, with a canary releasing approach for users.

