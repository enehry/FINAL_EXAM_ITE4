using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;
using System.Threading;

namespace DEDORO_FINAL
{
    public class Animations
    {
        public static void zetaAnimation()
        {

            
            string[,] zeta =
{
                {
                    " ███████████████████                                      ",
                    "               ███                                        ",
                    "             ███                                          ",
                    "           ███                                            ",
                    "         ███                                              ",
                    "       ███                                                ",
                    "     ███                                                  ",
                    "    ███                                                   ",
                    "  ███                                                     ",
                    "███████████████████                                       ",
                    "                                                          ",
                    "Z E R O                                                    ",

                },
                {
                    " ███████████████████                                      ",
                    "               ███                                        ",
                    "             ███                                          ",
                    "           ███                                            ",
                    "         ███   ████████████                               ",
                    "       ███                                                ",
                    "     ███                                                  ",
                    "    ███                                                   ",
                    "  ███                                                     ",
                    "███████████████████                                       ",
                    "                                                          ",
                    "Z E R O | E X A M                                          ",
                },
                {
                    " ███████████████████  ███████████████████                 ",
                    "               ███            ███                         ",
                    "             ███              ███                         ",
                    "           ███                ███                         ",
                    "         ███   ████████████   ███                         ",
                    "       ███                    ███                         ",
                    "     ███                      ███                         ",
                    "    ███                       ███                         ",
                    "  ███                         ███                         ",
                    "███████████████████           ███                         ",
                    "                                                          ",
                    "Z E R O | E X A M | T E R M I N A L                        ",
                },
                {
                    " ███████████████████  ███████████████████  ███            ",
                    "               ███            ███           ███           ",
                    "             ███              ███            ███          ",
                    "           ███                ███             ███         ",
                    "         ███   ████████████   ███              ███        ",
                    "       ███                    ███               ███       ",
                    "     ███                      ███  ████████████  ███      ",
                    "    ███                       ███                 ███     ",
                    "  ███                         ███                  ███    ",
                    "███████████████████           ███                   ███   ",
                    "                                                          ",
                    "Z E R O | E X A M | T E R M I N A L | A P P L I C A T I O N",
                },
            };

            int DA = 0;
            int V = 0;
            int ID = 255;
            int j, i;

            while (true)
            {

                for (i = 0; i < zeta.GetLength(0); i++)
                {
                    
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    for (j = 0; j < zeta.GetLength(1); j++)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - zeta[i, j].Length) / 2, Console.CursorTop);
                        Console.WriteLine(zeta[i, j],Color.FromArgb(DA,V,ID));
                        DA += 23;
                        V += 23;

                    }

                    DA = 0;
                    V = 0;
                  

                    string key = "PRESS ENTER KEY TO START";
                    Console.SetCursorPosition((Console.WindowWidth - key.Length) / 2, Console.CursorTop + 3);
                    Console.BackgroundColor = Color.Blue;
                    Console.WriteLine(key,Color.White);
                    Thread.Sleep(500);  
                    Console.BackgroundColor = Color.Black;
                    Console.Clear();
                }

                
                Console.Clear();

            }
        }


        public static void SpaceShipLoading()
        {

            string[] spaceShip1 = {
               "   __              ",
               "   \\ \\______     ",
               " ~~~[==     \\___  ",
               " ~~~[==_____/      ",
               "   /_/             ", };


            int j = 0;
            int i;
          

            while (j <= 100)
            {
                
                for (i = 0; i < spaceShip1.Length; i++)
                {
                    Console.SetCursorPosition(j, ((Console.WindowHeight - spaceShip1.Length)/2)+i);
                    Console.WriteLine(spaceShip1[i], Color.Yellow);


                }

              

                string loading = $"L O A D I N G  {j}   %";
                Console.SetCursorPosition((Console.WindowWidth - loading.Length) / 2, Console.CursorTop);
                Console.WriteLine(loading);
                Thread.Sleep(100);
                Console.Clear();
                
                i = 0;
                j += 10;
            }
                    
        }

        public static void SpaceShip()
        {

            for (int i = 1; i <= 100; i++)
            {
                if(i%2 == 0)
                {
                    Console.WriteLine(@"

        |
     \  :  /     
  `. __/ \__.'   
  _  \     / _ _ 
     /_   _\     
   .'  \ /  `.   
     /  :  \      
        |        ",Color.Yellow);
                }
                else
                {
                    Console.WriteLine(@"
        :
    \   |   /
     \  :  /     
  `. __/ \__ .'   
_ _  \     / _ _ 
     /_   _\     
   .'  \ /  `.   
     /  :  \      
   /    |    \
        :        ",Color.Goldenrod);
                }
                
                Thread.Sleep(5);
                Console.Clear();
                System.Console.WriteLine($"LOAING {i} %");
            }

            
            
          
        }
    }
}
