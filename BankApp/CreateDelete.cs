using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankApp.Account;
using static BankApp.Customer;

namespace BankApp
{
    class CreateDelete
    {
        //Case3
        public static void CreateCustomer()
        {
            Console.WriteLine("* Skapa Kund *");
            Console.Write("Organisationsnummer? ");
            string org = Console.ReadLine();
            Console.Write("Företagsnamn? ");
            string företag = Console.ReadLine();
            Console.Write("Adress? ");
            string adress = Console.ReadLine();
            Console.Write("Stad? ");
            string stad = Console.ReadLine();
            Console.Write("Region? ");
            string region = Console.ReadLine();
            Console.Write("Postnummer? ");
            string post = Console.ReadLine();
            Console.Write("Land? ");
            string land = Console.ReadLine();
            Console.Write("Telefonnummer? ");
            string tele = Console.ReadLine();
            if (org == String.Empty || företag == String.Empty || adress == String.Empty || stad == String.Empty || post == String.Empty)
            {
                Console.WriteLine("En kund måste ha ett kundnummer, namn, organisationsnummer, adress, postnummer och postort");
            }
            else
            {
                int lastIndexC = customers.Count - 1;
                int customerNumber = int.Parse(customers[lastIndexC].Kundnummer) + 1;
                customers.Add(new Customer(customerNumber.ToString(), org, företag, adress,
                    stad, region, post, land, tele));
                Console.WriteLine($"Kund {customerNumber} har skapats.");

                int lastIndexA = accounts.Count - 1;
                int accountNumber = int.Parse(accounts[lastIndexA].Kontonummer) + 1;
                accounts.Add(new Account(accountNumber.ToString(), customerNumber.ToString(), "0.00"));
                Console.WriteLine($"kontot {accountNumber} har skapats till kund {customerNumber}");
            }
        }
        
        //Case4
        public static void DeleteCustomer()
        {
            Console.WriteLine("* Ta bort kund *");
            Console.Write("Kundnummer? ");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Var vänlig och ange kundnummer i siffror.");
            }
            else if (!accounts.Exists(x => x.Kundnummer == input.ToString()))
            {
                //Find the index of the customer to be deleted
                int index = customers.FindIndex(i => i.Kundnummer == input.ToString());
                Console.WriteLine($"Kunden {customers[index].Kundnummer} har tagits bort.");
                customers.Remove(customers[index]);
            }
            else if (accounts.Exists(x => x.Kundnummer == input.ToString()))
            {
                Console.WriteLine("Kunden har konto och kan därför inte tas bort!");
            }
            else
            {
                Console.WriteLine("Fann inte den inmatade kundnumret");
            }
        }

        //Case5
        public static void CreateAccount()
        {
            Console.WriteLine("* Skapa konto *");
            Console.Write("Skapa konto till kundnummer? ");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Var vänlig och ange kundnummer i siffror.");
            }
            else if (customers.Exists(x => x.Kundnummer == input.ToString()))
            {
                int lastIndex = accounts.Count - 1;
                int accountNumber = int.Parse(accounts[lastIndex].Kontonummer) + 1;
                accounts.Add(new Account(accountNumber.ToString(), input.ToString(), "0.00"));
                Console.WriteLine($"kontot {accountNumber} har skapats till kund {input}");
            }
            else
            {
                Console.WriteLine("Fann inte den inmatade kundnumret");
            }
        }

        //Case6
        public static void DeleteAccount()
        {
            Console.WriteLine("* Ta bort konto *");
            Console.Write("Kontonummer? ");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Var vänlig och ange kontonummer i siffror.");
            }
            else if (accounts.Exists(x => x.Kontonummer == input.ToString()))
            {
                int index = accounts.FindIndex(i => i.Kontonummer == input.ToString());
                if (accounts[index].Saldo == 0.0m)
                {
                    Console.WriteLine($"konto {accounts[index].Kontonummer} har tagit bort");
                    accounts.Remove(accounts[index]);
                }
                else
                {
                    Console.WriteLine("Konton måste vara tom på saldo för att kunnas ta bort");
                }
            }
            else
            {
                Console.WriteLine("Fann inte den inmatade kontonummret");
            }
        }
    }
}
