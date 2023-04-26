# Outline Threat Assessment

This section describes the threats, risks and mitigations for the integration API component. UX Forms is a managed service, provided by an ISO 27001 certified company and is independently tested. Dynamics 365 is a managed service provided by Microsoft and is subject to their security strategy and implementation.

## Assets
- Applicant data
- DESNZ data
- User credentials

## Threats

1. Unauthorised access: A threat actor gains access to the web service by exploiting vulnerabilities in the authentication or authorization process, allowing them to steal sensitive data or cause damage to the service.

2. Denial of Service (DoS) attacks: A threat actor floods the web service with traffic, causing it to become unavailable to legitimate users.

3. Malware and viruses: A threat actor infects the web service with malware or viruses, allowing them to steal data or cause damage to the service.

4. Phishing attacks: A threat actor sends emails or messages that appear to be from the web service, but are designed to trick users into revealing sensitive information such as login credentials or personal data.

5. Injection attacks: A threat actor injects malicious code into the web service, such as SQL injection or cross-site scripting, allowing them to steal data or take control of the service.

6. Insider threats: A trusted insider, such as an employee or contractor, intentionally or unintentionally causes harm to the web service by accessing or leaking sensitive data or introducing vulnerabilities.

7. Social engineering: A threat actor uses psychological manipulation to trick employees or users of the web service into revealing sensitive information or taking actions that could compromise the service.

## Risks

1. Unauthorised access: Risk of confidential information being stolen, customer data being exposed, or the web service being taken offline.

2. Denial of Service (DoS) attacks: Risk of customers being unable to access the web service, lost revenue, and reputational damage.

3. Malware and viruses: Risk of data being stolen, sensitive information being compromised, or the web service being taken offline.

4. Phishing attacks: Risk of customer data being stolen, sensitive information being exposed, or the web service being taken offline.

5. Injection attacks: Risk of data being stolen, sensitive information being exposed, or the web service being taken offline.

6. Insider threats: Risk of data breaches, unauthorised access, or the web service being taken offline.

7. Social engineering: Risk of confidential information being exposed, customers being targeted for fraud, or the web service being taken offline.

## Mitigation

1. Unauthorised access: Implement strong authentication mechanisms, such as multi-factor authentication, to prevent unauthorised access. Implement access controls to limit access to sensitive data.

2. Denial of Service (DoS) attacks: Implement traffic filtering and rate-limiting mechanisms to prevent DoS attacks. Implement redundancy and failover mechanisms to ensure service availability.

   Recommendation: Azure Front Door in prevent mode, API throttling via rate limiting middleware.

3. Malware and viruses: Implement anti-malware and antivirus software to detect and prevent the installation of malicious software. Implement patch management processes to ensure that all software is up-to-date.

4. Phishing attacks: Liaise with DESNZ on existing strategy.

5. Injection attacks: Implement input validation mechanisms to prevent injection attacks. Analyse Dataverse & underlying storage mechanism (Can be SQL Server)

6. Insider threats: Implement access controls and monitoring mechanisms to prevent insider threats. Liaise with DESNZ on existing strategy.

7. Social engineering: Liaise with DESNZ on existing strategy.

## Testing & Monitoring

A full security / penetration test should be undertaken before key stages of delivery.

Recommendation to schedule ongoing penetration testing at regular intervals.

Azure Log Analytics and Application Insights should be used to consume application logging data. Liaise with DESNZ on existing strategy, but the logging data should be fed through to the DESNZ SIEM/SOAR.