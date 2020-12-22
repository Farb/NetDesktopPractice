using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    public class GenericTest
    {
        public static void ShowDemo()
        {
            Console.WriteLine(typeof(List<>));
            Console.WriteLine(typeof(List<string>));
            var p = new Person();
            var ch = new Chinese();
            GenericDemo<Person, int, string, Chinese, Chinese>.ShowWork(p, 1, "test", ch, ch);
        }
    }

    public class GenericDemo<T, T1, T2, T3, T4> where T : IStudy, ILearn
        where T1 : struct//结构类型约束
        where T2 : class//引用类型约束
        where T3 : new()//无参数构造函数约束
        where T4 : Person//基类约束
    {
        public static void ShowWork(T t, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            //t.Work(); //编译错误：以下方法或属性之间的调用具有二义性:“IStudy.Work()”和“ILearn.Work()”
            t1 = default(T1);
            t2 = null;
            t3 = new T3();
            t4.Work();
        }

    }

    class Chinese:Person
    {

    }
    public class Person : IStudy, ILearn
    {
        public void Work()
        {
            Console.WriteLine("Work");
        }
        //void IStudy.Work()
        //{
        //    Console.WriteLine("Work from IStudy");
        //}

        //void ILearn.Work()
        //{
        //    Console.WriteLine("Work from ILearn");
        //}
    }

    public interface IStudy
    {
        void Work();
    }

    public interface ILearn
    {
        void Work();
    }
}
