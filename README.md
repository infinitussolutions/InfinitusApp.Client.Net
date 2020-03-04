# InfinitusApp.Client.Net

## Start
### Install InfinitusApp.Services in your project
[![Nuget](https://img.shields.io/nuget/dt/InfinitusApp.Services)](https://www.nuget.org/packages/InfinitusApp.Services)
[![Nuget](https://img.shields.io/nuget/v/InfinitusApp.Services)](https://www.nuget.org/packages/InfinitusApp.Services)

```npm
PM > Install-Package InfinitusApp.Services
```

## How to use

Create a new intance from InfinitusAppServiceClient

``` csharp
public InfinitusAppServiceClient InfinitusAppServiceClient 
{ 
    get 
    { 
      return InfinitusServiceExt.CreateInfinitusAppServiceClientForApp("Yout AppId", "Yout AppSecret", "You ClientId"); 
    } 
}
```

#### Create a new instance from InfinitusApp.Services

```csharp
public SignaturePlanService SignaturePlanService 
{ 
    get 
    { 
        return new SignaturePlanService(InfinitusAppServiceClient); 
    }
}
```
#### And call Api:

````
var a = await SignaturePlanService.GetAll();
````

