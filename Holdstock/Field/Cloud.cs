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
    class Cloud : Block
    {
        Random random = new Random();
        int moving;

        public Cloud(RenderTarget window)
        {
            this.name = "cloud";
            moving = random.Next(2) + 1;
            sprite = new SpriteAnimated(BlockTextures.cloud, 400, 200, 1, window, RenderStates.Default, 0, 0, false, false);
            //  sprite.Scale = new Vector2f(1, 1);
        }

        public Cloud(Vector2f position, RenderTarget window)
            : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }

        public void update()
        {
             this.sprite.Position = new Vector2f(this.sprite.Position.X - moving, this.position.Y);
        }
    }
}