# InfinitusApp.Client.Net

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
