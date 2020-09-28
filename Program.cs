using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // declares the variable for the amount of numbers that should be generated
            int[] aiNumbers = new int[] { };
            
            // declares the variable for the typed in amount
            int iAmountNumbers;
            
            Console.WriteLine("This program generates a list of random numbers and sort them in a decending order.");
            
            randomOrNot();
            sortList();
            displaySortedList();

            // converts the typed in number to an int, saves it into an int variable and reinitializes the array with it
            void typedAmountNumber()
            {
                // saves the typed in number to the variable and converts it to a int
                iAmountNumbers = Convert.ToInt32(Console.ReadLine());
                // reinitializes the array that is has a range/index of the typed in number
                aiNumbers = new int[iAmountNumbers];
            }

            // asks the user if the number should be randomly generated or typed in
            void randomOrNot()
            {
                Console.WriteLine("Should the numbers be random?");

                // saves the typed in answer into a string
                string sRandomNumberAnswer = Console.ReadLine();

                // if the typed in answer was yes then it will be asked how many numbers to generate
                if (sRandomNumberAnswer == "yes")
                {
                    Console.WriteLine("How many numbers would you like to generate?");
                    typedAmountNumber();
                    generateRandomNumbers();
                    sortList();
                }
                else if (sRandomNumberAnswer == "no")
                {
                    Console.WriteLine("Please type in the amount of numbers you want to add.");
                    typedAmountNumber();

                    Console.WriteLine("Type in the numbers you would like to add.");
                    for (int i = 0; i < aiNumbers.Length; i++)
                    {
                        aiNumbers[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
               
                else
                {
                    Console.WriteLine("\nPlease type in 'Yes' or 'No'");
                    randomOrNot();
                }

            }

            // generates random numbers, amount and the range of it can be typed in
            void generateRandomNumbers()
            {
                // saved into a variable cause it's a class and needs to be initialized
                var rnd = new Random();
                
                int iFromNumber;
                int iToNumber;
                
                Console.WriteLine("\nWhich range do you want to declare?");
                
                Console.WriteLine("Type in the number thats the lowest in this range.");
                iFromNumber =Convert.ToInt32( Console.ReadLine() );
                
                Console.WriteLine("And now the highest number of that range.");
                iToNumber = Convert.ToInt32(Console.ReadLine() );

                // if the lowest number is equal or bigger than the highest number in the range then there will
                // be a warning about it and the method will be run again
                if (iFromNumber >= iToNumber)
                {
                    Console.WriteLine("The lowest number of the range must be lower than the highest one.");
                    generateRandomNumbers();
                }
                else
                {
                    // fills the array with a random number between the typed in ones
                    for (int i = 0; i < aiNumbers.Length; i++)
                    {
                        aiNumbers[i] = rnd.Next(iFromNumber, iToNumber);
                    }
                }

            }
            

            // sorts the array with a simple bubble sort algorythm, the loop will run two times
            void sortList()
            {
                bool swapped = false;
                do
                {
                    swapped = false;
                    for (int a = 0; a < aiNumbers.Length - 1; a++)
                    {
                        /*
                         if the current value of the array is bigger than the next one than 
                         the current number will be swapped with the next one
                        */
                        if (aiNumbers[a] > aiNumbers[a + 1])
                        {
                            int num1 = aiNumbers[a];
                            int num2 = aiNumbers[a + 1];

                            aiNumbers[a] = num2;
                            aiNumbers[a + 1] = num1;

                            swapped = true;
                        }
                    }
                } while (swapped);
            }
            
            
            // displays the array
            void displaySortedList()
            {
                Console.WriteLine("\nSorted numbers:\n");
                
                // finally writes the values of the array into the console
                for (int i = 0; i < aiNumbers.Length; i++)
                {
                    Console.WriteLine(aiNumbers[i]);
                }

                // that the console doesn't close immediately, needs a bottom prompt to close it
                Console.ReadLine();
            }
        }
    }
}
