using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncThreadPoolApplication
{
    class Factorial
    {
        public Request Request { get; set; }
        

        public Factorial(Request r)
        {
            Request = r;

        }

        public void ThreadPoolCallback(Object threadContext)
        {
            Console.WriteLine("Calculating factorial of {0}", Request.N);
            //Request.HandledTime = "_";
            Request.Result = Calculate(Request.N);
            Request.HandledTime = DateTime.Now.ToString();
            Console.WriteLine("Factorial of {0} calculated.", Request.N);
        }

        public string Calculate(int n)
        {
            BigInteger fact = 1;
            for (int i = 1; i < n; i++)
            {
                fact = fact * i;
            }
            return fact.ToString();
        }


    }
}
