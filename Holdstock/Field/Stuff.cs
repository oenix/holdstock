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
    class Stuff : Block
    {

        Font font;
        Text text;
        public int price { get; set; }

        public Stuff(RenderTarget window, string type)
        {
            font = new Font("Ressources/arial.ttf");
            this.name = type;
            if (type == "fleche")
            {
                sprite = new SpriteAnimated(MissilesTexture.arrow2, 100, 100, 1, window, RenderStates.Default, 0, 0, true, true);
                price = 5;
              //  sprite.Scale = new Vector2f((float)0.5, (float)0.5);
            }
            else if (type == "feu")
            {
                sprite = new SpriteAnimated(MissilesTexture.fireball, 545, 545, 1, window, RenderStates.Default, 0, 0, false, false);
                sprite.Texture.Smooth = true;
                sprite.Scale = new Vector2f((float)0.2, (float)0.2);
                price = 10;
            }
        }

        public Stuff(Vector2f position, RenderTarget window, string type)
            : this(window, type)
        {
            this.sprite.Position = position;
            this.position = position;

            text = new Text();
            text.Position = new Vector2f(position.X + 30, position.Y - 50);
            text.Font = font;
            text.DisplayedString = price.ToString() + " $";
        }

        public override void draw(RenderWindow _window)
        {
            _window.Draw(this.sprite);
            _window.Draw(this.text);
        }
    }
}
