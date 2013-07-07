using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Holdstock
{
    public class CollisionManager
    {
        public static bool Collides(FloatRect a, FloatRect b)
        {
            if (a.Intersects(b))
                return true;
            return false;
        }
    }
}
