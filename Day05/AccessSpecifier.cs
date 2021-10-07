using System;
namespace SampleConApp.Day05
{
    class SampleClass
    {
        public void publicFunction() => Console.WriteLine("Accessiable anywhere");
        private void privateFunction() => Console.WriteLine("Accessiable with in classs");
        protected void protectedFunction() => Console.WriteLine("Accessiable with in family");
        internal void internalFunction() => Console.WriteLine("Accessiable with in project");
        protected internal void ProcInternalFunction() => Console.WriteLine("Accessiable with in project or with in family");
    }
    class derivedclass : SampleClass
    {
        public void callmyFunctions()
        {
            protectedFunction();//accessiable because it is derives class of SampleClass
        }
    }
    class AccessSpecifier
    { 
        static void Main(string[] args)
        {
            SampleClass sc = new SampleClass();
            sc.publicFunction();
            //sc.privateFunction();hiddeen to outside world
          // sc.protectedFunction();//hidden with in the class and its derived class 
            sc = new derivedclass();//to access protectd class from SampleClass
            ((derivedclass)sc).callmyFunctions();//typecast to get the new method which is not there in the base class
            sc.internalFunction();
            sc.ProcInternalFunction();

        }
    }
}
