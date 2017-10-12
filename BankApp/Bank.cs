using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Bank
    {
        //Starts the BankApp
        public void StartBankApp()
        {
            BankDataFile.ReadBankData();
            Semicolon.SplitSemicolon();
            Menu.MenuAsText();
            Menu.MenuSwitch();
        }

        //Runs when Case0 is selected in the menu
        public void EndSession()
        {
            Console.WriteLine("*Avsluta och spara *");
            Semicolon.UniteWithSemicolon();
            BankDataFile.WriteBankData();
            Console.WriteLine("Antal kunder: " + Customer.customers.Count);
            Console.WriteLine("Antal konton: " + Account.accounts.Count);
            Console.WriteLine("Saldo: " + Balance.TotalBalance());
        }
    }
}
