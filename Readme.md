# ASP.NET CORE View unittest using Selenium and Self-host integrated.

1. Purpose: Unittest all views, including html, js. Same idea can be applied for rich client app base on angular/react/vuejs ....

2. Known issue: Couldn't have js code cover report, need apply some js patch in future. 

3. Implementation: 
  - TestInitialze: 
    * Construct Self-host web-application
    * Mocking services used by controller
    * Construct Selenim Driver

  - Test:
    * Use Driver to request self-hosted page
    * Assert expected behavior.

  - Cleanup:
    * Clean up Selenium driver
    * Stop web-app

4. Example: UF.Web.Test/UnitTest1.cs
