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
    public class Block
    {
        //public Sprite sprite { get; set; }
        public Vector2f position { get; set; }
        public static int speed { get; set; }
        public string name { get; set;}

        public SpriteAnimated sprite { get; set; }

        public void moveSprite(float x, float y)
        {
            this.sprite.Position = new Vector2f(x, y);
            this.position = new Vector2f(x, y);
        }

        public virtual void draw(RenderWindow _window)
        {
            _window.Draw(this.sprite);
        }
    }
}
