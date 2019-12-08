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
        public void zetaAnimation()
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
                  

                    string key = "PRESS ANY KEY TO START";
                    Console.SetCursorPosition((Console.WindowWidth - key.Length) / 2, Console.CursorTop + 3);
                    Console.WriteLine(key,Color.White);
                    Thread.Sleep(500);
                    Console.Clear();
                }

                
                Console.Clear();

            }
        }
    }
}
