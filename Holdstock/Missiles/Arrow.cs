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
    public class Arrow : Missile
    {
        public Arrow(float x, float y, float xVel, float yVel, RenderTarget window)
        {
            this.X = x;
            this.Y = y;
            this.xVel = xVel;
            this.yVel = yVel;
            this.damages = 10;
            xSpeed = 1000;
            sprite = new SpriteAnimated(MissilesTexture.arrow, 240, 63, 1, window, RenderStates.Default, 0, 0, false, false);
            sprite.Scale = new Vector2f((float)0.5, (float)0.5);
            sprite.Position = new Vector2f((float)x, (float)y);
            timerTracker = new System.Diagnostics.Stopwatch();
        }
    }
}
