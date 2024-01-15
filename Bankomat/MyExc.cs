using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class MyExc : Exception
    {
        public MyExc() : base(" Неправильно введені дані !") { }
    }
}
