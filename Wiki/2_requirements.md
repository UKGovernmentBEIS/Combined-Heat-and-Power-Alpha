# Requirements

The current Combined Heat & Power Quality Assurance (CHPQA) portal  is a transactional digital service, in essence it digitalises a paper based assessment form process. It was designed approx. 20 years ago. It is currently hosted on premise with the current supplier, Ricardo.
This portal is not compliant with government digital standards, and work is required to ensure that the CHPQA replacement system is secure, meeting all current privacy, security, accessibility standards and legislation.

## Overview
In the Alpha stage we are seeking to prove a buy before build approach, using cloud based managed service platforms to reduce the cost of delivery and provide a more modular and extensible system. For this approach the prototype will use Microsoft Azure, Dynamics 365 and Dataverse to host authentication, authorisation, integration and data storage components.
The Department for Energy Security and Net Zero have indicated that they currently use both Microsoft Azure and Dynamics 365 for other services, and that they are a preferred platform for the new CHPQA service.

## Functional Requirements

### Beta Phase

- Allow Responsible Persons (RPs) to add, update & submit details of their CHPQA schemes, and the current meter readings data. As part of these submissions allow supporting documentation to be attached and allow RPs to send, and respond to, queries to Technical Assessors.

- Allow Technical Assessors (TAs) to review and validate the current submission data for RP schemes, allowing supporting documentation to be attached and to raise and answer queries to RPs. Allow TAs to log audit recommendations.

- Allow Administrators to assign schemes to TAs.

- Allow Net Zero Approvers to view and approve RP schemes and to issue appropriate certification.

- Allow independent auditors to export all scheme data so that appropriate auditing of the data can be done, including raising queries to RPs.

- Allow Net Zero Policy Analysts to run appropriate business reports on all scheme data.

- Allow data subscribers, both within and without the Department of Energy Security and Net Zero to export appropriate data, for further analysis and reporting.

### Alpha phase
- We have chosen a steel thread to implement in a prototype, using one of the currently more complex processes done in the current system.

- This prototype will show an end to end user journey from annual submission of a complex scheme’s annual submission, through to the back office assessment and approval of that submission.

## Non-functional Requirements

Non functional requirements will be specified for use in the beta phase, but not used in their entirety in the alpha prototype.

## Assumptions and Dependencies

None.
