using System;
using System.Collections.Generic;
using System.Linq;

namespace FractionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAllUnitTests();
            Console.ReadLine();
        }

        #region Test

        public static void RunAllUnitTests()
        {
            var inputStrings = new[]
            {
                "1/2 * 3_3/4",
                "2_3/8 + 9/8",
                "2_3/8   +     9/8",
                "7/2 * 111",
                "10/6 + 21/23",
                "1/3 + 1/5",
                "4/5 - 1/5",
                "1/4 / 1/2",
                "-1/4 + 5/4",
                "-1/3 - 1/3",
                "1/0 - 2/4",
                "1/3 / 0/4",
            };

            foreach (var input in inputStrings)
            {
                RunUnitTest(input);
            }
        }

        private static void RunUnitTest(string input)
        {
            List<string> listofInput = input.Split(' ').ToList();
            listofInput = listofInput.Where(item => !string.IsNullOrWhiteSpace(item)).Distinct().ToList();

            Fraction x = ConvertMixedToImproperFraction(listofInput[0]);
            var _operator = listofInput[1];
            Fraction y = ConvertMixedToImproperFraction(listofInput[2]);

            switch (_operator)
            {
                case "+":
                    Console.WriteLine("Result of {0} = {1}", input, x.Add(y).Reduced());
                    break;
                case "-":
                    Console.WriteLine("Result of {0} = {1}", input, x.Subtract(y).Reduced());
                    break;
                case "/":
                    if (y.Equal(new Fraction(0)))
                        Console.WriteLine("Divide by Zero 0 is not allowed!!!");
                    else
                        Console.WriteLine("Result of {0} = {1}", input, x.DividedBy(y).Reduced());
                    break;
                case "*":
                    Console.WriteLine("Result of {0} = {1}", input, x.Multiply(y).Reduced());
                    break;
                case "x":
                    Console.WriteLine("Result of {0} = {1}", input, x.Multiply(y).Reduced());
                    break;
            }
        }

        #endregion

        #region Utility
        private static Fraction ConvertMixedToImproperFraction(string s)
        {
            if (!s.Contains("_"))
            {
                return StringToFraction(s);
            }

            int wholeNumber = Convert.ToInt32(s.Substring(0, s.IndexOf("_")));
            int numerator = Convert.ToInt32(s.Substring(s.IndexOf("_") + 1, s.IndexOf("/") - s.IndexOf("_") - 1));
            int denominator = Convert.ToInt32(s.Substring(s.IndexOf("/") + 1));

            return new Fraction(denominator * wholeNumber + numerator, denominator);
        }

        static Fraction StringToFraction(string str)
        {
            string[] split = str.Split(new char[] { ' ', '/' });

            if (split.Length == 1)
                return new Fraction(Convert.ToInt32(split[0]));

            if (split.Length == 2)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return new Fraction(a, b);
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");
        }


        #endregion

    }
}
