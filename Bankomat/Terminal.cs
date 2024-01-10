using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Banknots
{
    public class Terminal
    {
        public int ID { get; set; }
        public string Adres { get; set; }
        public Banknot100 [] B100 {  get; set; }
        public Banknot200[] B200 { get; set; }
        public Banknot500[] B500 { get; set; }
        public Banknot1000[] B1000 { get; set; }
        public Karta[] Kards { get; set; }



        public Terminal(int id, string adres, Banknot100[] b100, Banknot200[] b200, 
            Banknot500[] b500, Banknot1000[] b1000, Karta[] kards)
        {
            ID = id;
            Adres = adres;
            B100 = b100;
            B200 = b200;
            B500 = b500;
            B1000 = b1000;
            Kards = kards;
        }
    }
}
