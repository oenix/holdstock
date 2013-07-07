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
    class Grass : Block
    {
        static int speed = 2;

        public Grass(RenderTarget window, String placement)
        {
            this.name = "grass";
            switch (placement)
            {
                case "Solo":
                    sprite = new SpriteAnimated(BlockTextures.grassSolo, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "TopLeft":
                    sprite = new SpriteAnimated(BlockTextures.grassTopLeft, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Top":
                    sprite = new SpriteAnimated(BlockTextures.grass, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "TopRight":
                    sprite = new SpriteAnimated(BlockTextures.grassTopRight, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Left":
                    sprite = new SpriteAnimated(BlockTextures.grassLeft, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Middle":
                    sprite = new SpriteAnimated(BlockTextures.grassMiddle, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "Right":
                    sprite = new SpriteAnimated(BlockTextures.grassRight, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "BottomLeft":
                    sprite = new SpriteAnimated(BlockTextures.grassBottomLeft, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "BottomMid":
                    sprite = new SpriteAnimated(BlockTextures.grassBottomMid, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                case "BottomRight":
                    sprite = new SpriteAnimated(BlockTextures.grassBottomRight, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
                    break;
                default:
                    break;
            }
           // sprite = new SpriteAnimated(BlockTextures.grass, 100, 100, 1, window, RenderStates.Default, 0, 2, false, true);
            //this.sprite = new SpriteAnimated(BlockTextures.grass);
        }

        public Grass(Vector2f position, String placement, RenderTarget window) : this(window, placement)
        {
            this.sprite.Position = position;
            this.position = position;
        }
    }
}
