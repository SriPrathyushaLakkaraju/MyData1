using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDB.Day19
{
    static class MyExtensionMethods
    {
        public static int GetNoOfWords(this string arg)
        {
            string[] words = arg.Split(' ', '.');
            return words.Length;
        }
    }
    class NewFeatures
    {
        static void Main(string[] args)
        {
            //varKeyword();
            //anonymousTypes();
            //lambdaExpression();
            //extensionMethod();
            linqdemo();
        }

        private static void linqdemo()
        {
            var data = new string[]//A collection object
            {
               "Apple","Mango","Oranges"
            };
            var results = from f in data select f;//query based in c# language to get the data from the collection.
            foreach (var item in results) 
            {
                Console.WriteLine(item);
            }
        }

        private static void extensionMethod()
        {
            //extension method provides a mechanism of adding a new methods to a class without breaking it.However it is not the part of any OOP features.
            string content = "Hai My name is Sri Prathyusha Lakkaraju";
            //get number of words for a given string
            var count = content.GetNoOfWords();
            Console.WriteLine("The no.of words : "+count);
        }

        private static void lambdaExpression()
        {
            //lambda expression is a substitute for creating methods for delegate objects without a need of exclusive function.
            Action action = () => Console.WriteLine("Welcome to Lambda Expression");
            action();
            Action<int> intAction = (i) => Console.WriteLine("The value passed is "+i);
            intAction(123);
            Func<double, double, double> addfunc = (v1, v2) => v2 + v1;
            var res = addfunc(123, 456);
            Console.WriteLine("The result is "+res);
        }

        private static void anonymousTypes()
        {
            var empDetails = new
            {
                Empname = "Sri",
                EmpAddress = "Nrt",
                EmpSalary = 56000,
                JoinDate = DateTime.Now.AddDays(-895)
            };//created an object of an unknown type with only properties in it.They are like data carrires in object oriented design patterns.The objective of this object is to carry data ini it.Hence the name data carriers.
            Console.WriteLine(empDetails);
            Console.WriteLine(empDetails.Empname);
            Console.WriteLine(empDetails.EmpAddress);
            Console.WriteLine(empDetails.EmpSalary);
            Console.WriteLine(empDetails.JoinDate);
        }

        private static void varKeyword()
        {
            //var is a keyword in C# to create local variables. It is also called Implicitly typed variables. var allows to declare local variables with strict typechecking. It works like object by storing any kind of data it wants, but without boxing and unboxing. Once the value is assigned to the var, it will hold that type and follows all the rules of type safety.
            //var is used to create local variables only. it cannot be used as return type of a function, parameters for a function, fields of a class or any other kind. var variable declaration and the assignment to it should happen in the same statement.
            //var provides a convinient way of creating local variables without a need to specify the type.
            var fruit = "Apple";//string.once created as string ,it will be type variable and follows all the rules of the string class.
            fruit = 123.ToString();
            Console.WriteLine(fruit.GetType().Name);
        }
    }
}
