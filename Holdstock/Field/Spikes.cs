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
    class Spikes : Block
    {
        static int speed = 2;
        public static int lifeTaken = 20000;

        public Spikes(RenderTarget window)
        {
            this.name = "spikes";
            sprite = new SpriteAnimated(BlockTextures.spikes, 100, 100, 1, window, RenderStates.Default, 0, 0, false, false);
            //this.sprite = new SpriteAnimated(BlockTextures.grass);
        }

        public Spikes(Vector2f position, RenderTarget window) : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
