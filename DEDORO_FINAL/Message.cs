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

        public static Color BoxColor = Color.White;

        public static Color BoxtextColor = Color.Black;

        public static void Show(string text, string button)
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

        public static void ShowDark(string text, string button)
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
            Console.BackgroundColor = Color.Blue;
            for (int i = 0; i < messageBox.Length; i++)
            {
                
                Console.SetCursorPosition((Console.WindowWidth - messageBox[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(messageBox[i], Color.White);

            }
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop - 4);
            Console.WriteLine(text, Color.Black);
            Console.SetCursorPosition((Console.WindowWidth - button.Length) / 2, Console.CursorTop + 1);
            Console.WriteLine(button, Color.Black);
            Console.BackgroundColor = Color.Black;

        }

        //Box Creator
        public static void CreateBox(string title, int height, int width, string button)
        {
            
           
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                Console.BackgroundColor = BoxColor;
                Console.ForegroundColor = BoxtextColor;
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


        public static void menuBox(int height, int width, string text, ConsoleColor bgColor, ConsoleColor textColor, int spacing = 0, int pos = 0)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(((Console.WindowWidth - width)/2)-pos, Console.CursorTop);
                System.Console.BackgroundColor = bgColor;
                System.Console.ForegroundColor = textColor;
                for (int j = 0; j < width; j++)
                {
                    System.Console.Write(" ");
                }
                Console.WriteLine();
            }

            
            Console.SetCursorPosition(((Console.WindowWidth - text.Length) / 2)-pos, Console.CursorTop-(height/2)-1);
            Console.WriteLine(text);
            Console.SetCursorPosition(((Console.WindowWidth - text.Length) / 2)-pos, Console.CursorTop + (height / 2) + spacing);


        }


        public static void TitleBox(string title, int height, int width,ConsoleColor bgColor,ConsoleColor txtColor)
        {

            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                System.Console.BackgroundColor = bgColor;
                System.Console.ForegroundColor = txtColor;
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


            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop - (height/2)-1);
            Console.WriteLine(title);
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop+(height/2));


        }// TitleBox END
    }
}
