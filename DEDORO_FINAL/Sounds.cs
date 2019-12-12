using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace DEDORO_FINAL
{

    // Sound class handles the all the sound of the system
    public class Sounds
    {
        static SoundPlayer fireflies = new SoundPlayer();
        public static void playFireFlies()
        {
          
            fireflies.SoundLocation = "Sounds/fireflies.wav";
            fireflies.PlayLooping();
           
        }

        public static void Stop()
        {
            Thread.Sleep(1000);
            fireflies.Stop();
        }
 

    }
}
