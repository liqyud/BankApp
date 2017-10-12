using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Customer
    {
        public static List<Customer> customers = new List<Customer>();
        
        //properties
        public string Kundnummer { get; set; }
        public string Organisationsnummer { get; set; }
        public string Företagsnamn { get; set; }
        public string Adress { get; set; }
        public string Stad { get; set; }
        public string Region { get; set; }
        public string Postnummer { get; set; }
        public string Land { get; set; }
        public string Telefonnummer { get; set; }

        //contructor
        public Customer(string kundnummer, string organisationsnummer, string företagsnamn, string adress,
            string stad, string region, string postnummer, string land, string telefonnummer)
        {
            Kundnummer = kundnummer;
            Organisationsnummer = organisationsnummer;
            Företagsnamn = företagsnamn;
            Adress = adress;
            Stad = stad;
            Region = region;
            Postnummer = postnummer;
            Land = land;
            Telefonnummer = telefonnummer;
        }
    }
}
