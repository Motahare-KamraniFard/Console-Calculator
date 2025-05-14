using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /// Provides a console - based interface for performing basic arithmetic and scientific operations.
            /// Supported operations: addition (+), subtraction (-), multiplication (*), division (/), exponentiation (^),
            /// modulo (%), square root (sqrt), and logarithm base 10 (log).
            /// The user can type 'exit' at any prompt to terminate the application.

            bool running = true;

            while (running)
            {
                Console.WriteLine("Please select operation (+, -, *, / , ^, %, sqrt, log or 'exit'):");
                string operation = Console.ReadLine()?.Trim().ToLower();
                if (operation == "exit")
                {
                    running = false;
                    Console.WriteLine("Exiting calculator.");
                    continue;
                }

                switch (operation)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "^":
                    case "%":
                        var numbers = GetTwoNumbers();
                        if (numbers.num1 == null || numbers.num2 == null)
                        {
                            running = false;
                            Console.WriteLine("Exiting calculator.");
                            continue;
                        }
                        double? num1 = numbers.num1;
                        double? num2 = numbers.num2;

                        switch (operation)
                        {
                            case "+":
                                Console.WriteLine($"Result: {num1 + num2}");
                                break;


                            case "-":

                                Console.WriteLine($"Result: {num1 - num2}");
                                break;


                            case "*":

                                Console.WriteLine($"Result: {num1 * num2}");
                                break;


                            case "/":

                                if (num2 == 0)
                                {
                                    Console.WriteLine("Error: Cannot divide by zero.");
                                }
                                else
                                {
                                    Console.WriteLine($"Result: {num1 / num2}");
                                }
                                break;


                            case "^":

                                Console.WriteLine($"Result: {Math.Pow(num1.Value, num2.Value)}");
                                break;

                            case "%":

                                if (num2 == 0)
                                {
                                    Console.WriteLine("Error: Cannot divide by zero for modulo.");
                                }
                                else
                                {
                                    Console.WriteLine($"Result: {num1 % num2}");
                                }
                                break;

                            case "exit":
                                running = false;
                                Console.WriteLine("Exiting calculator.");
                                break;


                            default:
                                Console.WriteLine("Invalid operation.");
                                break;
                        }
                        break;

                    case "log":
                    case "sqrt":
                        var number = GetoneNumber();
                        if (number == null)
                        {
                            running = false;
                            Console.WriteLine("Exiting calculator.");
                            continue;
                        }
                        double? num = number;
                        switch (operation)
                        {
                            case "sqrt":

                                if (num < 0)
                                {
                                    Console.WriteLine("Error: Cannot calculate square root of a negative number (in real numbers).");
                                }
                                else
                                {
                                    Console.WriteLine($"Result: {Math.Sqrt(num.Value)}");
                                }
                                break;

                            case "log":

                                if (num <= 0)
                                {
                                    Console.WriteLine("Error: Cannot calculate logarithm of a non-positive number.");
                                }
                                else
                                {
                                    Console.WriteLine($"Result: {Math.Log10(num.Value)}");
                                }
                                break;

                            case "exit":
                                running = false;
                                Console.WriteLine("Exiting calculator.");
                                break;


                            default:
                                Console.WriteLine("Invalid operation.");
                                break;
                        }
                        break;
                }
                Console.WriteLine();

            }


        }
        static double? GetValidNumber(string prompt)
        {
            double number;
            bool isValid;
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine().ToLower();
                if (input == "exit")
                {
                    return null;
                }

                isValid = double.TryParse(input, out number);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isValid);

            return number;
        }

        static (double? num1, double? num2) GetTwoNumbers()
        {
            double? num1 = GetValidNumber("Please enter first number:");
            if (num1 == null)
            {
                return (null, null); // اگر کاربر exit زد، هر دو مقدار null برمی‌گردونیم
            }

            double? num2 = GetValidNumber("Please enter second number:");
            if (num2 == null)
            {
                return (null, null); // اگر کاربر exit زد، هر دو مقدار null برمی‌گردونیم
            }

            return (num1, num2);
        }

        static double? GetoneNumber()
        {
            double? num1 = GetValidNumber("Please enter the number:");
            if (num1 == null)
            {
                return (null); // اگر کاربر exit زد، هر دو مقدار null برمی‌گردونیم
            }

            return (num1);
        }
    }
}




