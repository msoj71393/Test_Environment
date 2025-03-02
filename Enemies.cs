using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Environment
{
    internal class Enemies
    {
    }

    internal class Kobold : Enemies
    {
        public int Health = 14;
        public int Damage = 3;
    }

    internal class Dragon : Enemies
    {
        public int Health = 30;
        public int Damage = 8;
    }
}
