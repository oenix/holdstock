using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using System.Diagnostics;

namespace Holdstock
{
    class LaserBeam : Missile
    {
        public LaserBeam(float x, float y, float xVel, float yVel, RenderTarget window)
        {
            this.X = x;
            this.Y = y;
            this.xVel = xVel;
            this.yVel = yVel;
            this.damages = 200;
            xSpeed = 1;
            sprite = new SpriteAnimated(MissilesTexture.laserbeam, 960, 93, 32, window, RenderStates.Default, 0, 7, true, false);
            sprite.Scale = new Vector2f((float)3, (float)3);
            sprite.Position = new Vector2f((float)x, (float)y);

            timerTracker = new Stopwatch();
            timerTracker.Start();
            
        }
    }
}
