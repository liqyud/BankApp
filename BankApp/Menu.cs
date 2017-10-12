using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankApp.Balance;
using static BankApp.BankDataFile;
using static BankApp.Manage;
using static BankApp.CreateDelete;

namespace BankApp
{
    class Menu
    {
        static Bank bank = new Bank();
        
        //Menu printed as text in console
        public static void MenuAsText()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("* VÄLKOMMEN TILL BANKAPP 1.0 *");
            Console.WriteLine("******************************");
            Console.WriteLine();
            Console.WriteLine("Läser in bankdata.txt...");
            Console.WriteLine("Antal kunder: " + customersInFile.Count);
            Console.WriteLine("Antal konton: " + accountsInFile.Count);
            Console.WriteLine("Totalt saldo: " + TotalBalance());
            Console.WriteLine();
            Console.WriteLine("HUVUDMENY");
            Console.WriteLine("0) Avsluta och spara");
            Console.WriteLine("1) Sök kund");
            Console.WriteLine("2) Visa kundbild");
            Console.WriteLine("3) Skapa kund");
            Console.WriteLine("4) Ta bort kund");
            Console.WriteLine("5) Skapa konto");
            Console.WriteLine("6) Ta bort konto");
            Console.WriteLine("7) Insättning");
            Console.WriteLine("8) Uttag");
            Console.WriteLine("9) Överföring");
        }

        //Method to run the selected case from the users input
        public static void MenuSwitch()
        {
            //Console.Clear();
            bool bankAppOn = true;
            do
            {
                Console.WriteLine();
                Console.Write("> ");
                string menuCase = Console.ReadLine();

                switch (menuCase)
                {
                    case "0": //Avsluta och spara
                        bank.EndSession();
                        bankAppOn = false;
                        break;
                    case "1": //Sök kund
                        Search();
                        break;
                    case "2": //Visa kundbild
                        CustomerImage();
                        break;
                    case "3": //Skapa kund
                        CreateCustomer();
                        break;
                    case "4": //Ta bort kund
                        DeleteCustomer();
                        break;
                    case "5": //Skapa konto
                        CreateAccount();
                        break;
                    case "6": //Ta bort konto
                        DeleteAccount();
                        break;
                    case "7": //Insättning
                        DepositCase();
                        break;
                    case "8": //Uttag
                        WithdrawCase();
                        break;
                    case "9": //Överföring
                        Transfer();
                        break;
                    default:
                        Console.WriteLine("Mata in en siffra (0-9).");
                        break;
                }
            } while (bankAppOn);
        }
    }
}
