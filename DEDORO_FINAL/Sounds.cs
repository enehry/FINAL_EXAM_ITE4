using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace DEDORO_FINAL
{
    public class Sounds
    {
        public static void playFireFlies()
        {
            SoundPlayer fireflies = new SoundPlayer();
            fireflies.SoundLocation = "Sounds/fireflies.wav";
            fireflies.PlayLooping();
        }



    }
}
