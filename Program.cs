using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumberAsyncApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int startRange = 0;
            int endRange = 100;
            List<int> primes = await GetPrimeNumbersAsync(startRange, endRange);
            Console.WriteLine ("List prime number: ");
            foreach (var num in primes)
            {
                Console.WriteLine(num);
            }
        }
        static async Task<List<int>> GetPrimeNumbersAsync(int start, int end)
        {
            List<int> primes = new List<int>();

            await Task.Run(() =>
            {
                for (int i = start; i <= end; i++)
                {
                    if (IsPrime(i))
                    {
                        primes.Add(i);
                    }
                }
            });
            return primes;
        }
        static bool IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            if (num == 2)
            {
                return true;
            }
            if (num % 2 == 0)
            {
                return false;
            }
            int sqrt = (int)Math.Sqrt(num);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
