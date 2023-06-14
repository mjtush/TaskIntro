using System;
using System.Threading.Tasks;
using System.Threading;

namespace TaskIntro
{
    internal class Program
    {
        static void Main()
        {
            var task = new Task(SimpleMethod);
            task.Start();
            task.Wait();

            var taskThatReturns = new Task<string>(MethodThatReturns);
            taskThatReturns.Start();
            taskThatReturns.Wait();
            Console.WriteLine(taskThatReturns.Result);
        }

        private static string MethodThatReturns()
        {
            Thread.Sleep(2000);
            return "Hello from return method!";
        }

        private static void SimpleMethod()
        {
            Console.WriteLine("Hello world!");
        }
    }
}