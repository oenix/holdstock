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
    class Box : Block
    {
        public Box(RenderTarget window)
        {
            this.name = "box";
            sprite = new SpriteAnimated(BlockTextures.box, 100, 100, 1, window, RenderStates.Default, 0, 0, true, true);
        }

        public Box(Vector2f position, RenderTarget window) : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
