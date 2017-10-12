using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Account
    {
        public static List<Account> accounts = new List<Account>();

        //Properties
        public string Kontonummer { get; set; }
        public string Kundnummer { get; set; }
        public decimal Saldo { get; set; }

        //Constuctor
        public Account(string kontonummer, string kundnummer, string saldo)
        {
            Kontonummer = kontonummer;
            Kundnummer = kundnummer;
            Saldo = decimal.Parse(saldo,CultureInfo.InvariantCulture);
        }
    }
}
