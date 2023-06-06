using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/")]
public class TodoController : ControllerBase
{

    public class Todo {
       public int Id {get; set;}  
       public string Title {get; set;}  = null!;
       public bool Completed {get; set;}
    }
    
    const string url = "https://jsonplaceholder.typicode.com/todos/1";

    [HttpGet(Name = "todo")]
    [Route("todo")]
    public  Todo GetTodo() {
        
        using (HttpClient client = new HttpClient())
        {
            var responseTask = client.GetAsync(url);
            responseTask.Wait();
            var response = responseTask.Result;
            var task = response.Content.ReadFromJsonAsync<Todo>();
            task.Wait();
            return task.Result!;
        }
    }

    [HttpGet(Name = "todoAsync")]
    [Route("todoAsync")]
    public async Task<Todo> GetTodoAsync() {
        
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            return (await response.Content.ReadFromJsonAsync<Todo>())!;
        }
    }
}
