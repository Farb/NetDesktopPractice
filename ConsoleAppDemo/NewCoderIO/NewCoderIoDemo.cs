using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppDemo.NewCoderIO
{
    class NewCoderIoDemo
    {
        static void Main(string[] args)
        {
            NumbersOfOne();
        }

        static void RecoverConfigFile()
        {
            var dict = new Dictionary<string, string>{ 
                { "reset", "reset what" },
                { "reset board", "board fault" },
                { "board add", "where to add" },
                { "board delete", "no board at all" },
                { "reboot backplane", "impossible" },
                { "backplane abort", "install first" },
            };
            string cmd;
            while (!string.IsNullOrEmpty(cmd=Console.ReadLine()))
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                List<string> foundKeys = new List<string>();
                if (arr.Length == 1)
                {
                    if (dict.ContainsKey(cmd))
                        foundKeys.Add(cmd);
                    else
                        foundKeys = dict.Keys.Where(k => k.StartsWith(arr[0])).ToList();
                }
                else if(arr.Length == 2)
                {
                    foundKeys= dict.Keys.Where(k => k.StartsWith(arr[0])&&k.Contains($" {arr[1]}")).ToList();
                }
                if (foundKeys.Count != 1)
                    Console.WriteLine("unknown command");
                else
                    Console.WriteLine(dict[foundKeys.First()]);
            }
        }
        static void NumbersOfOne()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;
                int n = int.Parse(line);
                int count = 0;
                while (n > 0)
                {
                    if ((n & 1) == 1)
                        count++;
                    n >>= 1;
                }
                Console.WriteLine(count);
            }
        }
        static void OrderByAlphabet()
        {
            int n = int.Parse(Console.ReadLine());
            var upperList = new List<string>();
            var lowerList = new List<string>();
            string str;
            for (int i = 0; i < n; i++)
            {
                 str=Console.ReadLine();
                if (char.IsUpper(str[0]))
                    upperList.Add(str);
                else
                    lowerList.Add(str);
            }
            upperList.Sort();
            lowerList.Sort();

            upperList.ForEach(u => Console.WriteLine(u));
            lowerList.ForEach(l => Console.WriteLine(l));
        }
        static void LengthOfLastWord()
        {
            string line = Console.ReadLine().TrimEnd();
            int count = 0;
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (line[i] == ' ')
                    break;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
