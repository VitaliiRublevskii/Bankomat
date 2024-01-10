using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Banknots
{
    public class Banknot1000 : Banknot
    {
        public Banknot1000()
        {

            Nominal = 1000;
            ID = RndStr(2, 7);
        }

        public override void BanknotPrint()
        {
            base.BanknotPrint();
        }


    }
}
