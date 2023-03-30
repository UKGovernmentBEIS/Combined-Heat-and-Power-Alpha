# DESNZ.CHPQA.Alpha.Prototype - ASP.NET Core 3.1 Server

CHPQA Schemes and Submissions Proxy/Facade API

## Upgrade NuGet Packages

NuGet packages get frequently updated.

To upgrade this solution to the latest version of all NuGet packages, use the dotnet-outdated tool.


Install dotnet-outdated tool:

```
dotnet tool install --global dotnet-outdated-tool
```

Upgrade only to new minor versions of packages

```
dotnet outdated --upgrade --version-lock Major
```

Upgrade to all new versions of packages (more likely to include breaking API changes)

```
dotnet outdated --upgrade
```


## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```
## Run in Docker

```
cd src/DESNZ.CHPQA.Alpha.Prototype
docker build -t desnz.chpqa.alpha.prototype .
docker run -p 5000:8080 desnz.chpqa.alpha.prototype
```
