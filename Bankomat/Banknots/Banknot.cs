using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Banknots
{
    public class Banknot
    {
        public int Nominal { get; set; }
        public string ID { get; set; }

        public Banknot()
        {
            Nominal = 0;
            ID = RndStr(2, 7);
        }

        public Banknot(int nomin, string id)
        {
            Nominal = nomin;
            ID = id;

        }
        public virtual void BanknotPrint()
        {
            Console.WriteLine($"Банкнота номіналом {Nominal} грн., серійний номер {ID}");
        }

        public static Random rnd = new Random();
        //  Метод генерації  серії та номеру купюри
        public static string RndStr(int letters, int numbers)
        {
            StringBuilder sb = new StringBuilder(letters + numbers);
            string letterSet = "АБВГГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЮЯ";
            string numberSet = "0123456789";
            for (int i = 0; i < letters; i++)
                sb.Append(letterSet[rnd.Next(letterSet.Length)]);
            for (int i = 0; i < numbers; i++)
                sb.Append(numberSet[rnd.Next(numberSet.Length)]);
            return sb.ToString();
        }
    }
}
