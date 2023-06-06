#  Api Task Example


### Running the server
First run the api server

`dotnet run --project api/api.csproj`


Then either make calls to the api yourself, or use the
api-caller project to make a number of requests to the
server.


### Using the api caller

`dotnet .. <cpu or io> <number of requests> <optional async>`


#### Examples

**Run cpu bound task using async/await**
    
    dotnet run --project api-caller/api-caller.csproj -- cpu <number of requests> async

**Run cpu bound task without using async/await**
    
    dotnet run --project api-caller/api-caller.csproj -- cpu <number of requests>

**Run io bound task using async/await**

    dotnet run --project api-caller/api-caller.csproj -- io <number of requests> async


**Run io bound task without using async/await**
    
    dotnet run --project api-caller/api-caller.csproj -- io <number of requests>

