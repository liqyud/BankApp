using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class TextHandler
    {
        //Method to split the information after every semicolon, retrieved from the text file. 
        public static void SplitSemicolon()
        {
            //Customer split
            foreach (var customer in BankDataFile.customersInFile)
            {
                string[] customerInfo = customer.Split(';');

                Customer customerInList = new Customer(
                    customerInfo[0], customerInfo[1], customerInfo[2], customerInfo[3], customerInfo[4],
                    customerInfo[5], customerInfo[6], customerInfo[7], customerInfo[8]);
                Customer.customers.Add(customerInList);
            }

            //Account split
            foreach (var account in BankDataFile.accountsInFile)
            {
                string[] accountInfo = account.Split(';');

                Account accountInList = new Account(accountInfo[0], accountInfo[1], accountInfo[2]);
                Account.accounts.Add(accountInList);
            }
        }

        //Method to unite the information with Semicolon
        public static void UniteWithSemicolon()
        {
            foreach (var customer in Customer.customers)
            {
                BankDataFile.customersToFile.Add($"{customer.Kundnummer};{customer.Organisationsnummer};{customer.Företagsnamn};" +
                                                 $"{customer.Adress};{customer.Stad};{customer.Region};{customer.Postnummer};" +
                                                 $"{customer.Land};{customer.Telefonnummer}");

            }

            foreach (var account in Account.accounts)
            {
                BankDataFile.accountsToFile.Add($"{account.Kontonummer};{account.Kundnummer};{account.Saldo}");
            }
        }
    }
}
