using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soda_Purchase_Exercise
{
    class SodaExcercise
    {
        // Global Variable Declarations
        private static double accountBal = 0;
        private static double accTempHold;
        private static string depositText;


        static void Main()
        {
            bool askPurchase = true;
            string userInput;
            int returnValue = 0;
            Deposit();
            while (askPurchase)
            {
                Console.Write("Would you like to make a purchase? (y/n)");
                userInput = Console.ReadLine();
                returnValue = CheckYesNo(userInput);
                if (returnValue == 1)
                {
                    Purchase();
                    askPurchase = false;
                }
                else if (returnValue == 2)
                {
                    Console.WriteLine("Sad, no purchase :(");
                }
                else if (returnValue == 3)
                {
                    Console.WriteLine("woops?" + Environment.NewLine);
                }
            }
            Console.ReadLine();
        }

        // Deposit function
        static void Deposit()
        {
            bool properInput = false;

            while (properInput == false)
            {
                Console.Write("Please Enter a Deposit Amount, " + Environment.NewLine + "If you do not wish to make a deposit enter \"0\" " + Environment.NewLine);
                depositText = Console.ReadLine();

                if (double.TryParse(depositText, out accTempHold))
                {
                    accountBal = accountBal + accTempHold;
                    Console.WriteLine(Environment.NewLine + "Thank you for your deposit of $" + depositText + Environment.NewLine);
                    Console.WriteLine("Your Current Balance Is: $" + accountBal + Environment.NewLine);
                    depositText = String.Empty;
                    properInput = true;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Numerical Value");
                    properInput = false;
                }

            }
        }

        //Check Balance function
        static void CheckBal(int type)
        {
            string userInput;
            bool properInput = false;
            int yesNoReturn;
            while (properInput == false)
            {
                if (type == 1)
                {
                    Console.Write("Would You Like To Check Your Balance? (y/n)");
                    userInput = Console.ReadLine();
                    yesNoReturn = CheckYesNo(userInput);
                    if (yesNoReturn == 1)
                    {
                        Console.WriteLine("Current Balance: $" + accountBal);
                        properInput = true;
                        return;
                    }
                    else if (yesNoReturn == 2)
                    {
                        return;
                    }
                    else
                    {
                        properInput = false;
                    }
                }
                else
                {
                    Console.WriteLine("Current Balance: $" + accountBal);
                    return;
                }
            }
        }

        //Purchase Function
        static void Purchase()
        {
            string sSelection;
            string userInput;
            int yesNoRetun;
            int selection;
            bool properInput = false;
            bool makePurchase = true;
            String[] itemList = { "Pepsi", "Sprite", "Coke", "Redbull" };
            int[] priceList = { 5, 3, 2, 8 };

            while (properInput == false || makePurchase == true)
            {
                Console.WriteLine(Environment.NewLine + "Here is a list of items for purchase. Please make your selection" + Environment.NewLine);
                //For loop used to count items in array instead of ForEach
                for (int i = 0; i < (itemList.Length); i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] " + "$" + priceList[i] + " " + itemList[i]);
                }

                sSelection = Console.ReadLine();
                //Parse selection and check if selection is valid
                if (int.TryParse(sSelection, out selection) && (selection - 1) < itemList.Length)
                {
                    //Check If User Has Funds for Purchase
                    if (accountBal >= priceList[selection - 1])
                    {
                        //Write what user purchased
                        Console.WriteLine("You Purchased 1 " + itemList[selection - 1] + " for $" + priceList[selection - 1]);
                        //subtract from Account Balance
                        accountBal = accountBal - priceList[selection - 1];
                        CheckBal(2);
                        Console.WriteLine("Would you like to make another purchase? (y/n)");
                        userInput = Console.ReadLine();
                        yesNoRetun = CheckYesNo(userInput);

                        if (yesNoRetun == 1)
                        {
                            makePurchase = true;
                        }
                        else if (yesNoRetun == 2)
                        {
                            Console.WriteLine("You no longer wish to purchase any products");
                            Console.WriteLine(Environment.NewLine + "You will be refunded your current account balance of: $" + accountBal);
                            properInput = true;
                            makePurchase = false;
                            return;
                        }
                        properInput = true;
                    }
                    // If funds are not available for purchase
                    else
                    {
                        Console.WriteLine("You do not have the funds to purchase this item" + Environment.NewLine);
                        Console.WriteLine(itemList[selection - 1] + " costs $" + priceList[selection - 1] + ". " + "Current Balance: $" + accountBal);
                        Console.WriteLine(Environment.NewLine + "Would You Like to Make to Make a Deposit? (y/n)");
                        userInput = Console.ReadLine();
                        yesNoRetun = CheckYesNo(userInput);
                        if (yesNoRetun == 1)
                        {
                            Deposit();
                            makePurchase = true;

                        }
                        else if (yesNoRetun == 2)
                        {
                            Console.WriteLine(Environment.NewLine + "You no longer have the funds to purchase any products");
                            Console.WriteLine(Environment.NewLine + "You will be refunded your current account balance of: $" + accountBal);
                            makePurchase = false;
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a valid selection number.");
                    properInput = false;
                }
            }
        }

        //YesNo Check Function
        static int CheckYesNo(string userInput)
        {
            //Yes == 1  No ==2  Fail ==3
            userInput = userInput.ToLower();
            if (userInput == "y" || userInput == "n")
            {
                if (userInput == "y")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                Console.WriteLine("Please Enter 'y' for Yes or 'n' for No.");
                return 3;
            }
        }
    }

    /* *****WHAT I LEARNED*****
     * "var[]" arrays
     * "var.Length" for the length in items of the array
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
}

