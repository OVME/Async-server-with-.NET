using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace THreadPoolApplication
{
    class Factorial
    {
        private Request _request;
        private ManualResetEvent _done;

        public Factorial(Request r, ManualResetEvent e)
        {
            _request = r;
            _done = e;
        }

        public void ThreadPoolCallback(Object threadContext)
        {
            Console.WriteLine("Calculating factorial of {0}",_request.N);
            _request.Result = Calculate(_request.N);
            _request.HandledTime = DateTime.Now.ToString();
            Console.WriteLine("Factorial of {0} calculated.", _request.N);
            _done.Set();
        }

        public string Calculate(int n)
        {
            BigInteger fact = 1;
            for (int i = 1; i < n; i++)
            {
                fact = fact*i;
            }
            return fact.ToString();
        }


    }
}
