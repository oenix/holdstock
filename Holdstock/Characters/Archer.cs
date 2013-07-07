using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;

namespace Holdstock
{
    class Archer : Character
    {
        public bool activated = false;
        public Archer(double x, double y, RenderTarget window)
        {
            this.X = x;
            this.Y = y;
            this.Mana = 100;

            yVel = 50;
            gravity = 1.4;
            isJumping = false;
            xSpeed = 1;
            maxSpeed = 12;
            this.decalage = 405;

            //Sprites and textures
            Texture texture = CharactersTexture.archer;
            stayingSprite = new SpriteAnimated(texture, 165, 198, 1, window, RenderStates.Default, 0, 0, false, false);
            stayingSprite.Position = new Vector2f((float)x, (float)y);
            walkingAnimationSprite = new SpriteAnimated(texture, 165, 198, 18, window, RenderStates.Default, 1, 8, true, true);
            walkingAnimationSprite.Position = new Vector2f((float)x, (float)y);
            walkingAnimationLeftSprite = new SpriteAnimated(texture, 165, 198, 18, window, RenderStates.Default, 9, 16, true, true);
            walkingAnimationLeftSprite.Position = new Vector2f((float)x, (float)y);
            sprite = stayingSprite;

            //Sounds
            SoundBuffer attack1Buffer = new SoundBuffer("audio/Characters/Archer/attack1.wav");
            attack1Sound = new SFML.Audio.Sound(attack1Buffer);
            attack1Sound.Volume = 15; 
            SoundBuffer jump1Buffer = new SoundBuffer("audio/Characters/Archer/jump3.wav");
            jumpSound = new SFML.Audio.Sound(jump1Buffer);
            jumpSound.Volume = 150;
            jumpSound.PlayingOffset = new TimeSpan(0,0,0,0,900);

            SoundBuffer collectCoinBuffer = new SoundBuffer("audio/coinCollect.wav");
            collectCoinSound = new SFML.Audio.Sound(collectCoinBuffer);
            collectCoinSound.Volume = 25; 

            this.Life = 1000;
            this.MaxLife = 1000;
        }

        public override Missile attack(RenderTarget _window ,Window window)
        {
            if (activated && this.Mana > 0)
            {
                this.Mana -= 5;
                attack1Sound.Play();
                float missileX = (float)sprite.Position.X + 82;
                float missileY = (float)sprite.Position.Y + sprite.Texture.Size.Y / 2;

                int mouseXinWindow = Mouse.GetPosition(window).X;
                int mouseYinWindow = Mouse.GetPosition(window).Y;

                float playerX = (float)sprite.Position.X;
                float playerY = (float)sprite.Position.Y;

                Vector2f clikInMap = _window.MapPixelToCoords(new Vector2i(mouseXinWindow, mouseYinWindow));
                
                float xVel = (clikInMap.X - sprite.Position.X);
                float yVel = (clikInMap.Y - sprite.Position.Y);

                double vectLength = Math.Sqrt((double)xVel*xVel + (double)yVel*yVel);
                xVel = (float)(xVel / vectLength);
                yVel = (float)(yVel / vectLength);

                double angle = 180 * Math.Atan2(clikInMap.Y - playerY, clikInMap.X - playerX) / Math.PI;
                
                Console.WriteLine(angle);
                Arrow arrow = new Arrow(missileX, missileY, xVel, yVel, _window);
                arrow.sprite.Rotation = (float)angle;
                return (arrow);
            }
            return null;
        }
        
        public override List<Arrow> attackSpecial2(RenderTarget _window, Window window)
    {
        List<Arrow> arrowVolley = new List<Arrow>();
            //if (activated && this.Mana > 0)
            {
                
                this.Mana -= 5;
                attack1Sound.Play();
                float missileX = (float)sprite.Position.X + 82;
                float missileY = (float)sprite.Position.Y + sprite.Texture.Size.Y / 2;

                int mouseXinWindow = Mouse.GetPosition(window).X;
                int mouseYinWindow = Mouse.GetPosition(window).Y;

                float playerX = (float)sprite.Position.X;
                float playerY = (float)sprite.Position.Y;

                Vector2f clikInMap = _window.MapPixelToCoords(new Vector2i(mouseXinWindow, mouseYinWindow));
                for (float i = -1; i <= 1; i = i + 1)
                {
                       for (float j = 1; j >= -1; j = j - 1)
                    {
                        float xVel = i;//(clikInMap.X - sprite.Position.X);
                        float yVel = j;//(clikInMap.Y - sprite.Position.Y);

                        double vectLength = Math.Sqrt((double)xVel * xVel + (double)yVel * yVel);
                        xVel = (float)(xVel / vectLength);
                        yVel = (float)(yVel / vectLength);

                        double angle = 180 * Math.Atan2(yVel, xVel) / Math.PI;

                        Console.WriteLine(angle);
                        Arrow arrow = new Arrow(missileX, missileY, xVel, yVel, _window);
                        arrow.sprite.Rotation = (float)angle;
                        
                        arrowVolley.Add(arrow);
                    } 
                }
                
                return (arrowVolley);
            }
            return null;
    }
        public override Missile attackSpecial(RenderTarget _window, Window window)
        {
            List<Arrow> arrowVolley = new List<Arrow>();
            //if (activated && this.Mana > 0)
            {
                
                this.Mana -= 5;
                attack1Sound.Play();
                float missileX = (float)sprite.Position.X + 82;
                float missileY = (float)sprite.Position.Y + sprite.Texture.Size.Y / 2;

                int mouseXinWindow = Mouse.GetPosition(window).X;
                int mouseYinWindow = Mouse.GetPosition(window).Y;

                float playerX = (float)sprite.Position.X;
                float playerY = (float)sprite.Position.Y;

                Vector2f clikInMap = _window.MapPixelToCoords(new Vector2i(mouseXinWindow, mouseYinWindow));

                float xVel = -1 ;//(clikInMap.X - sprite.Position.X);
                float yVel = 1;//(clikInMap.Y - sprite.Position.Y);

                double vectLength = Math.Sqrt((double)xVel * xVel + (double)yVel * yVel);
                xVel = (float)(xVel / vectLength);
                yVel = (float)(yVel / vectLength);

                double angle = 180 * Math.Atan2(yVel, xVel) / Math.PI;

                Console.WriteLine(angle);
                Arrow arrow = new Arrow(missileX, missileY, xVel, yVel, _window);
                arrow.sprite.Rotation = (float)angle;
                arrowVolley.Add(arrow);
                return (arrow);
            }
            return null;
        }

          public override void jump()
          {
              if (!this.isJumping)
              {
                  jumpSound.Play();
                  yVel = -30;
                  this.isJumping = true;
              }

          }
    }
}
