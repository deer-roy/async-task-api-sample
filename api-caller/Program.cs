using System.Collections.Specialized;
using System.Web;

public class Program
{

    static async Task MakeNetworkCall(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            await response.Content.ReadAsStringAsync();
            return;
        }
    }

    static async Task Main(string[] args)
    {
        if(args.Length < 2) {
            Console.WriteLine("dotnet run -- <'cpu' or 'io'> <number of requests> <'async'>");
            return;
        }
        var cpuBound = args[0].ToLower() == "cpu";
        var numberOfRequests = int.Parse(args[1]);
        var useAsync = args.Length > 2 && args[2].ToLower() == "async";
        var suffix = useAsync ? "Async" : "";

        Console.WriteLine($"Task type: {(cpuBound? "cpu-bound": "io-bound")}");
        Console.WriteLine($"Number of requests: {numberOfRequests}");
        Console.WriteLine($"Using Async: {useAsync}");
        
        var url = cpuBound
            ? $"http://localhost:8000/prime{suffix}"
            : $"http://localhost:8000/todo{suffix}";
            
        var then = DateTime.Now;
        var tasks = new List<Task>();


        for (int i = 0; i < numberOfRequests; i++)
        {
            tasks.Add(MakeNetworkCall(url));

        }

        await Task.WhenAll(tasks);
        var now = DateTime.Now;

        var duration = now - then;
        Console.WriteLine($"\nTook {duration.TotalSeconds}s to complete.");
    }
}