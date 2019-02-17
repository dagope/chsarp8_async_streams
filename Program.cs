using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Async streams C# 8.0 ");            
            Console.WriteLine("Start - using tasks with IEnumerable in C# 7.0 ");

            foreach(var data in await GetBigResultsWithCsarp7Async())
            {
                Console.WriteLine($"{DateTime.Now.ToString()}  => {data}");
            }
        
            Console.WriteLine("End - using tasks with IEnumerable in C# 7.0 ");
            
            Console.WriteLine("Start - using tasks with IAsyncEnumerable in C# 8.0 ");

            await foreach(var data in GetBigResultsWithCsarp8Async())
            {
                Console.WriteLine($"{DateTime.Now.ToString()}  => {data}");
            }            
            
            Console.WriteLine("End - using tasks with IAsyncEnumerable in C# 8.0 ");
        }
        
        static async Task<IEnumerable<int>> GetBigResultsWithCsarp7Async()
        {
            List<int> dataPoints = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000); //Simulate waiting for external API
                dataPoints.Add(i);
            }
        
            return dataPoints;
        }
        
        static async IAsyncEnumerable<int> GetBigResultsWithCsarp8Async()
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000); //Simulate waiting for external API
                yield return i;
            }
        }
        
    }
}

