using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdstock
{
    public static class Score
    {
        public static int Points { get; set; }

        public static void killEnnemy()
        {
            Points += 100;
        }

        public static void takeRings()
        {
            Points += 10;
        }
        public static void savePrincess()
        {
            Points += 135;
        }
    }
}
