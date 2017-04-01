using Trademe.Parcel.Utilities;
using System;

namespace Trademe.Parcel.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userWantsToExit = false;

    
            while (!userWantsToExit)
            {
                System.Console.Clear();
                try
                {
                    System.Console.WriteLine("Welcome to TRADEME Parcel Parser");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("Enter the dimensions of your parcel...");

                    System.Console.WriteLine("");
                    System.Console.WriteLine("What is the parcel's length in centimeters?");
                    string length = System.Console.ReadLine();

                    System.Console.WriteLine("");
                    System.Console.WriteLine("What is the parcel's breadth in centimeters?");
                    string breadth = System.Console.ReadLine();

                    System.Console.WriteLine("");
                    System.Console.WriteLine("What is the parcel's height in centimeters?");
                    string height = System.Console.ReadLine();

                    System.Console.WriteLine("");
                    System.Console.WriteLine("What is the parcel's weight in kilograms?");
                    string weight = System.Console.ReadLine();
                    System.Console.WriteLine("");

                    var dimensions = new Dimensions(
                        Convert.ToDouble(length),
                        Convert.ToDouble(breadth),
                        Convert.ToDouble(height),
                        Convert.ToDouble(weight));

                    var parcel = new Manager.Parcel(dimensions);
                    if (parcel.PackagingSolution != null)
                    {
                        System.Console.Write($"Your parcel is {parcel.PackagingSolution.Size.ToString()} and the shipping cost for your parcel is ${parcel.PackagingSolution.Cost}");
                        System.Console.WriteLine("");
                    }
                    else
                    {
                        System.Console.WriteLine("No packaging solution could be calculated for your parcel!");
                        System.Console.WriteLine("");
                    }
                    System.Console.ReadLine();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"An error occurred, please try again - {ex.Message}");
                    System.Console.WriteLine("");
                    System.Console.ReadLine();
                }
                System.Console.WriteLine("Do you want to exit? Y/N");
                string done = System.Console.ReadLine();

                if (done.ToUpper() == "Y")
                    userWantsToExit = true;
            }
        }
    }
}
