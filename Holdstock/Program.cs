using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;

namespace Holdstock
{
    class Program
    {
        static void Main(string[] args)
        {
            MySFMLProgram app = new MySFMLProgram();

            app.StartSFMLProgram();
        }
    }

    class MySFMLProgram
    {
        private RenderWindow _window;
    
        public int lines = CreateWorld.getLines();
 
        public void StartSFMLProgram()
        {
            /* Basic initialisations  */

            _window = new RenderWindow(new VideoMode(1280 , 1024), "Holdstock", Styles.Fullscreen);

            _window.SetVisible(true);
            
            _window.SetFramerateLimit(60);
           


            /* Set Level */

            Level.setLevels();

            /* Set Money */

            Pieces.init_Rings();

            /* Loading game textures */

            BlockTextures.loadTextures();
            CharactersTexture.loadTextures();
            MissilesTexture.loadTextures();

            /* Screen management */

            List<Screen> screens = new List<Screen>();

            int screenIndex = (int)ScreenChange.menuScreen;

            ScreenChange loopAction = ScreenChange.sameScreen;

            screens.Add(new MenuScreen(_window));
            screens.Add(new GameScreen(_window));
            screens.Add(new PauseScreen(_window));
            screens.Add(new DeathScreen(_window));

            /* Main loop game */

            bool isLeavingPause = false;

            while (_window.IsOpen())
            {
                loopAction = screens[screenIndex].Run();

                if (loopAction != ScreenChange.sameScreen)
                {
                    /* After death or when start a new game, reinit the game screen */

                    if (screenIndex == (int)ScreenChange.menuScreen || screenIndex == (int)ScreenChange.deathScreen)
                        screens[(int)ScreenChange.gameScreen] = new GameScreen(_window);

                    /* After resuming game after a pause, do not reinit */

                    if (screenIndex == (int)ScreenChange.pauseScreen && loopAction == ScreenChange.gameScreen)
                        isLeavingPause = true;

                    screenIndex = (int)loopAction;
                    
                    if (!isLeavingPause)
                        screens[screenIndex].Init();

                    isLeavingPause = false;
                }
            }
        }
    }
}
