using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    public class ReflectionDemo
    {
        public static void Show()
        {
            Assembly assembly1= Assembly.GetExecutingAssembly();
            Type type1= assembly1.GetType("ConsoleAppDemo.ReflectionDemo");
            object instance= Activator.CreateInstance(type1);
            if (instance is ReflectionDemo currentInstance)
            {
                currentInstance.Test();
            }

            Assembly assembly2 = Assembly.GetCallingAssembly();
            Type type02 = assembly2.GetType("ConsoleAppDemo.ReflectionTest");
            object o2 = Activator.CreateInstance(type02, new[] { "Ctor-Params"});
            MethodInfo methodInfo= type02.GetMethod("Test");
            methodInfo.Invoke(o2, new[]{"1"});
        }

        public void Test()
        {
            Console.WriteLine($"From {nameof(ReflectionDemo)}-Test");
        }

    }

    class ReflectionTest
    {
        private string _name;
        public ReflectionTest(string name)
        {
            _name = name;
        }
        public void Test(string num)
        {
            Console.WriteLine($"num={num}");
            Console.WriteLine($"name={_name}");
            Console.WriteLine($"From {nameof(ReflectionTest)}-{nameof(Test)}");
        }
    }
}
