using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Banknots
{
    public class Banknot500 : Banknot
    {
        public Banknot500()
        {

            Nominal = 500;
            ID = RndStr(2, 7);
        }

        public override void BanknotPrint() => base.BanknotPrint();


    }
}
