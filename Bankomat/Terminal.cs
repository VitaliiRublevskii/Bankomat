using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bankomat.Banknots
{
    public class Terminal : IDisposable
    {
        public int ID { get; set; }
        public string Adres { get; set; }
        public List <Banknot100> B100 {  get; set; }
        public List <Banknot200> B200 { get; set; }
        public List <Banknot500> B500 { get; set; }
        public List <Banknot1000> B1000 { get; set; }
        public List <Karta> Kards { get; set; }

        public Terminal() { }

        public Terminal(int id, string adres, string pathb100, string pathb200, string pathb500, string pathb1000, string pathkards)
        {
            ID = id;
            Adres = adres;
            B100 = new List<Banknot100>();
            string[] str100 = File.ReadAllLines(pathb100);
            for (int i = 0; i < str100.Length; i++)
            {                
                string[] str2 = str100[i].Split(" ");
                for (int j = 0; j < str2.Length; j++)
                {
                    Banknot100 b2 = new Banknot100();
                    b2.Nominal = int.Parse(str2[0]);
                    b2.ID = str2[1];
                    B100.Add(b2);
                }
            }

            B200 = new List<Banknot200>();
            string[] str200 = File.ReadAllLines(pathb200);
            for (int i = 0; i < str200.Length; i++)
            {
                string[] str2 = str200[i].Split(" ");
                for (int j = 0; j < str2.Length; j++)
                {
                    Banknot200 b2 = new Banknot200();
                    b2.Nominal = int.Parse(str2[0]);
                    b2.ID = str2[1];
                    B200.Add(b2);
                }
            }

            B500 = new List<Banknot500>();
            string[] str500 = File.ReadAllLines(pathb500);
            for (int i = 0; i < str500.Length; i++)
            {
                string[] str2 = str500[i].Split(" ");
                for (int j = 0; j < str2.Length; j++)
                {
                    Banknot500 b2 = new Banknot500();
                    b2.Nominal = int.Parse(str2[0]);
                    b2.ID = str2[1];
                    B500.Add(b2);
                }
            }

            B1000 = new List<Banknot1000>();
            string[] str1000 = File.ReadAllLines(pathb1000);
            for (int i = 0; i < str1000.Length; i++)
            {
                string[] str2 = str1000[i].Split(" ");
                for (int j = 0; j < str2.Length; j++)
                {
                    Banknot1000 b2 = new Banknot1000();
                    b2.Nominal = int.Parse(str2[0]);
                    b2.ID = str2[1];
                    B1000.Add(b2);
                }
            }

            Kards = new List<Karta>();
            string[] strK = File.ReadAllLines(pathkards);
            for (int i = 0; i < strK.Length; i++)
            {
                string[] str2 = strK[i].Split(" ");
                for (int j = 0; j < 1; j++)
                {
                    Karta k = new Karta();
                    k.Bank = str2[0];
                    k.Number = str2[1];
                    k.Pin = str2[2];
                    k.Balans = double.Parse(str2[3]);
                    string[] s = str2[4].Split(".");
                    for (int kj = 0; kj < str2[4].Length; kj++)
                    {
                        int d = int.Parse(s[0]);
                        int m = int.Parse(s[1]);
                        int y = int.Parse(s[2]);

                        k.Date = new DateOnly(d, m, y);
                    }
                    
                    Kards.Add(k);
                }
            }


        }

        public Terminal(int id, string adres, List<Banknot100> b100, List<Banknot200> b200,
            List<Banknot500> b500, List<Banknot1000> b1000, List<Karta> kards)
        {
            ID = id;
            Adres = adres;
            B100 = b100;
            B200 = b200;
            B500 = b500;
            B1000 = b1000;
            Kards = kards;
        }

        public void TerminalInfo() => Console.WriteLine($" Термінал № {ID}, розташований за адресою: {Adres}.\n " +
            $"В наявності купюри:\n номіналом 100 грн. - {B100.Count} од.\n номіналом 200 грн. - {B200.Count} од.\n" +
            $" номіналом 500 грн. - {B500.Count} од.\n номіналом 1000 грн. - {B1000.Count} од.");

      
        public void Dispose()
        {
            Console.WriteLine("Files delete");
            File.Delete("myKartas.txt");
            File.Delete("myB100.txt");
            File.Delete("myB200.txt");
            File.Delete("myB500.txt");
            File.Delete("myB1000.txt");
            GC.Collect();

        }

    }
}
