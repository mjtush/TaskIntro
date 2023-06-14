using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace TaskIO
{
    internal class TaskIOClass
    {
        static void Main()
        {
            Task<string> task = Task.Factory.StartNew<string>
                (() => GetPosts("http://jsonplaceholder.typicode.com/posts"));

            SomethingElse();

            try
            {
                // Main thread waits for the task
                //task.Wait()

                // task.Results block the main thread and waits for the
                // result form task thread. Understand when and how to use it. 
                Console.WriteLine(task.Result);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SomethingElse()
        {
            // Dummy implementaiton
        }

        private static string GetPosts(string url)
        {
            // Obsolete approach
            //using (var client = new System.Net.WebClient())
            //{
            //    return client.DownloadString(url);
            //}

            using (var client = new System.Net.Http.HttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }
    }
}