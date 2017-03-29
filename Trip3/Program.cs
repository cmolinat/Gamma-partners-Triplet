using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trip3
{
    class Program
    {
        static void Main(string[] args)
        {

            Triplet trip = new Triplet { exit = false, intToEvaluate = 0 };
            if (trip.initializeArray())
            {
                if (trip.fillArray())
                {
                    trip.getNumberToEvaluate();
                    if (trip.intToEvaluate > 0)
                    {
                        if (trip.findTriplet())
                        {
                            Console.WriteLine(trip.message);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("triplet not found for " + trip.intToEvaluate + " , press Enter key to exit.");
                            Console.ReadLine();
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }

    public class Triplet
    {
        //prop
        public int[] a { get; set; }
        public int intToEvaluate { get; set; }
        public bool exit { get; set; }
        public string message { get; set; }
        //methods
        /// <summary>Initializes array a[int]     
        /// </summary>
        public bool initializeArray()
        {
            bool isValid = false;
            while (!exit)
            {
                Console.WriteLine("Enter number of items for array ,q for exit:");
                var x = Console.ReadLine();
                if (this.ValidateInput(x))
                {
                    this.a = new int[Convert.ToInt32(x)];
                    isValid = this.ValidateArrayLenght();

                }
            }
            return isValid;
        }
        /// <summary>Fills each position on the array a[int]   
        /// </summary>
        public bool fillArray()
        {
            int count = 0;
            exit = false;

            while ((count <= a.Length - 1) && (exit == false))
            {
                Console.WriteLine("Enter number {0} ,q for exit:", count + 1);
                var x = Console.ReadLine();
                if (this.ValidateInput(x))
                {
                    if (this.validateArrayItem(Convert.ToInt32(x)))
                    {
                        a[count] = Convert.ToInt32(x);
                        count++;
                    }
                }
            }
            if (count == a.Length)
            {
                return true;
            }
            else return false;
        }
        /// <summary>Sets a.IntToEvaluate to a non negative int     
        /// </summary>
        public void getNumberToEvaluate()
        {
            while (this.intToEvaluate < 1 && exit == false)
            {
                Console.WriteLine("Enter number to evaluate,  q for exit:");
                var x = Console.ReadLine();
                if (this.ValidateInput(x))
                {
                    int toEval = Convert.ToInt32(x);
                    if (this.validateArrayItem(toEval))
                    {
                        this.intToEvaluate = toEval;
                    }
                }
            }
        }
        /// <summary>Search for a triplet in a[int] that matches a.intToEvaluate   
        /// </summary>
        public bool findTriplet()
        {
            Array.Sort(this.a);
            int z, y;
            for (int i = 0; i < this.a.Length; i++)
            {
                z = i + 1;
                y = this.a.Length - 1;
                while (z < y)
                {
                    if (this.a[i] + this.a[z] + this.a[y] == this.intToEvaluate)
                    {
                        this.message = "Found: " + this.intToEvaluate + " = + " + this.a[i] + "+ " + this.a[z] + " + " + this.a[y] + "";
                        return true;
                    }
                    if (this.a[i] + this.a[z] + this.a[y] < this.intToEvaluate)
                    {
                        z++;
                    }
                    else
                    {
                        y--;
                    }
                }
            }
            return false;
        }
    }



    public static class Validator
    {
        public static bool valid = true;
        public static string Message;
        /// <summary>Validates input for each array item, rules: x > 0 , x<= 3000.      
        /// </summary>
        public static bool validateArrayItem(this Triplet trip, int x)
        {
            if (x < 1 || x > 3000)
            {
                valid = false;
                Message = "Number must be greater than 1 and less than 3000, try again:";
            }

            Console.WriteLine(Message);
            return valid;
        }
        /// <summary>Validates array lenght, rules: x >=3 , x<= 1000.      
        /// </summary>
        public static bool ValidateArrayLenght(this Triplet triplet)
        {

            if (triplet.a.Length < 3)
            {
                Message = "Array lenght can't be less than 3 numbers";
                valid = false;

            }
            else if (triplet.a.Length > 1000)
            {
                Message = "Array lenght can't be greater than 1000 numbers";
                valid = false;
            }
            else
            {
                Message = "";
                valid = true;
                triplet.exit = true;

            }
            Console.WriteLine(Message);
            return valid;
        }
        /// <summary>Validates input for each value entered, rules: x must be a non negative int, x>0, || x==q then exit.      
        /// </summary>
        public static bool ValidateInput(this Triplet triplet, string input)
        {

            if (input == "q")
            {
                Message = "press enter key to exit";
                triplet.exit = true;
                valid = false;
            }
            else if ((Regex.IsMatch(input, @"^[1-9]|[0-9]{2,}$")))
            {

                Message = "";
                valid = true;
            }
            else
            {
                Message = "Only numbers greater than cero allowed.";
                valid = false;
            }



            Console.WriteLine(Message);
            return valid;
        }
    }
}
