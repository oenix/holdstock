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
    static class CreateWorld
    {
        static public List<Block> readWorldFile(RenderTarget window)
        {
            List<Block> world = new List<Block>();
            string[] lines = System.IO.File.ReadAllLines(@"World/world" + Level.ActualLevel + ".txt");
            Random random = new Random();

            int j = 0;
            foreach (string line in lines)
            {
                for(int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '0')
                        if(Level.ActualLevel < 3)
                           world.Add(new Grass(new SFML.Window.Vector2f(i * 100, j * 100), "Solo", window));
                    else if (line[i] == '1')
                            world.Add(new Ground(new SFML.Window.Vector2f(i * 100, j * 100), window));
                        else if (line[i] == '2')
                            world.Add(new Ring(new SFML.Window.Vector2f((i * 100) + 10, j * 100), window));
                        else if (line[i] == '3')
                            world.Add(new Box(new SFML.Window.Vector2f((i * 100), j * 100 + 1), window));
                        else if (line[i] == '4')
                            world.Add(new Spikes(new SFML.Window.Vector2f((i * 100), j * 100), window));
                        else if (line[i] == '5')
                            world.Add(new House(new SFML.Window.Vector2f((i * 100), j * 100 - 280), window));
                        else if (line[i] == '6')
                            world.Add(new Interrupteur(new SFML.Window.Vector2f((i * 100), j * 100), window));
                        else if (line[i] == '7')
                            world.Add(new Princess(new SFML.Window.Vector2f((i * 100), j * 100 - 260), window));
                        //    else if (line[i] == '8')
                        //       world.Add(new Ghost(new SFML.Window.Vector2f((i * 100), j * 100 - 115), window, random));
                        else if (line[i] == '9')
                            world.Add(new Cloud(new SFML.Window.Vector2f((i * 100), j * 100 - 115), window));
                        else if (line[i] == 'a')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'b')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "Top", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'c')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopRight", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'd')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "Left", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'e')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "Middle", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'f')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "Right", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'g')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "BottomLeft", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'h')
                        {
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "BottomMid", window));
                            else
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "TopLeft", window));
                        }
                        else if (line[i] == 'i')
                            if (Level.ActualLevel < 3)
                                world.Add(new Grass(new SFML.Window.Vector2f((i * 100), j * 100), "BottomRight", window));
                            else if (line[i] == '&')
                                world.Add(new Stuff(new SFML.Window.Vector2f((i * 100), j * 100), window, "fleche"));
                            else if (line[i] == 'é')
                                world.Add(new Stuff(new SFML.Window.Vector2f((i * 100), j * 100), window, "feu"));
                            else if (line[i] == 'm')
                                world.Add(new Potion(new SFML.Window.Vector2f((i * 100), j * 100), window, "mana"));
                            else if (line[i] == 'l')
                                world.Add(new Potion(new SFML.Window.Vector2f((i * 100), j * 100), window, "life"));
                            else if (line[i] == 'r')
                                world.Add(new Rock(new SFML.Window.Vector2f((i * 100), j * 100), window));

                }
                j++;
            }

            return world;
        }

        public static int getLines()
        {
            return System.IO.File.ReadAllLines(@"World/world1.txt").Length;
        }
    }
}
