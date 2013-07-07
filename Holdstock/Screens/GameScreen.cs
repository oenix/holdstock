using Holdstock;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;

namespace Holdstock
{
    class GameScreen : Screen
    {
        private RenderWindow _window;

        private ScreenChange _screenChange;

        public Stopwatch _timerTracker;

        bool enlair = false;

        private Music _mainMusic;
        public int activePlayer;

        public List<Character> _characters;
        public List<Missile> missiles;
        public List<Block> _worldBlock;

        private int _livingPlayers;

        private Vector2f _lifePosition;
        private Vector2f _manaPosition;
        private Vector2f _textPosition;

        private Font _font;

        private Text _winText;
        private Text _moneyText;
        private Text _objectiveText;

        private View _mainView;
        private RectangleShape _life;
        private RectangleShape _mana;

        public GameScreen(RenderWindow window)
        {
            /* Loading game music */

            _mainMusic = new Music("audio/" + Level.musicPerLevel());

            _mainMusic.Volume = 15;
            _mainMusic.Loop = true;

            MusicManagement.GameMusic = _mainMusic;
            MusicManagement.IsPlaying = true;

            MusicManagement.startPlaying();

            _window = window;
            _window.SetVisible(true);

            _timerTracker = new Stopwatch();

            _window.SetFramerateLimit(60);
            _timerTracker.Start();

            _window.Closed += new EventHandler(OnClosed);
            _window.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyRelease); 
            _window.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(OnMouseButtonReleased);

            _characters = new List<Character>();
            missiles = new List<Missile>();

            /* World creation */

            _worldBlock = CreateWorld.readWorldFile(_window);

            /* Loading font and texts */

            _font = new Font("Ressources/arial.ttf");

            _moneyText = new Text("", _font);
            _moneyText.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 1770);

            _textPosition = _moneyText.Position;

            _winText = new Text("VICTOIRE !!!", _font);

            _objectiveText = new Text("Votre objectif : + " + Level.objectives[Level.ActualLevel], _font);
            _objectiveText.CharacterSize = 40;
            _objectiveText.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 500);

            /* */

            _life = new RectangleShape(new Vector2f(200, 50));
            _life.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 1830);
            _life.FillColor = new Color(255, 0, 0);

            _mana = new RectangleShape(new Vector2f(200, 50));
            _mana.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 1800);
            _mana.FillColor = new Color(0, 255, 255);


            _lifePosition = _life.Position;
            _manaPosition = _mana.Position;


            _livingPlayers = 3;

            /* Characters' management */

            _characters.Add(new Archer(0, 770, _window));
            _characters.Add(new Sorciere(0, 770, _window));
            _characters.Add(new Guerrier(0, 770, _window));

            // Load a sprite to display
            this.activePlayer = 0;
        }

        public override void Init()
        {

            _characters = new List<Character>();
           missiles = new List<Missile>();

            /* World creation */

            _worldBlock = CreateWorld.readWorldFile(_window);

            /* Loading font and texts */

            _font = new Font("Ressources/arial.ttf");

            _moneyText = new Text("", _font);
            _moneyText.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 1770);

            _textPosition = _moneyText.Position;

            _objectiveText = new Text("Niveau " + Level.ActualLevel + " Votre objectif : " + Level.objectives[Level.ActualLevel], _font);
            _objectiveText.CharacterSize = 40;
            _objectiveText.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 500);

            /* */

            _life = new RectangleShape(new Vector2f(200, 50));
            _life.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 1830);
            _life.FillColor = new Color(255, 0, 0);

            _mana = new RectangleShape(new Vector2f(200, 50));
            _mana.Position = new Vector2f(20, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 1800);
            _mana.FillColor = new Color(0, 255, 255);


            _lifePosition = _life.Position;
            _manaPosition = _mana.Position;

            _livingPlayers = 3;

            /* Characters' management */

            _characters.Add(new Archer(0, 770, _window));
            _characters.Add(new Sorciere(0, 770, _window));
            _characters.Add(new Guerrier(0, 770, _window));

            // Load a sprite to display
            this.activePlayer = 0;
            _mainView = new View();
            _mainView.Zoom((float)2);
            _mainView.Center = new Vector2f(1000, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 900);

            _window.SetView(_mainView);
        }

        public override ScreenChange Update()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            _moneyText.DisplayedString = "Pièces : " + Pieces.nbRings + " Score : " + Score.Points;

            _window.DispatchEvents();
            _window.Clear(Color.Blue);
            _window.SetView(_mainView);

            //DRAW

            //Draw the world
            foreach (Block block in _worldBlock)
            {
                //Draw only if near the character to save memory
                if (block.sprite.Position.X > _characters[activePlayer].sprite.Position.X - _window.Size.X * 2
                    && block.sprite.Position.X < _characters[activePlayer].sprite.Position.X + _window.Size.X * 2
                    )
                {
                    if (block.name == "ring")
                        block.sprite.Update(_timerTracker.Elapsed);
                    else
                        block.draw(_window);
                }
                if (block.name == "ghost")
                    ((Ghost)block).update();
                if (block.name == "cloud")
                    ((Cloud)block).update();

            }

            _window.Draw(_life);
            _window.Draw(_mana);

            _window.Draw(_moneyText);
            _window.Draw(_objectiveText);
        }

        public override ScreenChange Run()
        {
            _screenChange = ScreenChange.sameScreen;

            if (_characters.Count == 0)
                return ScreenChange.deathScreen;

            Draw();

            _characters[activePlayer].sprite.Update(_timerTracker.Elapsed);

            if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Q))
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    _characters[activePlayer].moveRight(_timerTracker.Elapsed);

                    //caracters[activePlayer].SetSPrite("movingRight");
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                    _characters[activePlayer].moveLeft();
            }
            else
            {
                for (int i = 0; i < _characters.Count; i++)
                    _characters[i].xSpeed = 0;
                _characters[activePlayer].SetSPrite("staying");
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                _characters[activePlayer].jump();
            }

            //update missiles
            foreach (Missile missile in missiles.GetRange(0, missiles.Count()))
            {
                missile.update(_worldBlock, _timerTracker.Elapsed);
                if (missile.X > _characters[activePlayer].sprite.Position.X + _window.GetView().Size.X * 2
                    || missile.X < _characters[activePlayer].sprite.Position.X - _window.GetView().Size.X * 2
                    || missile.Y > _characters[activePlayer].sprite.Position.Y + _window.GetView().Size.Y * 2
                    || missile.Y < _characters[activePlayer].sprite.Position.Y - _window.GetView().Size.Y * 2
                    || (missile.timerTracker != null && missile.timerTracker.Elapsed.Milliseconds > 300))
                    missiles.Remove(missile);
                else
                {


                    //  missile.Draw(_window);
                }
            }
            _characters[activePlayer].update(_worldBlock);

            //UPDATE

            _life.Size = new Vector2f(_characters[activePlayer].getPercentageLife() * 2, 10);

            _mana.Size = new Vector2f(_characters[activePlayer].Mana * 2, 10);

            Vector2f viePos1 = new Vector2f(_characters[activePlayer].sprite.Position.X - _characters[activePlayer].decalage - 575, _lifePosition.Y);
            Vector2f viePos2 = new Vector2f(_characters[activePlayer].sprite.Position.X - _characters[activePlayer].decalage - 575, _lifePosition.Y - 300);

            Vector2f ringPos1 = new Vector2f(_characters[activePlayer].sprite.Position.X - _characters[activePlayer].decalage - 575, _textPosition.Y);
            Vector2f ringPos2 = new Vector2f(_characters[activePlayer].sprite.Position.X - _characters[activePlayer].decalage - 575, _textPosition.Y - 300);

            Vector2f manaPos1 = new Vector2f(_characters[activePlayer].sprite.Position.X - _characters[activePlayer].decalage - 575, _manaPosition.Y);
            Vector2f manaPos2 = new Vector2f(_characters[activePlayer].sprite.Position.X - _characters[activePlayer].decalage - 575, _manaPosition.Y - 300);
           
            if (_characters[activePlayer].sprite.Position.X > 1000)
            {
                Console.WriteLine(_life.Position.Y);
                _mainView.Center = new Vector2f(_characters[activePlayer].sprite.Position.X, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y -  900); //+ taille ecran div 2
                _life.Position = viePos1;
                _mana.Position = manaPos1;
                _moneyText.Position = ringPos1;

                if (_characters[activePlayer].sprite.Position.Y < 150 && (!_characters[activePlayer].isJumping || enlair))
                {
                    Console.WriteLine("Life position " + viePos2);
                  //  _mainView.Center = new Vector2f(_characters[activePlayer].sprite.Position.X + 75, _characters[activePlayer].sprite.Position.Y); //+ taille ecran div 2
                    _mainView.Center = new Vector2f(_characters[activePlayer].sprite.Position.X, _worldBlock[_worldBlock.Count - 1].sprite.Position.Y - 1200); //+ taille ecran div 2
                    _life.Position = viePos2;
                    _mana.Position = manaPos2;
                    _moneyText.Position = ringPos2;
                    enlair = true;
                }
                else
                    enlair = false;

                if (_characters[activePlayer].savePrincess)
                {
                    Level.ActualLevel += 1;
                    _winText.Position = new Vector2f(_characters[activePlayer].sprite.Position.X, _characters[activePlayer].sprite.Position.Y - 250);
                    _window.Draw(_winText);
                    _screenChange = ScreenChange.gameScreen;
                }
            }

            int money = Pieces.nbRings;

            foreach (Character car in _characters)
            {
                car.updatePosition(_characters[activePlayer].X, _characters[activePlayer].Y);
            }
            Pieces.nbRings = money;

            if (_characters[activePlayer].Life < 0)
            {
                _characters.Remove(_characters[activePlayer]);
                _livingPlayers--;
                swapPlayers();
            }

            _timerTracker.Restart();
            _window.Display();

            return _screenChange;
        }

        void OnClosed(object sender, EventArgs e)
        {
            _window.Close();
        }

        void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            Window window = (Window)sender;

            #region Necessary hack because of garbage collector failures 

            if (_characters.Count <= 0)
                return;

            #endregion

            if (e.Button == Mouse.Button.Left)
            {
                Missile missile = _characters[activePlayer].attack(_window, _window);

                if (missile != null)
                {
                    missiles.Add(missile);
                    missile.update(_worldBlock, _timerTracker.Elapsed);
                }
            }
            if (e.Button == Mouse.Button.Right)
            {
                Missile missile = _characters[activePlayer].attackSpecial(_window, _window);
                if (missile != null)
                {
                    missiles.Add(missile);
                   // missile.update(_worldBlock, _timerTracker.Elapsed);
                }
            }
        }

        void OnKeyRelease(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;

            #region Necessary hack because of garbage collector failures

            if (_characters.Count <= 0)
                return;

            #endregion

            if (e.Code == Keyboard.Key.Space)
            {
                this.swapPlayers();
            }

            if (e.Code == Keyboard.Key.Escape)
            {
                _screenChange = ScreenChange.pauseScreen;
            }

            if (e.Code == Keyboard.Key.C)
            {
                Console.WriteLine("(" + _characters[activePlayer].X + "," + _characters[activePlayer].Y + ")");
            }

            if (e.Code == Keyboard.Key.R)
            {
                _characters[activePlayer].ChangeSize();

            }
        }

        void swapPlayers()
        {
            if (this.activePlayer >= (_livingPlayers - 1))
                this.activePlayer = 0;
            else
                this.activePlayer += 1;
        }

    }
}
