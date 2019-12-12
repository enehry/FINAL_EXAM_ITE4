using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using Console = Colorful.Console;
using System.Drawing;
using Colorful;

namespace DEDORO_FINAL
{
    class Program
    {

        public static void Main(string[] args)
        {

            // Starting point of the program

            Console.SetWindowPosition(0, 0);
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;

            //Thread that play sound
            ThreadStart sounds = new ThreadStart(Sounds.playFireFlies);
            Thread sound = new Thread(sounds);
            sound.Start();


            // Thread that play animation
            ThreadStart Animation = new ThreadStart(Animations.zetaAnimation);
            Thread animation = new Thread(Animation);
            animation.Start();


            ConsoleKey stop = Console.ReadKey().Key;

            if (!stop.Equals(ConsoleKey.Escape))
            {

                animation.Abort();
                Console.ReplaceAllColorsWithDefaults();
                Console.BackgroundColor = Color.Black;
                Console.ForegroundColor = Color.White;
                Console.Clear();
                Animations.SpaceShipLoading();
                Sounds.Stop();

                // Calling the User interface of the system
                UserInterface ui = new UserInterface();
                ThreadStart main = new ThreadStart(ui.Initialize);
                Thread Main = new Thread(main);

                Main.Start();

            }




        }





    }
}

