using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;

namespace DEDORO_FINAL
{
    public class Message
    {

        public Color BoxColor = Color.White;

        public Color BoxtextColor = Color.Black;

        public void Show(string text, string button)
        {
            string[] messageBox =
            {
                "╔════════════════════   M E S S A G E  ═════════════════════╗",
                "║                                                           ║",
                "║                                                           ║",
                "║                                                           ║",
                "║                                                           ║",
                "╚═══════════════════════════════════════════════════════════╝",
            };
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = Color.White;
            for (int i = 0; i < messageBox.Length; i++)
            {
              
                Console.SetCursorPosition((Console.WindowWidth - messageBox[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(messageBox[i], Color.Black);

            }
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop - 4);
            Console.WriteLine(text,Color.Black);
            Console.SetCursorPosition((Console.WindowWidth - button.Length) / 2, Console.CursorTop + 1);
            Console.WriteLine(button,Color.Black);
            Console.BackgroundColor = Color.Black;

        }

        public void ShowDark(string text, string button)
        {
            string[] messageBox =
            {
                "╔════════════════════   M E S S A G E  ═════════════════════╗",
                "║                                                           ║",
                "║                                                           ║",
                "║                                                           ║",
                "║                                                           ║",
                "╚═══════════════════════════════════════════════════════════╝",
            };
            Console.WriteLine();
            Console.BackgroundColor = Color.Gray;
            for (int i = 0; i < messageBox.Length; i++)
            {
                
                Console.SetCursorPosition((Console.WindowWidth - messageBox[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(messageBox[i], Color.Black);

            }
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop - 4);
            Console.WriteLine(text, Color.Black);
            Console.SetCursorPosition((Console.WindowWidth - button.Length) / 2, Console.CursorTop + 1);
            Console.WriteLine(button, Color.Black);
            Console.BackgroundColor = Color.Black;

        }

        //Box Creator
        public void box(string title, int height, int width, string button)
        {
            
            Console.ForegroundColor = BoxtextColor;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                Console.BackgroundColor = BoxColor;
                Console.SetCursorPosition((Console.WindowWidth - width) / 2, Console.CursorTop);
                for (int j = 0; j < width; j++)
                {
                    
                    if (j == 0 && i == 0)
                    {
                        Console.Write("╔");
                    }
                    else if ((j < width - 1 && j > 0 && i == 0) || (j < width - 1 && j > 0 && i == height - 1))
                    {
                        Console.Write("═");
                    }

                    else if (j == width - 1 && i == 0)
                    {
                        Console.Write("╗");
                    }
                    else if (i == height - 1 && j == 0)
                    {
                        Console.Write("╚");
                    }
                    else if (i == height - 1 && j == width - 1)
                    {
                        Console.Write("╝");
                    }
                    else if ((j == 0 || j == width - 1) && !(j == 0 && i == 0 && j == width - 1 && i == 0 && i == height - 1 && i == width - 1 && i == height - 1 && i == 0))
                    {
                        Console.Write("║");
                    }

                    else
                    {
                        Console.Write(" ");
                    }


                }

                Console.WriteLine();
            }// Loop End


            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop - height);
            Console.WriteLine(title);

            Console.SetCursorPosition((Console.WindowWidth - button.Length) / 2, Console.CursorTop + (height - 3));
            Console.WriteLine(button);

        }// Box Creator END
    }
}
