using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Karta
    {
        public string Bank { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public double Balans { get; set; }
        public DateOnly Date { get; set; }


    

        public Karta()
        {
            Bank = RndBank(1);
            Number = RndNum(4) + "-" + RndNum(4) + "-" + RndNum(4) + "-" + RndNum(4);
            Pin = RndNum(4);
            Balans = random.Next(0, 100000);
            Date = new DateOnly(random.Next(23, 27), random.Next(1, 12), 1);
        }


        public Karta(string bank, string number, string pin, double balans, DateOnly data)
        {
            Bank = bank;
            Number = number;
            Pin = pin;
            Balans = balans;
            Date = data;

        }

       

        public void KartaPrint() => Console.WriteLine( $" Данні карти: \n банк-імітент :\t\t{Bank},\n номер карти : \t\t{Number},\n PIN-код карти: \t{Pin}\n" +
                $" баланс карти: \t\t{Balans},\n строк дії: \t\t{Date.Month}/{Date.Year}" );

        public void KartaShow() => Console.WriteLine($" Данні карти: \n банк-імітент :\t\t{Bank},\n номер карти : \t\t{Number},\n строк дії: \t\t{Date.Month}/{Date.Year}");

        public static Random random = new Random();
        //  Метод рандомного вибору Банку імітенту карти
        public static string RndBank(int letters)
        {
            StringBuilder sbank = new StringBuilder(letters);
            List<string> letterSet = new List<string> { "ПриватБанк", "Ощадбанк", "УкрСиббанк", "РайффайзенБанк" };

            for (int i = 0; i < 1; i++)
                sbank.Append(letterSet[random.Next(4)]);

            return sbank.ToString();
        }

        public static string RndNum(int numbers)
        {
            StringBuilder sNum = new StringBuilder(numbers);
            
            string numberSet = "0123456789";
            
            for (int i = 0; i < numbers; i++)
                sNum.Append(numberSet[random.Next(numberSet.Length)]);
            return sNum.ToString();
        }

        public void AddToFile (string filename) => File.AppendAllText(filename, Bank + " " + Number + " " + Pin + " " + Balans + " " + Date + "\n");



    }
}
