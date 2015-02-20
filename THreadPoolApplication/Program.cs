using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace THreadPoolApplication
{
    class Program
    {
        private static THreadPoolApplication.RequestContext context = new RequestContext();
        static void Main(string[] args)
        {
            List<Factorial> factorials = new List<Factorial>();
            List<Request> requests;
            ManualResetEvent[] doneEvents;
            while (true)
            {
                requests = new List<Request>(context.Requests.Where(p => p.HandledTime == null));
                doneEvents = new ManualResetEvent[requests.Count];
                var k = requests.Count;
                for (int i = 0; i < requests.Count; i++)
                {
                    doneEvents[i] = new ManualResetEvent(false);
                    var f = new Factorial(requests[i], doneEvents[i]);
                    factorials.Add(f);
                    ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
                }
                if(k!=0)
                    WaitHandle.WaitAll(doneEvents);
                context.SaveChanges();
          
                factorials.Clear();

                if(k==0) Thread.Sleep(5000);
                

            }
        }


    }
}
