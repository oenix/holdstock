using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdstock
{
    public static class MusicManagement
    {
        public static Music GameMusic { get; set; }
        public static bool IsPlaying { get; set; }

        public static void startPlaying()
        {
            GameMusic.Play();
        }

        public static void stopPlaying()
        {
            GameMusic.Pause();
        }
    }
}
