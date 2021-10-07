using System;
namespace SampleConApp.Day07
{
    sealed class TestClass//sealed classes cannot be inherited
    {
        public void TestFunc() => Console.WriteLine("Test Func");
    }
    //sealed classes can be reused only in the form of association.
    class TestClass2
    {
        private static TestClass cls = new TestClass();
        public void TestFunc()
        {
            cls.TestFunc();
            Console.WriteLine("Add some extra features in it");
        }
    }
    class SealedClass
    {
        static void Main(string[] args)
        {
            TestClass2 cls= new TestClass2();
            cls.TestFunc();

        }
      
    }
}
