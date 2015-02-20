using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncThreadPoolApplication
{
    class Program
    {
        private static RequestContext context = new RequestContext();
        static void Main(string[] args)
        {
            List<Factorial> factorials = new List<Factorial>();
            List<Request> requests;
            //ManualResetEvent[] doneEvents;
            while (true)
            {
                requests = new List<Request>(context.Requests.Where(p => p.HandledTime == null));
                
                var k = requests.Count;
                for (int i = 0; i < requests.Count; i++)
                {
                    requests[i].HandledTime = "_";
                    var f = new Factorial(requests[i]);
                    factorials.Add(f);
                    ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
                }

                
                context.SaveChanges();
                
                var factorialsToRemove = (from f in factorials where context.Requests.Any(p => p.Id == f.Request.Id && p.HandledTime == null) select f).ToList();
                
                foreach (var f in factorialsToRemove)
                {
                    factorials.Remove(f);
                }
                
                if(k==0) Thread.Sleep(5000);
                

            }
        }


    }
}
