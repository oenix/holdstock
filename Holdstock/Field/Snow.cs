
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
    class Snow : Block
    {
        static int speed = 2;

        public Snow(RenderTarget window, String placement)
        {
            this.name = "snow";
            switch (placement)
            {
                case "Solo":
                    sprite = new SpriteAnimated(BlockTextures.snowSolo, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "TopLeft":
                    sprite = new SpriteAnimated(BlockTextures.snowTopLeft, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Top":
                    sprite = new SpriteAnimated(BlockTextures.snow, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "TopRight":
                    sprite = new SpriteAnimated(BlockTextures.snowTopRight, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Left":
                    sprite = new SpriteAnimated(BlockTextures.snowLeft, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Middle":
                    sprite = new SpriteAnimated(BlockTextures.snowMiddle, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Right":
                    sprite = new SpriteAnimated(BlockTextures.snowRight, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "BottomLeft":
                    sprite = new SpriteAnimated(BlockTextures.snowBottomLeft, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "BottomMid":
                    sprite = new SpriteAnimated(BlockTextures.snowBottomMid, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "BottomRight":
                    sprite = new SpriteAnimated(BlockTextures.snowBottomRight, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                default:
                    break;
            }
            // sprite = new SpriteAnimated(BlockTextures.grass, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
            //this.sprite = new SpriteAnimated(BlockTextures.grass);
        }

        public Snow(Vector2f position, String placement, RenderTarget window)
            : this(window, placement)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
