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
    public abstract class Character
    {


        public int decalage = 0;
        public double X { get; set; }
        public double Y { get; set; }
        public double xSpeed;
        public double ySpeed;
        public double maxSpeed;
        public double terminalSpeed;

        public bool isJumping;
        public double yVel;
        public double gravity;

        public bool rightCollision = false;
        public bool upCollision = false;
        public bool leftCollision = false;

        public int Life { get; set; }

        public int MaxLife;

        public int Mana { get; set; }

        public bool savePrincess = false;

        //Sprites
        public SpriteAnimated walkingAnimationSprite;
        public SpriteAnimated walkingAnimationLeftSprite;
        public SpriteAnimated stayingSprite;
        public SpriteAnimated sprite;

        //Sounds
        public Sound attack1Sound;
        public Sound attack2Sound;
        public Sound jumpSound;
        public Sound collectCoinSound;

        public abstract Missile attack(RenderTarget _window, Window window);

        public abstract Missile attackSpecial(RenderTarget _window, Window window);

        public virtual List<Arrow> attackSpecial2(RenderTarget _window, Window window)
        {
            return null;
        }

        
        public void moveRight(TimeSpan deltaTime)
        {
            if (leftCollision)
            {
                xSpeed = 0;
            }
            else if (xSpeed < maxSpeed)
            {
                xSpeed += 1;
            }
            else
                xSpeed = maxSpeed;
            this.X += 1 * xSpeed;
            SetSPrite("movingRight");
        }

        public void moveLeft()
        {
            if (rightCollision)
            {
                xSpeed = 0;
            }
            else if (xSpeed < maxSpeed)
            {
                xSpeed += 1;
            }
            else
                xSpeed = maxSpeed;
            this.X -= 1 * xSpeed;
            SetSPrite("movingLeft");
        }

        public void SetSPrite(String spriteAction)
        {
            if (spriteAction == "staying")
            {
                float x = sprite.Position.X;
                float y = sprite.Position.Y;
                sprite = stayingSprite;
                sprite.Position = new Vector2f(x, y);

            }
            else if (spriteAction == "movingRight")
            {
                float x = sprite.Position.X;
                float y = sprite.Position.Y;
                sprite = walkingAnimationSprite;
                sprite.Position = new Vector2f(x, y);
            }
            else if (spriteAction == "movingLeft")
            {
                float x = sprite.Position.X;
                float y = sprite.Position.Y;
                sprite = walkingAnimationLeftSprite;
                sprite.Position = new Vector2f(x, y);
            }
            else
                sprite = stayingSprite;
        }

        public void update(List<Block> collisions)
        {


            bool isonground = false;
            Block takeRing = null;
            Block takePopo = null;
            leftCollision = false;
            rightCollision = false;
            upCollision = false;
            Princess princess = null;
            Stuff s = null;
            bool isBuy = false;

            /* Check if the character is going forward the left board of the map */

            if (this.X <= -1)
            {
                rightCollision = true;

                return;
            }

            foreach (Block block in collisions) // a optimiser avec une liste contenant uniquement des caisses
            {
                if (block.name == "princess")
                    princess = (Princess)block;
                if (block.name == "interrupteur")
                {

                    Interrupteur inte = (Interrupteur)block;
                    foreach (Block block2 in collisions)
                    {
                        if (block2.name == "box")
                        {
                            if (block.sprite.GetGlobalBounds().Intersects(block2.sprite.GetGlobalBounds()))
                            {
                                inte.activate();
                                if (princess != null)
                                    princess.activate();
                            }
                            else
                            {
                                inte.desactivate();
                                princess.desactivate();
                            }
                        }
                    }
                }
            }

            foreach (Block block in collisions)
            {
                bool isColliding = this.sprite.GetGlobalBounds().Intersects(block.sprite.GetGlobalBounds());

                if (block.name == "house" || block.name == "cloud")
                    isColliding = false;
                float positionY = this.sprite.Position.Y;
                float positionX = this.sprite.Position.X;
                float playerHauteur = this.sprite.GetGlobalBounds().Height;
                float playerLargeur = this.sprite.GetGlobalBounds().Width;
                float blockLargeur = block.sprite.GetGlobalBounds().Width;
                float blockPositionX = block.sprite.Position.X;
                float blockPositionY = block.sprite.Position.Y;


                if (block.name == "ghost" && isColliding)
                {
                    Ghost g = (Ghost)block;
                    this.Life -= g.degats;
                    isColliding = false;
                }

                if (isColliding)
                {
                    if (block.name == "princess")
                    {
                        Princess p = (Princess)block;
                        if (!p.inPrison)
                        {
                            Score.savePrincess();

                            savePrincess = true;
                        }
                    }
                    if (block.name == "rock" && Keyboard.IsKeyPressed(Keyboard.Key.R) && this.GetType().ToString() == "Holdstock.Guerrier")
                    {
                        Rock r = (Rock)block;
                        r.sprite.Position = new Vector2f(r.sprite.Position.X, r.sprite.Position.Y + 100);
                        break;
                    }
                    if (block.GetType().ToString() == "Holdstock.Stuff")
                    {
                        s = (Stuff)block;
                        if (block.name == "fleche" && this.GetType().ToString() == "Holdstock.Archer")
                        {
                            if (s.price <= Pieces.nbRings)
                            {
                                Pieces.nbRings -= s.price;
                                isBuy = true;
                            }
                            Archer a = (Archer)this;
                            a.activated = true;
                        }
                        else if (block.name == "feu" && this.GetType().ToString() == "Holdstock.Sorciere")
                        {
                            if (s.price <= Pieces.nbRings)
                            {
                                Pieces.nbRings -= s.price;
                                isBuy = true;
                            }
                            Sorciere so = (Sorciere)this;
                            so.activated = true;
                        }
                    }
                }
                if (isColliding
                  &&
                 Y + playerHauteur >= blockPositionY)
                {
                    if (block.name == "ring")
                    {
                        collectCoinSound.Play();
                        Pieces.nbRings += 1;
                        takeRing = block;
                        Score.takeRings();
                    }
                    if (block.name == "potion")
                    {
                        Score.takeRings();
                        Potion popo = (Potion)block;
                        if (popo._type == "life")
                        {
                            this.Life += 100;
                            if (this.Life > MaxLife)
                                this.Life = MaxLife;
                        }
                        else if (popo._type == "mana")
                        {
                            this.Mana += 100;
                            if (this.Mana > 100)
                                this.Mana = 100;
                        }
                        takePopo = block;
                    }

                    if (takeRing != null)
                    {
                        collisions.Remove(takeRing);
                        takeRing = null;
                        break;
                    }
                    if (takePopo != null)
                    {
                        collisions.Remove(takePopo);
                        takePopo = null;
                        break;
                    }


                    else if ((blockPositionX - (positionX + playerLargeur) <= 0) &&
                   (blockPositionX - (positionX + playerLargeur) > -20))
                    {
                        Console.WriteLine("collision gauche");

                        if (this.GetType().ToString() == "Holdstock.Guerrier" && block.name == "box")
                        {
                            block.moveSprite(positionX + playerLargeur, block.sprite.Position.Y);
                        }
                        else
                        {
                            this.X = blockPositionX - playerLargeur;
                            leftCollision = true;
                            break;
                        }
                    }
                    else if ((blockPositionY + blockLargeur - positionY) <= 30)
                    {
                        upCollision = true;
                        this.Y = blockPositionY + blockLargeur;
                        Console.WriteLine("Collision Haut");
                    }
                    else if (((blockPositionX + blockLargeur) - (positionX) <= 25) &&
             (blockPositionX + blockLargeur - positionX > 0))
                    {
                        Console.WriteLine("collision droite");

                        if (this.GetType().ToString() == "Holdstock.Guerrier" && block.name == "box")
                        {
                            block.moveSprite(positionX - blockLargeur, block.sprite.Position.Y);
                        }
                        else
                        {
                            Console.WriteLine((blockPositionX + blockLargeur) - (positionX));
                            this.X = blockPositionX + blockLargeur;
                            rightCollision = true;
                            break;
                        }
                    }
                    else if (!isonground)
                    {

                        Console.WriteLine((blockPositionX + blockLargeur) - (positionX));
                        this.Y = blockPositionY - playerHauteur;
                        isJumping = false;
                        isonground = true;
                    }
                }
                if (!((X <= blockPositionX && X + playerLargeur >= blockPositionX)
                    || (X >= blockPositionX + blockLargeur && X <= blockPositionX)
                    || (X >= blockPositionX && X + playerLargeur >= blockPositionX + blockLargeur && X <= blockPositionX + blockLargeur)))
                    isonground = false;


                if (blockPositionY == Y + playerHauteur &&
                                   (((X <= blockPositionX && X + playerLargeur >= blockPositionX)
                                   || (X >= blockPositionX + blockLargeur && X <= blockPositionX)
                                   || ((X >= blockPositionX && X + playerLargeur >= blockPositionX + blockLargeur && X <= blockPositionX + blockLargeur) && block.name != "spikes")
                                   || (X >= blockPositionX && X + playerLargeur <= blockPositionX + blockLargeur))))
                {
                    if (block.name == "spikes")
                        this.Life -= Spikes.lifeTaken;
                    if (block.name == "interrupteur")
                    {
                        Console.WriteLine("Interupteur");
                        Interrupteur inte = (Interrupteur)block;
                        inte.activate();
                        if (princess != null)
                            princess.activate();
                    }

                    Console.WriteLine(block.name);
                    isonground = true;
                    break;
                }
            }
            if (isBuy)
            {
                collisions.Remove(s);
            }

            if (!isonground && !isJumping && !leftCollision && !rightCollision && !upCollision)
            {
                //  yVel = 18;
                yVel += this.gravity;
                Y += yVel;
            }
            
            if (isJumping)
            {
                isonground = false;

                yVel += this.gravity;
                Y += yVel;

            }
        }

        public abstract void jump();

        public virtual void ChangeSize()
        {

        }

        public FloatRect collisionRect;

        public void updatePosition(double x, double y)
        {
            sprite.Position = new Vector2f((float)x, (float)y);
            X = x;
            Y = y;
        }

        public int getPercentageLife()
        {
            return (int)(((double)this.Life / (double)this.MaxLife) * 100);
        }


    }
}
