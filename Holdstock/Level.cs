using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdstock
{
    class Level
    {
        public static int ActualLevel { get; set; }
        public static int MaxLevel { get; set; }
        public static List<string> objectives { get; set; }

        public static void setLevels()
        {
            ActualLevel = 4;
            MaxLevel = 5;

            objectives = new List<string>();
            for (int i = 0; i < MaxLevel; i++)
                objectives.Add("Sauver la princesse");
            objectives.Add("Trouver le trésor");
            objectives.Add("Un objectif très long pour que vous puissiez parcourir tout le niveau sans finir de le lire");
        }

        public static string musicPerLevel()
        {
            if (ActualLevel == 1)
                return "music4.ogg";
            if (ActualLevel == 2)
                return "music5.ogg";
            if (ActualLevel == 3)
                return "music6.ogg";
            return "music1.ogg";
        }
    }
}
