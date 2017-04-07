using System;

namespace L9_CircleCalculator
{
    class CircleCalculator
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Circle roundObject = new Circle(Validator.ValidateInput());

                roundObject.printCircumference();
                roundObject.printArea();

                //exit program               
                if (Exit.ExitProgram())
                {
                    Console.WriteLine("Goodbye!");
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
        }       
    }

    class Circle
    {
        public double radius;
        private double pi = Math.PI;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double getCircumference()
        {
            return Math.Round(2 * pi * radius, 2);
        }

        public double getArea()
        {
            return Math.Round(pi * (radius * radius), 2);
        }

        public void printCircumference()
        {
            Console.WriteLine("The circumference is: " + getCircumference());
        }

        public void printArea()
        {
            Console.WriteLine("The area is: " + getArea());
        }
    }

    class Validator
    {
        public static double ValidateInput()
        {
            double result;

            Console.WriteLine("Enter a radius for the circle: ");
            bool isValid = double.TryParse(Console.ReadLine(), out result);

            if (isValid)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                return ValidateInput();
            }
        }
    }

    class Exit
    {
        //exit the program when the user wants to
        public static Boolean ExitProgram()
        {
            Console.WriteLine("Do you want to continue? Enter Y or N.");
            var KP = Console.ReadKey(true);

            while (KP.Key != ConsoleKey.N && KP.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Not a vaid answer. Do you want to " +
                    "continue? Enter Y or N.");
                KP = Console.ReadKey(true);
            }
            return KP.Key == ConsoleKey.N ? true : false;
        }
    }
}
