using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEDORO_FINAL
{
    public class ColorGame
    {

        private ConsoleColor bgColor;
        int score = 1;
        public void gameStart()
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            bgColor = generateColor();
          
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Message.CreateBox(" I N S T R U C T I O N", 6, 52, "");
            string[] ins =
            {
                "Choose the letter of your guess",
                "if your guess is correct the score will be added",
                "else if your guess is wrong game over !",
          
            };
            
            Console.CursorTop = 3;
            for (int i = 0; i < ins.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - ins[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(ins[i]);
             
            }
            Message.menuBox(1, 20, $"Score : {score}", ConsoleColor.White, bgColor, -2);
            Console.WriteLine();
            Console.CursorTop = 9;
            Message.CreateBox("", 22, 34, "");
            
            
            Console.CursorTop = 7;
            Message.TitleBox(" C O L O R  G A M E ", 5, 30, ConsoleColor.Red, ConsoleColor.White);
            Console.WriteLine();
            Console.WriteLine();
            Message.menuBox(3, 36, "A. C O L O R  R E D", ConsoleColor.Red, ConsoleColor.White,1);
            Message.menuBox(3, 36, "B. C O L O R  B L U E", ConsoleColor.Blue, ConsoleColor.White,1);
            Message.menuBox(3, 36, "C. C O L O R  Y E L L O W", ConsoleColor.Yellow, ConsoleColor.Black,1);
            Message.menuBox(3, 36, "D. C O L O R  G R E E N", ConsoleColor.Green, ConsoleColor.Black,1);
            ConsoleKey guess = Console.ReadKey().Key;

            ConsoleColor color;

            if (guess.Equals(ConsoleKey.A)) color = ConsoleColor.Red;
            else if (guess.Equals(ConsoleKey.B)) color = ConsoleColor.Blue;
            else if (guess.Equals(ConsoleKey.C)) color = ConsoleColor.Yellow;
            else  color = ConsoleColor.Green ;

            
            if (CheckColorGuess(color))
            {
                score += score;
                Message.TitleBox($" Your guess was correct ! Your score : {score}, press any key to continue !",5,72, ConsoleColor.Blue, ConsoleColor.White);
                Console.ReadKey();
                
                gameStart();
            }
            else
            {
        
                Message.TitleBox(" Your guess was wrong , Try again ? [Y]es/[N]o ", 5, 50, ConsoleColor.Red, ConsoleColor.White);
                ConsoleKey des = Console.ReadKey().Key;

                if (des.Equals(ConsoleKey.Y))
                {
                    score = 1;
                
                    gameStart();
                }
               
            }

            

        }

        public ConsoleColor generateColor()
        {
            Random rand = new Random();

            int num = rand.Next(1, 4);
            Console.WriteLine(num);

            if (num == 1)
            {
                bgColor = ConsoleColor.Red;
                return ConsoleColor.Red;
            }
            else if (num == 2)
            {
                bgColor = ConsoleColor.Blue;
                return ConsoleColor.Blue;
            }
            else if (num == 3)
            {
                bgColor = ConsoleColor.Yellow;
                return ConsoleColor.Yellow;
            }
            else
            {
                bgColor = ConsoleColor.Green;
                return ConsoleColor.Green;
            }
        }

        public bool CheckColorGuess(ConsoleColor color)
        {
            if (color == bgColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
