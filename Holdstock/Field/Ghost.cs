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
    class Ghost : Block
    {
        public int Life { get; set; }
        int moving;

        public int degats;

        public Ghost(RenderTarget window, Random random)
        {
            this.name = "ghost";
            Life = 20;
            degats = 50;
            moving = RandomNumber(1, 11, random);
            Console.WriteLine(moving);
            sprite = new SpriteAnimated(BlockTextures.ghost, 289, 228, 1, window, RenderStates.Default, 0, 0, false, false);
          //  sprite.Scale = new Vector2f(1, 1);
        }

        public Ghost(Vector2f position, RenderTarget window, Random random)
            : this(window, random)
        {
            this.sprite.Position = position;
            this.position = position;
        }

        public void update()
        {
            if (this.Life <= 0)
            {
                //this.sprite.Rotation = 180;
                this.sprite.Position = new Vector2f(this.sprite.Position.X - 3, this.sprite.Position. Y + 10);

            }
            else
                this.sprite.Position = new Vector2f(this.sprite.Position.X - moving, this.position.Y);
        }

        private int RandomNumber(int min, int max, Random random)
        {
            return random.Next(min, max);
        }
    }
}