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
    class Potion : Block
    {
        RenderTarget _windows;
        public string _type;


        public Potion(RenderTarget window, string type)
        {
            this.name = "potion";
            _windows = window;
            _type = type;
            if (type == "life")
            {
                sprite = new SpriteAnimated(BlockTextures.lifePotion, 100, 100, 1, window, RenderStates.Default, 0, 0, true, true);
                sprite.Texture.Smooth = true;
                //  sprite.Scale = new Vector2f((float)0.5, (float)0.5);
            }
            else if (type == "mana")
            {
                sprite = new SpriteAnimated(BlockTextures.manaPotion, 100, 100, 1, window, RenderStates.Default, 0, 0, false, false);
                sprite.Texture.Smooth = true;
              //  sprite.Scale = new Vector2f((float)0.2, (float)0.2);
            }
        }

        public Potion(Vector2f position, RenderTarget window, string type) : this(window, type)
        {
            this.sprite.Position = position;
            this.position = position;
        }

    }
}
