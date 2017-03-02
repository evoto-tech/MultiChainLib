using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MultiChainLib.Harness
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var task = Task.Run(async () =>
                {
                    await new Complete().RunAsync();
//                    await new Example().RunAsync();
                });
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("**********************");
                Console.WriteLine(ex);
            }
            finally
            {
                if (Debugger.IsAttached)
                    Console.ReadLine();
            }
        }
    }
}