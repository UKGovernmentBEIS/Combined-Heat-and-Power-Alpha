# Solution Overview

## Conceptual Architecture Diagram

![Conceptual Architecture](./Images/Alpha_%20Proposed%20To-Be%20Conceptual%20Architecture%20v2.svg)

The diagram above shows a high level view of the roles and components that are proposed in the alpha system design. DESNZ digital split internal and external users into separate tenants to provide a secure boundary and simpler user management.

## Component Breakdown

1. Authentication & authorisation service: provides system security, enabling users to authenticate before using the system. This will be an Azure hosted Web API service receiving user credentials and providing an OAuth 2 authentication token using the Client Credentials flow for use by UX Forms when calling the CHPQA service. ([ADR-004](6_decisions_adr_004.md))

2. Application Service: UX Forms, a managed service providing GDS styled forms. Once authenticated, users will enter data into forms hosted in this service. ([ADR-001](./6_decisions_adr_001.md))

3. CHPQA Service: an integration service serving data between the application service and the data storage service (Dataverse). This will be an Azure hosted Web API service acting as a proxy / facade between UX Forms and Microsoft Dataverse. ([ADR-003](6_decisions_adr_003.md))

4. Scheme Assessment & Administration: A custom Dynamics 365 solution built on top of the Dynamics Customer Services solution, providing the back office case management for scheme assessors. ([ADR-002](./6_decisions_adr_002.md))

5. External data storage: A Dataverse environment holding scheme, submission and case management data for use by external users (assessors and administrators). Scheme and submission data will be pushed to the internal Dataverse environment for approval (8)

6. Data Export & Import: Exposing a Dataverse view for consumption by external users using Excel / Power Query. (Not in scope for Alpha)

7. Data Analysis: A Power BI Workspace containing reports drawing data from the internal Dataverse environment. (Not in scope for Alpha)

8. Internal data storage: A Dataverse environment holding scheme, submission and case management data for use by internal users (approvers). Approval data will be pushed back to the external Dataverse environment (5)

9. Data Export & Import: Exposing a Dataverse view for consumption by internal users using Excel / Power Query. (Not in scope for Alpha)

## Component Interaction

### Authentication & authorisation service
- will interact with the Dataverse service to determine user access and system roles.
- will interact with the UX Forms service by providing an access token for use when interacting with the CHPQA integration service.

### UX Forms
- will interact with the CHPQA integration service to retrieve data from and save data to the Dataverse data storage service.

### CHPQA Service
- will interact with the Dataverse data storage service to provide user data for consumption by the UX Forms component.
- will interact with the UX Forms service to receive user data and send it to the Dataverse data storage service.

# Logical Architecture & Data flow

![Logical Architecture](./Images/Alpha_%20Proposed%20To-Be%20Logical%20Architecture%20v2.svg)

The diagram above shows a more detailed view of the components that are proposed in the alpha system design, with the interaction between each displayed.

# Data Storage

Microsoft Dataverse will be used for structured data storage. Azure Storage Accounts will be used for non-structured data storage. The storage accounts will be private (i.e., no public endpoints).

# Unstructured data analysis

As of 20th March 2023:

| Description | Files | Total Size | Largest Size |
|--|--|--|--|
|Submission Attachments|32,462|15.316 GB|28.4 MB|
|Communications attachments. (this feature hasn’t been around that long so there are fewer files stored)|818|697 MB| 29.4 MB|
|Form Submissions||11 GB|
Certificates||3 GB|
|Secretary of State Certificates (SoS)|| 2 GB|
|Energy Efficiency Certificates||84 MB|
|Audit attachments||691 MB|

_It’s believed the unstructured data grows by approximately 2 GB per year._
