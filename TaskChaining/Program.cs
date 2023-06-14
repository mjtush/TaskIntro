using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace TaskChaining
{
    internal class Program
    {
        static void Main()
        {
            Task<string> antecedent = Task.Run(() =>
            {
                Task.Delay(TimeSpan.FromSeconds(2));
                return DateTime.Today.ToShortDateString();
            });

            Task<string> continuation = antecedent.ContinueWith(t => "Today is "
                + antecedent.Result);
#if DEBUG
            //Debug.WriteLine("This will display before the result");
            Console.WriteLine("This will display before the result");
#endif
            Console.WriteLine(continuation.Result);
        }
    }
}