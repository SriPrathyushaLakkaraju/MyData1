using System;
namespace SampleConApp.Day04
{
    class Calculator
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter two numbers");
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your choice");
            Console.WriteLine("1.Addition \n 2.Subtraction \n 3.Multiplication \n 4.Division");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    double add = num1 + num2;
                    Console.Write("You are selected Addition \n The Addition of given two numbers {0} and {1} is {2} \n",num1,num2,add);
                    break;
                case 2:
                    if (num1 >= num2)
                    {
                        double sub = num1 - num2;
                        Console.Write("You are selected Suntraction \nThe Subtraction of given two numbers is {0}\n", sub);
                        break;
                    }
                    else
                        Console.WriteLine("You are selected Subtraction \nThe number1 should be greater than number2 for subtraction\n");
                      
                    break;
                case 3:
                    double mul = num1 * num2;
                    Console.WriteLine("You are selected Multiplication \nThe Multiplication of given two numbers is {0}\n", mul);
                    break;
                case 4:
                    double div = num1 / num2;
                    Console.WriteLine("You are selected Division \n The Value for division is {0}\n", div);
                    break;

                default:
                    Console.WriteLine("Please select the Valid Option");
                    break;
            }
        }   
    }
}
