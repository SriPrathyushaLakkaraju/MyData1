using System;

namespace SampleConApp.Day06
{
    abstract class SuperBaseClass
    {
        public void NormalFunc() => Console.WriteLine("This is normal method of abstract class");
        public virtual void VirtualFunction() => Console.WriteLine("This is virtual method of abstract class");
        public abstract void SuperFunction();//This is now an abstract method.
    }
    class SuperImplementor : SuperBaseClass
    {
        public override void SuperFunction()
        {
            Console.WriteLine("Abstract method implemented in derived class");
        }
    }

    class AbstractClass
    {
        static void Main(string[] args)
        {
           // SuperBaseClass sb = new SuperBaseClass();this wont work as abstract classes cannot be instantiated
            SuperBaseClass sb = new SuperImplementor();
            sb.SuperFunction();
            sb.NormalFunc();
            sb.VirtualFunction();
        }
    }
}
