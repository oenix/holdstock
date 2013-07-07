using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdstock
{
    public enum ScreenChange : int
    {
        sameScreen = -1,
        menuScreen = 0,
        gameScreen = 1,
        pauseScreen = 2,
        deathScreen = 3
    }

    public abstract class Screen
    {
        public abstract void Init();

        public abstract ScreenChange Update();

        public abstract void Draw();

        public abstract ScreenChange Run();
    }
}
