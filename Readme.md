ASP.NET CORE View unittest using Selenium and Self-host integrated.

Purpose: Unittest all views, including html, js
Same idea can applied for rich client app base on angular/react/vuejs ....

Known issue: Couldn't have js code cover report, need apply some js patch in future. 

Implementation: 
  TestInitialze: 
    Construct Self-host web-application
    Mocking services used by controller
    Construct Selenim Driver

  Test:
    Use Driver to request self-hosted page
    Assert expected behavior.

  Cleanup:
    Clean up Selenium driver
    Stop web-app

