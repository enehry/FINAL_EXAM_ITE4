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




            //Program pr = new Program();

            Animations animate = new Animations();

            ThreadStart Animation = new ThreadStart(animate.zetaAnimation);
            Thread animation = new Thread(Animation);
            animation.Start();

            ConsoleKey stop = Console.ReadKey().Key;

            if (stop.Equals(ConsoleKey.Enter))
            {
                animation.Abort();
                Console.BackgroundColor = Color.Black;
                Console.ForegroundColor = Color.White;
                Console.ReplaceAllColorsWithDefaults();
                Console.Clear();
                UserInterface ui = new UserInterface();
                ThreadStart main = new ThreadStart(ui.Initialize);
                Thread Main = new Thread(main);
                Main.Start();
                
                

            }

        }


        


    }
}

