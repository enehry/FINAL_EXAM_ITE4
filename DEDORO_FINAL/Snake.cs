using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;

namespace DEDORO_FINAL
{
    public class Snake
    {
    
        protected string username;
        public Snake(string username)
        {
            this.username = username;
        }
        public void Initialize()
        {
            snakeForm();
        }


        private void snakeForm()
        {
        game:
            {
                
                Console.CursorVisible = (false);
                Console.Title = "Snaaaaake!";

               

                Console.SetWindowSize(56, 38);

                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                Console.ForegroundColor = Color.White;
                Console.BackgroundColor = Color.Black;
                Console.Clear();


                int delay = 100;
                string direction = "right";

                int snakeLength = 8;

                Random rnd = new Random();

                int score = 0;
                int x = 20;
                int y = 20;
                int colourTog = 1;
                bool alive = true;
                bool pelletOn = false;
                int pelletX = 0;
                int pelletY = 0;

                int[] xPoints;
                xPoints = new int[8] { 20, 19, 18, 17, 16, 15, 14, 13 };
                int[] yPoints;
                yPoints = new int[8] { 20, 20, 20, 20, 20, 20, 20, 20 };


                while (alive)
                {
                    if (pelletOn == false)
                    {
                        bool collide = false;
                        pelletOn = true;
                        pelletX = rnd.Next(4, Console.WindowWidth - 4);
                        pelletY = rnd.Next(4, Console.WindowHeight - 4);

                        for (int l = (xPoints.Length - 1); l > 1; l--)
                        {
                            if (xPoints[l] == pelletX & yPoints[l] == pelletY)
                            {
                                collide = true;
                            }
                        }
                        if (collide == true)
                        {
                            pelletOn = false;
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(pelletX, pelletY);
                            Console.ForegroundColor = Color.Cyan;
                            Console.BackgroundColor = Color.Black;
                            pelletOn = true;
                            Console.Write("*",Color.HotPink);
                        }

                           
                    }
                    Array.Resize<int>(ref xPoints, snakeLength);
                    Array.Resize<int>(ref yPoints, snakeLength);

                    System.Threading.Thread.Sleep(delay);
                    colourTog++;
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        switch (key.Key)
                        {
                            case ConsoleKey.RightArrow:
                                if (direction != "left")
                                {
                                    direction = "right";
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (direction != "right")
                                {
                                    direction = "left";
                                }
                                break;
                            case ConsoleKey.UpArrow:

                                if (direction != "down")
                                {
                                    direction = "up";
                                }
                                break;
                            case ConsoleKey.DownArrow:

                                if (direction != "up")
                                {
                                    direction = "down";
                                }
                                break;
                            default:
                                break;
                        }
                    } //Inputs & direction


                    if (direction == "right")
                    {
                        x += 1;
                    }
                    else if (direction == "left")
                    {
                        x -= 1;
                    }
                    else if (direction == "down")
                    {
                        y += 1;
                    }
                    else if (direction == "up")
                    {
                        y -= 1;
                    }

                    xPoints[0] = x;
                    yPoints[0] = y;

                    for (int l = (xPoints.Length - 1); l > 0; l--)
                    {
                        xPoints[l] = xPoints[l - 1];
                        yPoints[l] = yPoints[l - 1];
                    }


                    try
                    {
                        Console.SetCursorPosition(xPoints[0], yPoints[0]);
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        alive = false;
                    }
                    if (colourTog == 2)
                    {
                        System.Console.BackgroundColor = System.ConsoleColor.Green;
                    }
                    else
                    {
                        colourTog = 1;
                        Console.BackgroundColor = Color.Green;
                    }
                    Console.ForegroundColor = Color.White;
                    Console.Write(" ");

                    try
                    {
                        Console.SetCursorPosition(xPoints[xPoints.Length - 1], yPoints[yPoints.Length - 1]);
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        alive = false;
                    }
                    Console.BackgroundColor = Color.Black;
                    Console.Write(" ");

                    if (x == pelletX & y == pelletY)
                    {
                        pelletOn = false;
                        snakeLength += 1;
                        delay -= delay / 16;
                        new Thread(() => Console.Beep(320, 250)).Start();
                    }

                    for (int l = (xPoints.Length - 1); l > 1; l--)
                    {
                        if (xPoints[l] == xPoints[0] & yPoints[l] == yPoints[0])
                        {
                            alive = false;
                        }

                    }
                    score = ((snakeLength) - 8);
                    Console.SetCursorPosition(2, 2);
                    Console.ForegroundColor = Color.White;
                    Console.BackgroundColor = Color.Black;
                    Console.Write("Score : {0} \t\t\t", score);
                    Console.Write("Username : {0} ", username);

                }
                new Thread(() => Console.Beep(37, 1)).Start();
                Console.BackgroundColor = Color.Black;
                Console.Clear();
                /*
                Console.Beep(2093, 260);
                Console.Beep(1319, 260);
                Console.Beep(1047, 260);
                Console.Beep(1319, 260);
                Console.Beep(1760, 260);
                Console.Beep(1319, 260);
                Console.Beep(932, 260);
                Console.Beep(784, 260);
               
                Console.Beep(2093, 200);
                Console.Beep(1319, 200);
                Console.Beep(1047, 200);
                Console.Beep(1319, 200);
                Console.Beep(1760, 200);
                Console.Beep(1319, 200);
                */

                Console.Beep(831, 250);


                Console.Beep(785, 250);


                Database db = new Database();
                db.insertScore(username, score);


                System.ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));



                for (int i = 0; i < 1; i++)
                {
                    foreach (var color in colors)
                    {
                        Console.SetCursorPosition(0, 0);
                        System.Console.ForegroundColor = color;
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\n");
                        Console.WriteLine("\n                       Game over :(");
                        Console.WriteLine("\n\n                   Your score was: {0} !", score);
                        Thread.Sleep(100);
                    }
                }
                Thread.Sleep(1000);
                Message msg = new Message();
                Message.CreateBox(" PRESS THE KEY OF YOUR CHOICE ",5,53, "[M]enu | [Any key] to play again | [H]igh Score ");
                Console.CursorVisible = true;

                Console.ReadKey(true);

                ConsoleKey select = Console.ReadKey().Key;

                if (select.Equals(ConsoleKey.M))
                {
                    UserInterface ui = new UserInterface();
                    ui.USERNAME = username;
                  
                    ui.SystemMenu();
                    
                    Console.Clear();
                }
                else if (select.Equals(ConsoleKey.H))
                {
                   
                    highScores();
                }
                else
                {
                    goto game;
                }
               
            }
        }

        public void highScores()
        {

            Console.BackgroundColor = Color.Black;
            Console.ForegroundColor = Color.White;
            Console.Clear();

            Message msg = new Message();
             Message.CreateBox(" HIGH SCORES ", 30, 40, "[M]enu    [Any key] play again");


            Database db = new Database();

            var hss = db.GetHighScores();

            Console.SetCursorPosition(14, Console.CursorTop - 27);
            Console.WriteLine("USERNAME\t\tHIGH SCORE");
            foreach (var hs in hss)
            {
                Console.SetCursorPosition(14, Console.CursorTop);
                Console.WriteLine("{0} \t\t {1}", hs.un,hs.highScore);
            }


            ConsoleKey select = Console.ReadKey().Key;

            if (select.Equals(ConsoleKey.M))
            {
                UserInterface ui = new UserInterface();
                ui.USERNAME = username;

                ui.SystemMenu();

                Console.Clear();
            }
            else
            {
                snakeForm();
            }

        }
    
    }
}
