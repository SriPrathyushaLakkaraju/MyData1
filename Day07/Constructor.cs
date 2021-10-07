using System;

//namespace SampleConApp.Day07
//{
//    class Radio
//    {
//        public string Name { get; set; }
//        public void Play() => Console.WriteLine("{0} is Playing", Name);
//    }
//    class Car
//    {
//        public Car()//Default constructor
//        {
//            Entertainment = new Radio { Name="HONDA"};

//        }
//        public Car(Radio radio)
//        {
//            Entertainment = radio;
//        }
//        public Radio Entertainment { get; set; }//Association HAS-A Relationship
//        public void Run()
//        {
//            Console.WriteLine("Car in Run mode");
//            Entertainment.Play();
//        }
//    }
//    class Constructor
//    {
//        static void Main(string[] args)
//        {
//            Car car = new Car();
//            car.Run();
//            car.Entertainment = new Radio { Name = "JBL" };
//            car.Run();
//        }
//    }
//}
/////////////////////////////////////////
namespace SampleConApp.Day07
{
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Base class Constructor");
        }
        public BaseClass(string name)
        {
            Console.WriteLine($"Base class with {name} as argument");
        }
    }
    class DerivedClass : BaseClass
    {
        public DerivedClass(): base("Super")
        {
            Console.WriteLine("Derived class constructor");
        }
    }
    class Constructor
    {
        static void Main(string[] args)
        {
            DerivedClass dc = new DerivedClass();
        }
        
    }
}