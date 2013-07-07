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
    static class MissilesTexture
    {
        public static Texture arrow;
        public static Texture arrow2;
        
        public static Texture fireball;
        public static Texture laserbeam;

        public static void loadTextures()
        {
            arrow = new Texture("images/arrow.png");
            arrow2 = new Texture("images/arrow2.png");
            fireball = new Texture("images/fireball_SpriteSheet.png");
            laserbeam = new Texture("images/laserbearm-spritesheet.png");
        }
    }
}
