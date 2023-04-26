# Security

## Security Engineering Principles

Although this system is a prototype, we will still be guided by these principles:

1. Least privilege principle: We will limit user and system component access to the minimum required for their roles and tasks.
2. Data encryption: We will encrypt data at rest, in transit, and during processing.
3. Input validation and sanitisation: we will validate and sanitise user inputs and data from external sources to prevent injection attacks and data corruption.
4. Logging and monitoring: We will implement logging and monitoring to detect, alert, and respond to security incidents.
5. Secure API design: We will design the APIs with strong authentication, authorisation, and rate limiting controls to prevent unauthorised access.
6. Network segmentation: We will isolate system components into separate network zones, limiting access between them to reduce the risk of lateral movement.

## Encryption
We will encrypt data at rest, in transit, and during processing.

## Threat Protection and Vulnerability Management
We will host the two Azure app services behind an Azure Front Door implementation with WAF configured in prevent mode and OWASP rules set.

## Authentication
Applicants will be authenticated from UX Forms using an OAuth 2 Client Credentials grant type endpoint, served by the Authentication & Authorisation service outlined above. UX Forms will then use this to interact with the CHPQA API to pull from and push to the external Dataverse environment. ([ADR-004](./6_decisions_adr_004.md))
External assessors and administrators and internal approvers and data analysts will use Azure AD.

## Data Access and Tenant Security
Access to the data will be restricted using RBAC and Dataverse entity permissions.

## Backups and Data Retention Policy
As the system is a prototype, there will be no automated backups and user and logging data will be removed within 3 months from the end of the alpha phase.
