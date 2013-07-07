using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdstock
{
    class DeathScreen : Screen
    {
        private Font _menuFont;

        private Text _selectorText;

        private Text _deathInfosText;
        private Text _deathScoreText;

        private List<Text> _menuOptions;

        private existingOptions _selectedOption;

        private Keyboard.Key _previousPressedKey;

        private RenderWindow _window;

        public enum existingOptions : short
        {
            restartGame = 0,
            exitGame = 1
        }

        public DeathScreen(RenderWindow window)
        {
            _window = window;
            _menuOptions = new List<Text>();
            _menuFont = new Font("Ressources/arial.ttf");

            /* Death informations configuration */

            _deathInfosText = new Text("You are dead... :/", _menuFont, 20);

            _deathInfosText.Color = new Color(255, 255, 255);
            _deathInfosText.Position = new Vector2f(window.Size.X / 2 - 50, 150);


            _deathScoreText = new Text("You reached " + Score.Points + " points.", _menuFont, 18);

            _deathScoreText.Color = new Color(255, 255, 255);
            _deathScoreText.Position = new Vector2f(window.Size.X / 2 - 50, 200);

            /* */

            Text restartGameText = new Text("Restart Game", _menuFont, 16);

            restartGameText.Color = new Color(255, 255, 255);
            restartGameText.Position = new Vector2f(window.Size.X / 2 - 50, window.Size.Y / 2 - 30);

            _menuOptions.Add(restartGameText);

            /* Default option selection cursor */

            _selectorText = new Text("->", _menuFont, 16);

            _selectorText.Color = new Color(255, 255, 255);
            _selectorText.Position = new Vector2f(restartGameText.Position.X - 40, restartGameText.Position.Y);

            /* Exit game button configuration */

            Text exitGameText = new Text("Go back to menu", _menuFont, 16);

            exitGameText.Color = new Color(255, 255, 255);
            exitGameText.Position = new Vector2f(window.Size.X / 2 - 50, window.Size.Y / 2 + 30);

            _menuOptions.Add(exitGameText);
        }

        public override void Init()
        {
            _previousPressedKey = Keyboard.Key.Unknown;

            _window.SetView(_window.DefaultView);

            _deathScoreText.DisplayedString = "You reached " + Score.Points + " points.";
        }

        public override ScreenChange Update()
        {
            /* The user changes the current selected option */

            if (_previousPressedKey == Keyboard.Key.Down && !Keyboard.IsKeyPressed(Keyboard.Key.Down)) // Down
            {
                /* If last option, go to the first one */

                if (_selectedOption == existingOptions.exitGame)
                    _selectedOption = existingOptions.restartGame;
                else
                    _selectedOption++;

                /* Update the cursor position */

                Vector2f selectedOptionPosition = _menuOptions[(short)_selectedOption].Position;

                _selectorText.Position = new Vector2f(selectedOptionPosition.X - 40, selectedOptionPosition.Y);
            }
            else if (_previousPressedKey == Keyboard.Key.Up && !Keyboard.IsKeyPressed(Keyboard.Key.Up)) // Up
            {
                /* If first option, go to the last one */

                if (_selectedOption == existingOptions.restartGame)
                    _selectedOption = existingOptions.exitGame;
                else
                    _selectedOption--;

                /* Update the cursor position */

                Vector2f selectedOptionPosition = _menuOptions[(short)_selectedOption].Position;

                _selectorText.Position = new Vector2f(selectedOptionPosition.X - 40, selectedOptionPosition.Y);
            }
            else if (_previousPressedKey == Keyboard.Key.Return && !Keyboard.IsKeyPressed(Keyboard.Key.Return)) // Enter
            {
                if (_selectedOption == existingOptions.restartGame)
                    return ScreenChange.gameScreen;
                else if (_selectedOption == existingOptions.exitGame)
                    return ScreenChange.menuScreen;
            }

            /* Update the previous pressed key for realeased handling */

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                _previousPressedKey = Keyboard.Key.Up;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                _previousPressedKey = Keyboard.Key.Down;
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                _previousPressedKey = Keyboard.Key.Return;
            else
                _previousPressedKey = Keyboard.Key.Unknown;

            return ScreenChange.sameScreen;
        }

        public override void Draw()
        {
            _window.Clear();

            _window.Draw(_deathInfosText);
            _window.Draw(_deathScoreText);

            foreach (Text option in _menuOptions)
            {
                _window.Draw(option);
            }

            _window.Draw(_selectorText);

            _window.Display();
        }

        public override ScreenChange Run()
        {
            ScreenChange screenChange = Update();

            Draw();

            return screenChange;
        }
    }
}
