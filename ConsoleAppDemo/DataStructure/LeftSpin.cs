using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.DataStructure
{
    class LeftSpin
    {
        public string ReverseLeftWords(string s, int n)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            var arr = s.ToArray();
            Reverse(arr, 0, arr.Length - 1);
            Reverse(arr, 0, arr.Length - 1 - n);
            Reverse(arr, arr.Length - n, arr.Length - 1);
            return new string(arr);
        }

        private void Reverse(char[] arr, int start, int end)
        {
            for (int i = start, j = end; i <= j; i++, j--)
            {
                char tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }
    }
}
