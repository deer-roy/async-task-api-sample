using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/")]
public class PrimeController : ControllerBase
{

    [HttpGet(Name = "prime")]
    [Route("prime")]
    public int Get()
    {
        var prime = GetLargestPrimeNumber();
        return prime;
    }
    
    [HttpGet(Name = "primeAsync")]
    [Route("primeAsync")]
    public async Task<int> GetAsync()
    {
        // Console.WriteLine($"Async processing for {n}...");
        var bigPrime = await Task.Run(() =>
        {
            return GetLargestPrimeNumber();
        });

        return bigPrime;
    }


    static int GetLargestPrimeNumber()
    {
        int count = 0; // Counter for prime numbers
        int num = 2; // Starting number to check for primality
        int largestPrime = 0;
        var n = 100_000;

        while (count < n)
        {
            if (IsPrime(num))
            {
                count++;
                largestPrime = num;
            }
            num++;
        }

        return largestPrime;
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        int sqrt = (int)Math.Sqrt(num);

        for (int i = 2; i <= sqrt; i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }

}
