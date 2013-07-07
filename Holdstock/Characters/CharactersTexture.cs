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
    static class CharactersTexture
    {
        public static Texture guerrier;
        public static Texture archer;
        public static Texture magicien;

        public static void loadTextures()
        {
            guerrier = new Texture("images/guerrier_spritesheet_leftright.png");
            archer = new Texture("images/archer_spritesheet_leftright.png");
            magicien = new Texture("images/spritesheet_wizard.png");
            
        }
    }
}
