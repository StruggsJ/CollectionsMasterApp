using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            
            int[] array = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50

            Populater(array);


            //TODO: Print the first number of the array

            Console.WriteLine($"Your first number is {array[0]}.");

            //TODO: Print the last number of the array            

            Console.WriteLine($"Your last number is {array[array.Length - 1]}");
            Console.WriteLine("");

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(array);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");

            Array.Reverse(array);
            NumberPrinter(array);

            Console.WriteLine("---------REVERSE CUSTOM------------");

            ReverseArray(array);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(array);
            NumberPrinter(array);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            
            Array.Sort(array);
            NumberPrinter(array);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            
            List<int> list = new List<int>();

            //TODO: Print the capacity of the list to the console

            Console.WriteLine($"The list can currently hold {list.Capacity} integers.");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
      
            Populater(list);

            //TODO: Print the new capacity

            Console.WriteLine($"The new capacity of the list is now {list.Capacity} integers.");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!

            Console.WriteLine("What number will you search for in the number list?");
            bool validNumber = Int32.TryParse(Console.ReadLine(), out int numLookUp);

            while (!validNumber)
            {
                Console.WriteLine("Please enter a valid number to search for in the list:");
                validNumber = Int32.TryParse(Console.ReadLine(), out numLookUp);
                
            }

            NumberChecker(list, numLookUp);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            
            NumberPrinter(list);
            
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            
            OddKiller(list);
            NumberPrinter(list);

            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");

            list.Sort();
            NumberPrinter(list);

            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            
            int[] newArray = list.ToArray();

            //TODO: Clear the list

            list.Clear();
            Console.WriteLine("List cleared. Here are the current numbers in the list now:");
            NumberPrinter(list);

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            for (int i = numberList.Count-1; i >= 0 ; i--) //Use instead of int i = 0; i < numberList.Count; i++ because the numbers' index number within the array will shift if started from the beginning.
            {
                if (numberList[i] % 2 != 0)
                {
                    numberList.Remove(numberList[i]); 
                }
            }


        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            bool foundNumber = false;

            foreach (var item in numberList)
            {   

                if (item == searchNumber)
                {
                    Console.WriteLine($"{searchNumber} is in the list.");
                    foundNumber = true;
                    break;
                }
                
            }

            if (foundNumber == false)
            {
                Console.WriteLine($"{searchNumber} is not in the list.");
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();

            for (int index = 0; index < 50; index++)
            {
                int randomNumber = rng.Next(0, 51);
                numberList.Add(randomNumber);
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();

            for(int index = 0; index < numbers.Length; index++)
            {
                int randomNumber = rng.Next(0, 51);
                numbers[index] = randomNumber;
            }
        }        

        private static void ReverseArray(int[] array)
        {
            int[] newArray = new int[array.Length];
            int index = 0;

            for(int i = array.Length - 1; i >= 0; i--)
            {
                newArray[index] = array[i];
                index++;
            }
            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
