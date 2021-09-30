## Miscellaneous
.NET 5.0 is the current "main" release.  Let's use that one.  6.0 is currently in release candidate status so let's wait on upgrading to that one right now.
```
dotnet --list-sdks
dotnet help
dotnet new -h
dotnet help new
```

## Create solution named "Sample" and project also named "Sample" in a subfolder
```
dotnet new mvc --output Sample/Sample --framework net5.0 --auth None --razor-runtime-compilation true
dotnet new sln -o Sample
dotnet sln Sample add Sample/Sample
```

## Add required packages
[Documentation for command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package)
[NuGet Repository](https://www.nuget.org/)
Either manually add version information (--version) or double check that you got the ones you wanted

```
cd Sample
dotnet list package
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
# If planning to use lazy loading
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```

## Run and open
```
dotnet dev-certs https --trust
dotnet build
dotnet run
code .
```

## Add data model and finish setting up EF
Install or update the tool (install is only needed once as it installs the tool globally)
```
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

Add DB connection with connection string named SampleConnection.

Reverse engineer C# model files from the DB schema found through the SampleConnection, placing them in the Models folder, and also create a DBContext subclass called SampleDbContext in the Models folder.  If older models exist already, the --force will overwrite them.
```
dotnet ef dbcontext scaffold Name=SampleConnection Microsoft.EntityFrameworkCore.SqlServer --context SampleDbContext --context-dir Models --output-dir Models --verbose --force
# or if you want to use data annotations in your model classes rather than defining things in the context class
# try them one after another to see the difference in the generated classes
dotnet ef dbcontext scaffold Name=SampleConnection Microsoft.EntityFrameworkCore.SqlServer --context SampleDbContext --context-dir Models --output-dir Models --verbose --force  --data-annotations
```
