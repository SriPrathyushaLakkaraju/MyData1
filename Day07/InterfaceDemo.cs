using System;
namespace SampleConApp.Day07
{
   /*
     Interface is a group of functions and properties that are only abstract.
     All interface members are public only.U cannot have any other access specifiers.
    The class that implements the interface must implement all the methods in the public scope.
   Interfaces is an improved version of abstract classes.It contains only abstract members in it.
  A Class can implement multiple interfaces at the same level which U cannot do it with class.
    U can implement the interface either explicitly or implicitly in C#
    All interfaces in .NET will have a prefix I which will determine it as an interface.
     */
    interface ISimpleInterface
    {
        void SimpleFunc();
    }
    interface IExampleInterface
    {
        void ExampleFunc();
    }
    class SimpleClass : ISimpleInterface,IExampleInterface
    {
        public void ExampleFunc()
        {
            Console.WriteLine("Example Implementation");
        }

        public void SimpleFunc()
        {
            Console.WriteLine("Simple implementation");
        }
    }

    class InterfaceDemo
    {
        static void Main(string[] args)
        {
            SimpleClass cls = new SimpleClass();
            cls.SimpleFunc();
            cls.ExampleFunc();
            //ExampleInterface ex = new SimpleClass();
            //ex.ExampleFunc();
            //SimpleInterface si = (SimpleInterface)ex;//u r not creating a new object.
            //si.SimpleFunc();
            ISimpleInterface si = new SimpleClass();
            si.SimpleFunc();
            //si.ExampleFunc();//we cannot call like this.
            IExampleInterface ei = (IExampleInterface)si;
            ei.ExampleFunc();

        }
    }
}
