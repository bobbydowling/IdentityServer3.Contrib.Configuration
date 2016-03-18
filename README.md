# IdentityServer3.Contrib.Configuration
Configuration API for IdentityServer and related components

## Overview ##

The IdentityServer3 Configuration handler provides XML configuration for IdentityServer3, IdentityManager, ASP.Net Identity as well as some generic application settings.  It is meant to be a one-stop-shop for all IdentityServer-related security configuration and is quite easy to extend.

Note:  This is only meant to serve as a strongly-typed, hierarchical configuration storage.  You must wire this up with the IdentityServer et al. data structures yourself.  I will update the repo with an example in time, but basicaly, instead of hard-coding your config, use this.

## Usage ##

Set your default, federated security configuration in the security.config file.  Override these stock settings in your app/web config file per IdentityServer or application instance, as needed.  Use the API to set your IdentityServer et al. data structures, instead of hard-coding.

See the test project for an example.

To use, first add the Security.config file to your project and change the project properties to copy the file to the output directory.

Next, configure your app/web config file.

* Register the handler:
```xml
<configSections>
		<section name="security" type="IdentityServer3.Contrib.Configuration.ConfigSectionHandler,IdentityServer3.Contrib.Configuration" allowLocation="false"/>
</configSections>
```

* Add the following appSettings key:
```xml
<appSettings>
		<add key="ConfigFilePath" value=""/>
</appSettings>
```

This is an optional location for the Security.Config file.

* Add the security configuration section:
```xml
<security>
</security>
```

Here you can override any/all sections/properties found in the Security.config file.

Access the API like so:
CompanySecurityConfig.Current.IdentityServer.Client.UniqueClaimTypeIdentifier
