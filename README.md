# LoadTool is a self contained application using .NET Core 1.1
simple console app for load testing

To restore package, run the following command:

``` dotnet restore```

To build, run the following command:

``` dotnet build ```  

To generate the self-contained application, run the following command:

``` dotnet publish -c release -r win10-x64 ```

Here is a helpful blog on how to run self contained application

[ReadMe](https://blogs.msdn.microsoft.com/luisdem/2017/03/19/net-core-1-1-how-to-publish-a-self-contained-application/)