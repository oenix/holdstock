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
    class Interrupteur : Block
    {
        RenderTarget _windows;
        bool activated;

        public Interrupteur(RenderTarget window)
        {
            this.name = "interrupteur";
            _windows = window;
            sprite = new SpriteAnimated(BlockTextures.interrupteur, 100, 100, 1, _windows, RenderStates.Default, 0, 0, true, true);
        }

        public Interrupteur(Vector2f position, RenderTarget window) : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }

        public void activate()
        {
            this.sprite = sprite = new SpriteAnimated(BlockTextures.interrupteurOn, 100, 100, 1, _windows, RenderStates.Default, 0, 0, true, true);
            this.sprite.Position = position;
            this.position = position;
            activated = true;
        }

        public void desactivate()
        {
            this.sprite = sprite = new SpriteAnimated(BlockTextures.interrupteur, 100, 100, 1, _windows, RenderStates.Default, 0, 0, true, true);
            this.sprite.Position = position;
            this.position = position;
            activated = false;
        }
    }
}
