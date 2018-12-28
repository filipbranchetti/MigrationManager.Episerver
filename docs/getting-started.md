## Getting started

### Installing Package

Installation nowadays can't be more simpler as just adding NuGet package(s).

```
PM> Install-Package MigrationManager.Episerver -Version 1.0.0
```

After installation of the package, make sure that module.config contains

```
 <add assembly="MigrationManager.Episerver" />
```

### AdminUI
It will be a MigrationManger component in admin view that list all possible migrations

