using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Banknots
{
    public class Banknot100 : Banknot
    {
        public Banknot100()
        {

            Nominal = 100;
            ID = RndStr(2, 7);
        }

        public override void BanknotPrint()
        {
            base.BanknotPrint();
        }


    }
}
