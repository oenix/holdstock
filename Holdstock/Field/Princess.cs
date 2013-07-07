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
    class Princess : Block
    {
        RenderTarget _windows;
        public bool inPrison;

        public Princess(RenderTarget window)
        {
            this.name = "princess";
            _windows = window;
            inPrison = true;
            sprite = new SpriteAnimated(BlockTextures.princessPrison, 370, 370, 1, _windows, RenderStates.Default, 0, 0, true, true);
        }

        public Princess(Vector2f position, RenderTarget window)
            : this(window)
        {
            this.sprite.Position = position;
            this.position = position;
        }

        public void activate()
        {
            this.sprite = sprite = new SpriteAnimated(BlockTextures.princess, 370, 370, 1, _windows, RenderStates.Default, 0, 0, true, true);
            this.sprite.Position = position;
            this.position = position;
            inPrison = false;
        }

        public void desactivate()
        {
            this.sprite = sprite = new SpriteAnimated(BlockTextures.princessPrison, 370, 370, 1, _windows, RenderStates.Default, 0, 0, true, true);
            this.sprite.Position = position;
            this.position = position;
            inPrison = true;
        }
    }
}
