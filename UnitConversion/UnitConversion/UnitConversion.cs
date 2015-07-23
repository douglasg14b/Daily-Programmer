using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/* Daily Challenge #173 Unit Calculator
 *  
 * 
 * 
 * 
 */


namespace UnitConversaionCalculator
{
    class ConvertUnits
    {
        static void Main()
        {
            string userInput;
            string[] splitUserInput;
            decimal inputUnitValue;
            decimal outputValue;


            Dictionary<string, decimal> length = new Dictionary<string, decimal>();
            length.Add("kilometers", 1M);
            length.Add("miles", 0.621371M);
            length.Add("meters", 1000M);
            length.Add("yards", 1093.61M);
            length.Add("inches", 39370.1M);
            length.Add("attoParsecs", 32407.7929M);

            Dictionary<string, decimal> weight = new Dictionary<string, decimal>();
            weight.Add("kilograms", 1M);
            weight.Add("pounds", 2.20462M);
            weight.Add("ounces", 35.274M);
            weight.Add("berylliumm-hogsheads", 0.00226757369M);

            //look into string.split
            do
            {
                Console.WriteLine("Please Enter Two Values You Want Converted \nIf you wish to exit at any time type \"exit\" ");
                userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                splitUserInput = userInput.Split(' ');

                //break the loop if user types exit
                if (userInput == "exit")
                {
                    break;
                }
                //Verify input has correct # of words
                if (splitUserInput.Length != 4)
                {
                    FailInput();
                    continue;
                }
                if (!decimal.TryParse(splitUserInput[0], out inputUnitValue) && splitUserInput[2] != "to")
                {
                    FailInput();
                    continue;
                }

                if (length.ContainsKey(splitUserInput[1]) && length.ContainsKey(splitUserInput[3]))
                {
                    outputValue = (inputUnitValue / length[splitUserInput[1]] * length[splitUserInput[3]]);
                    Console.WriteLine("{0} {1} is {2:##,###,###,###.#####0} {3}", inputUnitValue, splitUserInput[1], outputValue, splitUserInput[3]);
                    Console.ReadLine();

                }
                else if (weight.ContainsKey(splitUserInput[1]) && weight.ContainsKey(splitUserInput[3]))
                {
                    outputValue = (inputUnitValue / weight[splitUserInput[1]] * weight[splitUserInput[3]]);
                    Console.WriteLine("{0} {1} is {2} {3}", inputUnitValue, splitUserInput[1], outputValue, splitUserInput[3]);
                    Console.ReadLine();
                }
                else
                {
                    FailInput();
                    continue;
                }
                Thread.Sleep(100);
            }
            while (true);
        }
        //Method to write if user fails to input correctly.
        static void FailInput()
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter a valid combination of units to convert\n");
            Console.WriteLine("Units must be of the same type. ie. You cannot convert pounds into meters\n");
            Console.WriteLine("<number of units> <unit to convert from> <\"to\"> <unit to convert to>\n");
            Console.WriteLine("Example: 23 inches to miles\n");
            return;
        }
    }
}
/* What I Have Learned
 * 
 * Dictionaries
 * ContainsKey, a dictionary method
 * Using a break for the user to exit the program
 * stop using unecessary and redundant variables for everything
 * 
 * 
 */
