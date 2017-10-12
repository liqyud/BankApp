using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting;

namespace BankApp
{
    class BankDataFile
    {
        private static string bankDataPath = @"C:\Dev\PROG17\BankApp\BankApp\bankdata.txt";

        //information of customer and accounts added to the list from text file
        public static List<string> customersInFile = new List<string>();
        public static List<string> accountsInFile = new List<string>();

        //List of customers and accounts which is to be added into new textfile
        public static List<string> customersToFile = new List<string>();
        public static List<string> accountsToFile = new List<string>();


        //reading each row of text from bankdata.txt file
        public static void ReadBankData()
        {
            StreamReader reader = new StreamReader(bankDataPath);

            //Reads the first line where the total numbers of Customers is written
            //Converting that line into int to be used in the for loop,
            //in the for loop it iterares through the text file collecting all the Customers
            //untill it as collected the total amount of customers in the text file
            string lineCustomers = reader.ReadLine();
            int totalCustomers = int.Parse(lineCustomers);
            for (int i = 0; i < totalCustomers; i++)
            {
                lineCustomers = reader.ReadLine();
                customersInFile.Add(lineCustomers);
            }

            //Reads the next line where the total numbers of Accounts is written
            //Converting that line into int to be used in the for loop,
            //in the for loop it iterares through the text file collecting all the accounts.
            string lineAccounts = reader.ReadLine();
            int totalAccounts = int.Parse(lineAccounts);
            for (int i = 0; i < totalAccounts; i++)
            {
                lineAccounts = reader.ReadLine();
                accountsInFile.Add(lineAccounts);
            }

            reader.Close();
        }


        //Writing down all the customers and accounts into a new text file.
        public static void WriteBankData()
        {
            //Updated text files name with the current date having the format "ååååmmdd-ttmm.txt"
            string fileName = DateTime.Now.ToString("yyyyMMdd - HHmm") + ".txt";
            Console.WriteLine($"Sparar till {fileName}...");
            StreamWriter writer = new StreamWriter(fileName);

            //Write the total customer in the first line
            //and then print out all the customers in the updated text file
            writer.WriteLine(customersToFile.Count);
            foreach (var customerLine in customersToFile)
            {
                writer.WriteLine(customerLine);    
            }

            //Write the total accounts in the next line after the last customer
            //and then print out all the accounts in the updated text file
            writer.WriteLine(accountsToFile.Count);
            foreach (var accountLine in accountsToFile)
            {
                writer.WriteLine(accountLine);
            }

            writer.Close();
        }
    }
}