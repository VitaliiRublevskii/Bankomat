using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Banknots
{
    public class Banknot200 : Banknot
    {
        public Banknot200()
        {

            Nominal = 200;
            ID = RndStr(2, 7);
        }

        public override void BanknotPrint() => base.BanknotPrint();


    }
}
