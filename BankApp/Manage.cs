using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankApp.Account;
using static BankApp.Customer;


namespace BankApp
{
    class Manage
    {
        //Runs if Case1 is selected from the Menu
        public static void Search()
        {
            Console.WriteLine("* Sök kund *");
            Console.Write("Namn eller postort? ");
            string input = Console.ReadLine();
            bool exist = false;

            //Iterates through the Customer list properties and check 
            //if the input matches any company name or city
            foreach (var customer in customers.Where(x => x.Företagsnamn.ToUpper().Contains(input.ToUpper()) 
                                                        || x.Stad.ToUpper().Contains(input.ToUpper())))
            {
                Console.WriteLine($"{customer.Kundnummer}: {customer.Företagsnamn}");
                exist = true;
            }
            if (exist == false)
            {
                Console.WriteLine("Fann inga kunder");
            }
        }

        //Runs if Case2 is selected from the Menu
        public static void CustomerImage()
        {
            Console.WriteLine("* Visa kundbild *");
            Console.Write("Kundnummer? ");
            int inputId;
            decimal sumSaldo = 0;

            if (!int.TryParse(Console.ReadLine(), out inputId))
            {
                Console.WriteLine("Var vänlig och ange kundnummer i siffror.");
            }
            else
            {
                //Check if account number was given. If it is then take the index of the 
                //account number and check that same index customerID. Save the customerID
                //to inputId variable.
                if (accounts.Exists(x => x.Kontonummer == inputId.ToString()))
                {
                    int index1 = accounts.FindIndex(i => i.Kontonummer == inputId.ToString());
                    inputId = int.Parse(accounts[index1].Kundnummer);
                }
                try
                {
                    int index = customers.FindIndex(i => i.Kundnummer == inputId.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Kundnummer: " + customers[index].Kundnummer);
                    Console.WriteLine("Organisationsnummer: " + customers[index].Organisationsnummer);
                    Console.WriteLine("Företagsnamn: " + customers[index].Företagsnamn);
                    Console.WriteLine("Adress: " + customers[index].Adress);
                    Console.WriteLine("Stad: " + customers[index].Stad);
                    Console.WriteLine("Region: " + customers[index].Region);
                    Console.WriteLine("Postnummer: " + customers[index].Postnummer);
                    Console.WriteLine("Land: " + customers[index].Land);
                    Console.WriteLine("Telefonnummer: " + customers[index].Telefonnummer);
                    Console.WriteLine();
                    Console.WriteLine("Konton");
                    //Check for matching CustomerID input in Account list 
                    foreach (var account in accounts.Where(x => x.Kundnummer == inputId.ToString()))
                    {
                        Console.WriteLine($"{account.Kontonummer}: {account.Saldo}");
                        sumSaldo += account.Saldo;
                    }
                    Console.WriteLine($"Totala Saldo: {sumSaldo}");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Angivna Kundnummer eller kontonummer finns inte");
                }
            }
        }
    }
}
