using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Class1
    {
        public int A { get; set; }
    }
    class Command
    {
        public void Excecute()
        {
            Class1 ban1 = new Class1();
            ban1.A = 3;
            Class1 ban2 = new Class1();
            ban2.A = 4;
        }
    }
}
