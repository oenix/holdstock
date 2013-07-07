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
    class Ground : Block
    {
        static int speed = 1;

        public Ground(RenderTarget window)
        {
            this.name = "ground";
            sprite = new SpriteAnimated(BlockTextures.ground, 100, 100, 1, window, RenderStates.Default, 0, 0, false, false);
        }

        public Ground(Vector2f position, RenderTarget window) : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
