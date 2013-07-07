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
    class Rock : Block
    {
        public Rock(RenderTarget window)
        {
            this.name = "rock";
            sprite = new SpriteAnimated(BlockTextures.rock, 100, 100, 1, window, RenderStates.Default, 0, 0, false, false);
        }

        public Rock(Vector2f position, RenderTarget window)
            : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
