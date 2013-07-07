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
    class Guerrier : Character
    {
        public Guerrier(double x, double y, RenderTarget window)
        {
            this.X = x;
            this.Y = y;

            this.Mana = 100;


            yVel = 0;
            gravity = 2.3;
            isJumping = false;
            xSpeed = 0;
            maxSpeed = 5;


            decalage = 405;

            Texture texture = CharactersTexture.guerrier;

            stayingSprite = new SpriteAnimated(texture, 192, 192, 1, window, RenderStates.Default, 0, 0, false, false);
            stayingSprite.Scale = new Vector2f(1, 1);
            stayingSprite.Position = new Vector2f((float)x, (float)y);

            
            walkingAnimationSprite = new SpriteAnimated(texture, 192, 192, 10, window, RenderStates.Default, 1, 8, true, true);
            walkingAnimationSprite.Scale = new Vector2f(1, 1);
            walkingAnimationSprite.Position = new Vector2f((float)x, (float)y);

            walkingAnimationLeftSprite = new SpriteAnimated(texture, 192, 192, 10, window, RenderStates.Default, 10, 16, true, true);
            walkingAnimationLeftSprite.Scale = new Vector2f(1, 1);
            walkingAnimationLeftSprite.Position = new Vector2f((float)x, (float)y);

            SoundBuffer collectCoinBuffer = new SoundBuffer("audio/coinCollect.wav");
            collectCoinSound = new SFML.Audio.Sound(collectCoinBuffer);
            collectCoinSound.Volume = 25;  

            sprite = stayingSprite;

            this.Life = 5000;
            this.MaxLife = 5000;

        }

        public override Missile attack(RenderTarget _window, Window window)
        {
            return null;
        }

        public override Missile attackSpecial(RenderTarget _window, Window window)
        {
            return null;
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
