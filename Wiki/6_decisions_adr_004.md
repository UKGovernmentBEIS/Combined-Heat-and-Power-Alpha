# ADR-004 Authentication & Authorisation

- Status: proposed
- Deciders: stuart.brown@equalexperts.com
- Date: 17th April 2023
 
## Context
The legacy system stores user passwords in a database with the passwords asymmetrically encrypted using AES256 bit encryption. These details can be imported into the back office data storage environment. Users could then authenticate from the UX Forms service to a table in that environment. How should authentication & authorisation be implemented?
 
## Decision Drivers
- Implementation time and costs
- Easy to configure, change and maintain
- Secured and monitored
 
## Considered Options
1. OAuth 2 Client Credentials Flow provided by an ASP.NET Core Web API application
2. OAuth 2 On Behalf Of Flow provided by an ASP.NET Core Web API application
 
## Decision Outcome
Chosen option 1: "OAuth 2 Client Credentials Flow". UX Forms is a server based solution used by users with a single role 'Applicant'. Server to server authentication is then the requirement. UX Forms will authenticate users using the provided ASP.NET Core Web API application, which will return a token for use when pulling and pushing data via the integration API.

## Discounted Options
1. n/a
2. OAuth 2 On Behalf Of Flow - discounted as a single role (applicants) will use the integration API.