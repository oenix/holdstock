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
    public class Sorciere : Character
    {
        public bool isSmaller = false;
        public bool activated = false;

        public Sorciere(double x, double y, RenderTarget window)
        {

            this.Mana = 100;
            this.X = x;
            this.Y = y;
            yVel = 0;
            gravity = 1.2;
            isJumping = false;
            xSpeed = 1;
            maxSpeed = 10;

            decalage = 405;
            Texture magicienTextures = CharactersTexture.magicien;

            stayingSprite = new SpriteAnimated(magicienTextures, 58, 58, 1, window, RenderStates.Default, 0, 0, false, false);
            stayingSprite.Scale = new Vector2f(3, 3);
            stayingSprite.Position = new Vector2f((float)x, (float)y);
            
            walkingAnimationSprite = new SpriteAnimated(magicienTextures, 58, 58, 15,  window, RenderStates.Default, 1, 3, true, true);
            walkingAnimationSprite.Scale = new Vector2f(3, 3);
            walkingAnimationSprite.Position = new Vector2f((float)x, (float)y);

            walkingAnimationLeftSprite = new SpriteAnimated(magicienTextures, 58, 58, 15, window, RenderStates.Default, 5, 7, true, true);
            walkingAnimationLeftSprite.Scale = new Vector2f(3, 3);
            walkingAnimationLeftSprite.Position = new Vector2f((float)x, (float)y);

            sprite = stayingSprite;

            //Sounds
            SoundBuffer attack1Buffer = new SoundBuffer("audio/Characters/Wizard/fireball.wav");
            attack1Sound = new SFML.Audio.Sound(attack1Buffer);
            attack1Sound.Volume = 25;

            SoundBuffer attack2Buffer = new SoundBuffer("audio/Characters/Wizard/laserbeam.wav");
            attack2Sound = new SFML.Audio.Sound(attack2Buffer);
            attack2Sound.Volume = 25;

            SoundBuffer collectCoinBuffer = new SoundBuffer("audio/coinCollect.wav");
            collectCoinSound = new SFML.Audio.Sound(collectCoinBuffer);
            collectCoinSound.Volume = 25; 

            this.Life = 3000;
            this.MaxLife = 3000;

        }

        public override void ChangeSize()
        {
            if (isSmaller)
            {
                this.sprite.Scale = new Vector2f(3, 3);
                this.walkingAnimationSprite.Scale = new Vector2f(3, 3);
                this.walkingAnimationLeftSprite.Scale = new Vector2f(3, 3);
                isSmaller = false;
            }
            else
            {
                this.sprite.Scale = new Vector2f(1, 1);
                this.walkingAnimationSprite.Scale = new Vector2f(1, 1);
                this.walkingAnimationLeftSprite.Scale = new Vector2f(1, 1);
                isSmaller = true;
            }
        }

        public override Missile attack(RenderTarget _window, Window window)
        {
            if (activated && this.Mana > 0 && !isSmaller)
            {
                this.Mana -= 5;
                attack1Sound.Play();
                float missileX = (float)sprite.Position.X + sprite.Texture.Size.X / 2;
                float missileY = (float)sprite.Position.Y + sprite.Texture.Size.Y / 2;

                int mouseXinWindow = Mouse.GetPosition(window).X;
                int mouseYinWindow = Mouse.GetPosition(window).Y;

                float playerX = (float)sprite.Position.X;
                float playerY = (float)sprite.Position.Y;

                Vector2f clikInMap = _window.MapPixelToCoords(new Vector2i(mouseXinWindow, mouseYinWindow));

                float xVel = (clikInMap.X - sprite.Position.X);
                float yVel = (clikInMap.Y - sprite.Position.Y);

                //Vector normalization
                double vectLength = Math.Sqrt((double)xVel * xVel + (double)yVel * yVel);
                xVel = (float)(xVel / vectLength);
                yVel = (float)(yVel / vectLength);

                double angle = 180 * Math.Atan2(clikInMap.Y - playerY, clikInMap.X - playerX) / Math.PI;

                Spell fireball = new Spell(missileX, missileY, xVel, yVel, _window);
                fireball.sprite.Rotation = (float)angle;

                return (fireball);
            }
            return null;
        }

        public override Missile attackSpecial(RenderTarget _window, Window window)
        {
            
                
                attack2Sound.Play();
                float missileX = (float)sprite.Position.X + sprite.Texture.Size.X / 2;
                float missileY = (float)sprite.Position.Y + sprite.Texture.Size.Y / 2;

                int mouseXinWindow = Mouse.GetPosition(window).X;
                int mouseYinWindow = Mouse.GetPosition(window).Y;

                float playerX = (float)sprite.Position.X;
                float playerY = (float)sprite.Position.Y;

                Vector2f clikInMap = _window.MapPixelToCoords(new Vector2i(mouseXinWindow, mouseYinWindow));

                float xVel = (clikInMap.X - sprite.Position.X);
                float yVel = (clikInMap.Y - sprite.Position.Y);

                //Vector normalization
                double vectLength = Math.Sqrt((double)xVel * xVel + (double)yVel * yVel);
                xVel = (float)(xVel / vectLength);
                yVel = (float)(yVel / vectLength);

                double angle = 180 * Math.Atan2(clikInMap.Y - playerY, clikInMap.X - playerX) / Math.PI;

                LaserBeam laser = new LaserBeam(missileX, missileY, xVel, yVel, _window);
                laser.sprite.Rotation = (float)angle;

                return laser;
            
          
        }

          public override void jump()
          {
              if (!this.isJumping)
              {
                  yVel = -25;
                  this.isJumping = true;

              }
              

          }


    }
}
