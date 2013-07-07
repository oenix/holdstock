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
    class Ring : Block
    {
        public Ring(RenderTarget window)
        {
            this.name = "ring";
            sprite = new SpriteAnimated(BlockTextures.ring, 40, 40, 15, window, RenderStates.Default, 0, 9, true, true);
            sprite.Scale = new Vector2f(2, 2);
        }

        public Ring(Vector2f position, RenderTarget window) : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
