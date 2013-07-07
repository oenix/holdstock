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
    public abstract class Missile
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double xVel;
        public double yVel;

        public SpriteAnimated sprite;

        public double xSpeed;

        public int damages;

        public Stopwatch timerTracker;


        public void update(List<Block> collisions, TimeSpan time)
        {
            X += xVel * xSpeed * time.TotalSeconds;
            Y += yVel * xSpeed * time.TotalSeconds;
            if (sprite != null)
            {
                sprite.Position = new Vector2f((float)X, (float)Y);
                sprite.Update(time);
                // Console.WriteLine("Missile position : " + X + "," + Y);
                foreach (Block block in collisions)
                {
                    bool isColliding = this.sprite.GetGlobalBounds().Intersects(block.sprite.GetGlobalBounds());
                   // Console.WriteLine(isColliding);
                    if ((timerTracker == null  && isColliding && block.name == "ghost")
                        || (timerTracker != null && timerTracker.Elapsed.Milliseconds > 300 && isColliding && block.name == "ghost"))
                    {
                        this.sprite = null;
                        Ghost g = (Ghost)block;
                        g.Life -= this.damages;
                        Score.killEnnemy();
                        break;
                    }
                }     
            }
        }

        public void Draw(RenderWindow window)
        {
            if (sprite != null)
                 window.Draw(sprite);
        }
    }
}
