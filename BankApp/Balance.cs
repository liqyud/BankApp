using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static BankApp.Account;

namespace BankApp
{
    class Balance
    {
        //Sums up the total balance of all accounts in list
        public static decimal TotalBalance()
        {
            decimal totalBalance = accounts.Sum(x => x.Saldo);
            return totalBalance;
        }

        public static void Deposit(int accountNumber, decimal deposit, bool depositOnly)
        {
            //Check index in the account list. Find account that has the inputed Account Number
            int index = accounts.FindIndex(i => i.Kontonummer == accountNumber.ToString());
            try
            {
                //Account current balance + deposit
                accounts[index].Saldo += deposit;
                if (depositOnly)
                {
                    Console.WriteLine($"{deposit} kr insätts på konto {accountNumber}");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Angivna kontonummer finns inte");
            }
        }


        public static void Withdraw(int accountNumber, decimal withdraw, bool withdrawOnly)
        {
            //Check index in the account list. Find account that has the inputed Account Number
            int index = accounts.FindIndex(i => i.Kontonummer == accountNumber.ToString());
            try
            {
                if (withdraw <= accounts[index].Saldo)
                {
                    //Account current balance - withdraw
                    accounts[index].Saldo -= withdraw;
                    if (withdrawOnly)
                    {
                        Console.WriteLine($"{withdraw} kr togs ut från konto {accountNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("Uttag belopp får inte överskriva saldo från uttags konton");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Angivna kontonummer finns inte");
            }
        }

        //Runs when Case7 has been selected from the menu
        public static void DepositCase()
        {
            Console.WriteLine("* Insättning *");
            Console.Write("Kontonummer? ");
            int inputAccount;
            decimal deposit;
            if (!int.TryParse(Console.ReadLine(), out inputAccount))
            {
                Console.WriteLine("Var vänlig och ange kontonummer i siffror.");
            }
            else
            {
                Console.Write("Insättning Belopp? ");
                if (!decimal.TryParse(Console.ReadLine(), out deposit))
                {
                    Console.WriteLine("Insättning ska skrivas med siffror och punkt ska användas för decimaler");
                }
                else
                {
                    if (deposit > 0.0m)
                    {
                        Deposit(inputAccount, deposit, true);
                    }
                    else
                    {
                        Console.WriteLine("Summa får inte vara negativ!");
                    }
                }
            }
        }

        //Runs when Case8 has been selected from the menu
        public static void WithdrawCase()
        {
            Console.WriteLine("* Uttag *");
            Console.Write("Kontonummer? ");
            int inputAccount;
            decimal withdraw;
            if (!int.TryParse(Console.ReadLine(), out inputAccount))
            {
                Console.WriteLine("Var vänlig och ange kontonummer i siffror.");
            }
            else
            {
                Console.Write("Uttag Belopp? ");
                if (!decimal.TryParse(Console.ReadLine(), out withdraw))
                {
                    Console.WriteLine("Insättning ska skrivas med siffror och punkt ska användas för decimaler");
                }
                else
                {
                    if (withdraw > 0.0m)
                    {
                        Withdraw(inputAccount, withdraw, true);
                    }
                    else
                    {
                        Console.WriteLine("Summa får inte vara negativ!");
                    }
                }
            }
        }

        //Runs when Case9 is selected from the menu screen
        public static void Transfer()
        {
            int transferFromAccount;
            int transferToAccount;
            decimal transfer;
            Console.WriteLine("* Överföring *");

            //Checking if input is interger
            Console.Write("Från? ");
            bool from = !int.TryParse(Console.ReadLine(), out transferFromAccount);

            //Checking if input is interger
            Console.Write("Till? ");
            bool to = !int.TryParse(Console.ReadLine(), out transferToAccount);

            //Checking if input is decimal
            Console.Write("Belopp? ");
            bool belopp = !decimal.TryParse(Console.ReadLine(), out transfer);

            int index = accounts.FindIndex(i => i.Kontonummer == transferFromAccount.ToString());

            //if the inputs where not int or decimal then print message telling that.
            if (from || to || belopp)
            {
                Console.WriteLine("Kontonummer och belopp måste skrivas med siffror." +
                                  "\nFör belopp ska punkt användas för decimaler.");
            }
            else if (transfer >= 0.0m && accounts[index].Saldo >= transfer) //Check that the transfer value is greater than 0
            {
                Console.WriteLine();
                Withdraw(transferFromAccount, transfer, false);
                Deposit(transferToAccount, transfer, false);

                Console.WriteLine($"{transfer} kr har överfört från konto {transferFromAccount} till {transferToAccount}");
            }
            else //if transfer < 0.0m && accounts[index].Saldo < transfer
            {
                Console.WriteLine("Beloppet måste vara positiv och överföring belopp får inte överskriva saldo från uttags konton");
            }
        }
    }
}
