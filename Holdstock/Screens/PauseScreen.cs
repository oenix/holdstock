using SFML.Graphics;
using SFML.Window;
using SfmlFirstTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdstock
{
    class PauseScreen : Screen
    {
        private Font _menuFont;
        private Text _selectorText;
        private List<Text> _menuOptions;

        private existingOptions _selectedOption;

        private Keyboard.Key _previousPressedKey;

        private RenderWindow _window;

        public enum existingOptions : short
        {
            resumeGame = 0,
            musicGame = 1,
            exitGame = 2
        }

        public PauseScreen(RenderWindow window)
        {
            _window = window;
            _menuOptions = new List<Text>();
            _menuFont = new Font("Ressources/arial.ttf");

            /* Start new game button configuration */

            Text resumeGameText = new Text("Resume Game", _menuFont, 16);

            resumeGameText.Color = new Color(255, 255, 255);
            resumeGameText.Position = new Vector2f(window.Size.X / 2 - 50, window.Size.Y / 2 - 60);

            _menuOptions.Add(resumeGameText);

            /* Default option selection cursor */

            _selectorText = new Text("->", _menuFont, 16);

            _selectorText.Color = new Color(255, 255, 255);
            _selectorText.Position = new Vector2f(resumeGameText.Position.X - 40, resumeGameText.Position.Y);

            /* Start new game button configuration */

            Text musicGameText = new Text("Music : ON", _menuFont, 16);

            musicGameText.Color = new Color(255, 255, 255);
            musicGameText.Position = new Vector2f(window.Size.X / 2 - 50, window.Size.Y / 2 - 00);

            _menuOptions.Add(musicGameText);

            /* Exit game button configuration */

            Text exitGameText = new Text("Leave Game", _menuFont, 16);

            exitGameText.Color = new Color(255, 255, 255);
            exitGameText.Position = new Vector2f(window.Size.X / 2 - 50, window.Size.Y / 2 + 60);

            _menuOptions.Add(exitGameText);
        }

        public override void Init()
        {
            _previousPressedKey = Keyboard.Key.Unknown;

            _window.SetView(_window.DefaultView);
        }

        public override ScreenChange Update()
        {
            /* The user changes the current selected option */

            if (_previousPressedKey == Keyboard.Key.Down && !Keyboard.IsKeyPressed(Keyboard.Key.Down)) // Down
            {
                /* If last option, go to the first one */

                if (_selectedOption == existingOptions.exitGame)
                    _selectedOption = existingOptions.resumeGame;
                else
                    _selectedOption++;

                /* Update the cursor position */

                Vector2f selectedOptionPosition = _menuOptions[(short)_selectedOption].Position;

                _selectorText.Position = new Vector2f(selectedOptionPosition.X - 40, selectedOptionPosition.Y);
            }
            else if (_previousPressedKey == Keyboard.Key.Up && !Keyboard.IsKeyPressed(Keyboard.Key.Up)) // Up
            {
                /* If first option, go to the last one */

                if (_selectedOption == existingOptions.resumeGame)
                    _selectedOption = existingOptions.exitGame;
                else
                    _selectedOption--;

                /* Update the cursor position */

                Vector2f selectedOptionPosition = _menuOptions[(short)_selectedOption].Position;

                _selectorText.Position = new Vector2f(selectedOptionPosition.X - 40, selectedOptionPosition.Y);
            }
            else if (_previousPressedKey == Keyboard.Key.Return && !Keyboard.IsKeyPressed(Keyboard.Key.Return)) // Enter
            {
                if (_selectedOption == existingOptions.resumeGame)
                    return ScreenChange.gameScreen;
                else if (_selectedOption == existingOptions.exitGame)
                    return ScreenChange.menuScreen;
                else if (_selectedOption == existingOptions.musicGame)
                {
                    if (MusicManagement.IsPlaying)
                    {
                        MusicManagement.stopPlaying();

                        _menuOptions[(int)existingOptions.musicGame].DisplayedString = "Music : OFF";
                    }
                    else
                    {
                        MusicManagement.startPlaying();

                        _menuOptions[(int)existingOptions.musicGame].DisplayedString = "Music : ON";
                    }

                    MusicManagement.IsPlaying = !MusicManagement.IsPlaying;
                }
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
