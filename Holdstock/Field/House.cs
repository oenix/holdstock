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
    class House : Block
    {
        public House(RenderTarget window)
        {
            this.name = "house";
            sprite = new SpriteAnimated(BlockTextures.house, 397, 394, 1, window, RenderStates.Default, 0, 0, false, false);
            sprite.Scale = new Vector2f(1, 1);
        }

        public House(Vector2f position, RenderTarget window)
            : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
