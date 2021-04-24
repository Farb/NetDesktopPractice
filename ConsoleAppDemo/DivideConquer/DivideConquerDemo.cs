using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.DivideConquer
{
    class DivideConquerDemo
    {
        public double MyPow(double x, int n)
        {
            if (n == 1) return x;
            if (n > 0) return MyPow(x, n - 1) * x;
            if (n < 0) return 1 / (MyPow(x, -n));
            return 1;
        }
    }
}
