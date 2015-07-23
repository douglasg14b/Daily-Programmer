using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Find Next Prime Exercise
 * Quite Messy, could really use some optimization
 * Incomplete
 */

namespace FindNextPrime
{
    class FindNextPrime
    {
        static void Main()
        {
            long[] pArray;
            long[] primeArray;
            string userInput;
            string userChoice;
            int userInputNumber;
            bool foundPrime = false;
            
            Console.WriteLine("Would you like the next prime of the \"n\"th prime? (next or nth)" );
            userChoice = Console.ReadLine();
           
            
            Console.WriteLine("Please enter a number, and I will give you the next prime");
            userInput = Console.ReadLine();
            userInputNumber = int.Parse(userInput);

            pArray = GeneratePrimeArray(userInputNumber);
            primeArray = primesArray(pArray);


            if (userChoice == "next")
            {
                int i = userInputNumber;
                while(foundPrime == false)
                {
                    if(pArray[i] !=0 && pArray[i] != userInputNumber)
                    {
                        Console.Clear();
                        Console.WriteLine("Next Prime After {0} is: {1}", userInputNumber, pArray[i]);
                        foundPrime = true;
                    }
                    i++;
                }
            }
            else if (userChoice == "nth")
            {
                Console.Clear();
                Console.WriteLine("Prime #{0} is: {1}", userInputNumber, primeArray[userInputNumber]);
            }
           Console.ReadLine();
        }
        
        static long[] GeneratePrimeArray(int userInputNumber)
        {
            long[] parray = new long[10000000]; //10,000,000
            long[] primeArray = new long[10000000];
            int checker;
            long nextprime = 1;
            long next;
            int change = 1;
            int primeIndex = 1;
            bool arrayDone = false;


            //Generate Array
            for (long i = 1; i < parray.Length; i++)
            {
                parray[i] = i;
            }

            //NextPrime Loop
            for (long index1 = 0; change == 1; index1++)
            {
                change = 0;
                checker = 0;
                //Search through array to find next prime as long as the check is 0
                for (next = nextprime; checker == 0; next++)
                {
                    if (parray[next] != 0 && parray[next] != nextprime)
                    {
                        nextprime = parray[next];
                        checker = 1;
                        break;
                    }
                }
                //Erase all multiples of "nextprime" in parray till the array is exausted
                for (long index2 = nextprime; index2 < parray.Length; index2 += nextprime)
                {
                    if (parray[index2] != 0 && parray[index2] != nextprime)
                    {
                        parray[index2] = 0;
                        change = 1;
                    }
                }
            }
            

            return parray;
        }
        static long[] primesArray(long[] parray)
        {
            long index3 = 1;
            long[] primeArray = new long[10000000];
            int primeIndex = 1;
            bool arrayDone = false;


            while (arrayDone == false && index3 < 10000000 && primeIndex < 10000000)
            {
                if (parray[index3] != 0)
                {
                    primeArray[primeIndex] = parray[index3];
                    primeIndex++;
                }
                index3++;
            }
            return primeArray;
        }
    }
}