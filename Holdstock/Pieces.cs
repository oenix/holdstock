using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdstock
{
    static class Pieces
    {
        public static int nbRings { get; set; }
        static bool singleton = false;

        public static void init_Rings()
        {
                nbRings = 5;
        }
    }
}
