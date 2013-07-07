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
            ActualLevel = 2;
            MaxLevel = 5;

            objectives = new List<string>();
            for (int i = 0; i < MaxLevel; i++)
                objectives.Add("Sauver la princesse");
            objectives.Add("Trouver le trésor");
            objectives.Add("Un objectif très long pour que vous puissiez parcourir tout le niveau sans finir de le lire");
        }
    }
}
