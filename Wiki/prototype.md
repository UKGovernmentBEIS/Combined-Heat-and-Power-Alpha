# Steps to re-create the prototype components in new environments

## 1. D365 Back Office Solution

### Create a new Power Platform Environment, adding a Dataverse data store

![Create Environment](./Images/D365%20Create%20Envronment.png)

---

Set 'Enable Dynamics 365 apps?' and select 'Customer Service' in the 'Automatically deploy these apps' dropdown.

![Dataverse](./Images/D365%20Create%20Envronment%20Add%20Dataverse.png)

---

Visit https://make.powerapps.com/ and select the new environment from the top right nav 'Environment' dropdown.

---

Import the solution file, [stored here](../D365/CHPQACaseManagementPrototype_1_0_0_8.zip), into that environment.

---

## 2. Integration API

Deploy the [DESNZ.CHPQA.Alpha.Prototype.API solution](../DESNZ.CHPQA.Alpha.Prototype.API/DESNZ.CHPQA.Alpha.Prototype.sln) to an Azure App Service. We used GitHub actions during alpha development, the YAML file [is here](../.github/workflows/CHPQAAlphaPrototypeApi.yml).

For local debugging, create a `appsettings.Development.json` file:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "ApplicationInsights": {
    "ConnectionString": "******"
  },
  "ApiKey": "******",
  "ClientId": "******",
  "ClientSecret": "******",
  "EnvironmentUrl": "https://{environment}.crm11.dynamics.com"
}
```

The `ClientId` and `ClientSecret` values are taken from registering an app in Azure AD, then adding an Application User in the environment for the App Registration:

1. https://learn.microsoft.com/en-us/power-apps/developer/data-platform/walkthrough-register-app-azure-active-directory

2. https://learn.microsoft.com/en-us/power-apps/developer/data-platform/authenticate-oauth#use-client-secrets--certificates

3. https://learn.microsoft.com/en-us/power-platform/admin/manage-application-users

![Adding an Application User](./Images/D365%20Create%20Application%20User.png)

---

## 3. UX Forms

Inform UX Forms of the new API base url and API Key.