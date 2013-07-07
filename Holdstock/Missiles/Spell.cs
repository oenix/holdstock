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
    class Spell : Missile
    {
        public Spell(float x, float y, float xVel, float yVel, RenderTarget window)
        {
            this.X = x;
            this.Y = y;
            this.xVel = xVel;
            this.yVel = yVel;
            this.damages = 20;
            xSpeed = 800;
            sprite = new SpriteAnimated(MissilesTexture.fireball, 495, 495, 18, window, RenderStates.Default, 1, 5, true, true);
            sprite.Scale = new Vector2f((float)0.3, (float)0.3);
            sprite.Position = new Vector2f((float)x, (float)y);

            
            
        }
    }
}
