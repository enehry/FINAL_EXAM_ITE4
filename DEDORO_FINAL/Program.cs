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

            UserInterface ui = new UserInterface();
            ThreadStart main = new ThreadStart(ui.Initialize);
            Thread Main = new Thread(main);
            Main.Start();


            Program pr = new Program();

    



        }

     
        
    }
}

