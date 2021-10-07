using System;
namespace SampleConApp.Day05
{
    class Parent
    {
        public void TestNonVirtualFunc() => Console.WriteLine("Don't expect to be modified");
        public virtual void TestFunc() => Console.WriteLine("Test function from base");//modifiable in derived class
    }
    class child : Parent
    {

        public override void TestFunc() => Console.WriteLine("Test function modified in the override");//add new things
    }
 
        static class ParentFactory
        {
            public static Parent GetObject(string name)
            {
                Parent obj = null;
                if (name.ToLower() == "parent")
                    obj = new Parent();
                else
                    obj = new child();
                return obj;
            }
        }

    


    
    class MethodOverriding
    {
    static void Main(string[] args)
    {
            // Parent obj = new Parent();
            // obj.TestFunc();
            //obj = new child();
            // obj.TestFunc();
            Console.WriteLine("tell me which class you want parent or child");
            string classname = Console.ReadLine();
            Parent obj = ParentFactory.GetObject(classname);
            obj.TestFunc();
    }
    }
}
