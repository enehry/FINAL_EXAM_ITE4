using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Console = Colorful.Console;
using System.Drawing;
using Colorful;
using System.Speech.Synthesis;
using ConsoleTables;


namespace DEDORO_FINAL
{
    public class UserInterface
    {
    
       
       /// <summary>
       ///  USERINTERFACE CLASS
       ///  Separate the views of the system to its functionally, to easily manipulate the code
       ///  Changing anything from ui will not affect the other class
       /// </summary>
        private ConsoleKey select;

        public string USERNAME;
        

        public void Initialize()
        {
            
            LoginScreen();
           
        }


        Database db = new Database();
        int counter = 0;

        public void LoginScreen()
        {
            
            Console.Title = "(Z.E.T.A.) Zero sa Exam Terminal Application";
            string username, password;
            Console.BackgroundColor = Color.SeaGreen;
            Console.Clear();
            Console.CursorTop = 4;
            Message.CreateBox("", 13, 26, "");
            Console.CursorTop = 2;
            Message.TitleBox("L O G I N", 5, 20, ConsoleColor.Red, ConsoleColor.White);

          

            Message.BoxColor = Color.Blue;
            Message.BoxtextColor = Color.White;

           

         
            Message.CreateBox("  U S E R N A M E  ", 3, 30, "____");
            //syn.Speak("Enter your username");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 3, Console.CursorTop - 1);
            username = Console.ReadLine();

            Console.WriteLine();

            Message.BoxColor = Color.White;
            Message.BoxtextColor = Color.Black;
            Message.CreateBox("  P A S S W O R D  ", 3, 30, "____");
            //syn.Speak("Enter your password");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 3, Console.CursorTop - 1);
            password = Console.ReadLine();



            

            if (db.isRegistered(username, password))
            {
                new Thread(() => Console.Beep(320, 250)).Start();
                Console.BackgroundColor = Color.SteelBlue;
                Console.Clear();
                USERNAME = username;
                //syn.Speak("Success, Please wait");
             
                    SystemMenu();
              
            }
            else
            {
                //syn.Speak("Error, Invalid username or password");
                counter++;
                if(counter < 3)
                {
                    Console.CursorTop = 7;
                    Message.TitleBox("I N V A L I D  U S E R  O R  P A S S  T R Y  A G A I N ", 5, 60, ConsoleColor.Red, ConsoleColor.White);
                   
                    Thread.Sleep(1000);
                    
                    LoginScreen();
                }
                else
                {
                    
                    for (int i = 3; i >= 0; i--)
                    {
                        Console.BackgroundColor = Color.Red;
                        Console.Clear();
                        Console.CursorTop = 7;
                        Message.TitleBox("S Y S T E M    B L O C K E D ", 6, 60, ConsoleColor.Red, ConsoleColor.White);
                        Console.CursorTop = 11;
                        Console.CursorLeft = (Console.WindowWidth / 2)-10;
                        Console.WriteLine("E X I T T I N G  I N  {0}", i);
                        Thread.Sleep(1000);
                        
                    }
                    System.Environment.Exit(0);

                }
            }

        }


        public void SystemMenu()
        {
            Console.Title = "(Z.E.T.A.) Zero sa Exam Terminal Application";
            Console.BackgroundColor = Color.SeaGreen;
            Console.Clear();
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            ConsoleKey select, ok;
            Console.CursorTop = 4;
            Message.BoxColor = Color.Maroon;
            Message.CreateBox("", 30, 34, "");
            Message.BoxColor = Color.White;
            Console.CursorTop = 2;
            Console.WriteLine();
            Message.menuBox(3, 30, " M E N U ", ConsoleColor.Red, ConsoleColor.White, 1);
            Message.menuBox(3, 30, " A. U S E R  A C C O U N T ", ConsoleColor.Blue, ConsoleColor.White, 1, -10);
            Thread.Sleep(250);
            Message.menuBox(3, 30, " B. B A S I C ", ConsoleColor.White, ConsoleColor.Blue, 1, 10);
            Thread.Sleep(250);
            Message.menuBox(3, 30, " C. I N T E R M E D I A T E ", ConsoleColor.Blue, ConsoleColor.White, 1, -10);
            Thread.Sleep(250);
            Message.menuBox(3, 30, " D. E N T E R T A I N M E N T ", ConsoleColor.White, ConsoleColor.Blue, 1, 10);
            Thread.Sleep(250);
            Message.menuBox(3, 30, " E. C R E D I T S ", ConsoleColor.Blue, ConsoleColor.White, 1, -10);
            Thread.Sleep(250);
            Message.menuBox(3, 30, " F. E X I T ", ConsoleColor.White, ConsoleColor.Blue, 1, 10);
            Message.menuBox(1, 10, " E N T E R  K E Y  O F  Y O U R  C H O I C E ", ConsoleColor.Blue, ConsoleColor.White);
            Console.CursorLeft = (Console.WindowWidth / 2);

            select = Console.ReadKey().Key;
            
            if (select.Equals(ConsoleKey.A)) {
                new Thread(() => Console.Beep(320, 250)).Start();
                userAccount();  }
            else if (select.Equals(ConsoleKey.B)) {
                new Thread(() => Console.Beep(320, 250)).Start();
                Basic(); }
            else if (select.Equals(ConsoleKey.C)) {
                new Thread(() => Console.Beep(320, 250)).Start();
                Intermidiate(); }
            else if (select.Equals(ConsoleKey.D)) {
                new Thread(() => Console.Beep(320, 250)).Start();
                Entertainement(); }
            else if (select.Equals(ConsoleKey.E)) {
                new Thread(() => Console.Beep(320, 250)).Start();
                Credits(); }
            else if (select.Equals(ConsoleKey.F)) {
                new Thread(() => Console.Beep(320, 250)).Start();
                exit();  }

            else
            {
          
                Message.Show("Invalid Selection", "[O]K");
                ok = Console.ReadKey().Key;
                SystemMenu();

            }

            Message.Show("Do you want to exit or go to Menu ?", "[E]xit : [Any key] Menu");

            select = Console.ReadKey().Key;

            if (select.Equals(ConsoleKey.E))
            {
                System.Environment.Exit(0);
            }
            else
            {
                SystemMenu();
            }


        }




        public void userAccount()
        {
            Console.BackgroundColor = Color.Blue;
            Console.Clear();


            Message.TitleBox(" C R E A T E  U S E R  A C C O U N T", 3, 50, ConsoleColor.Red, ConsoleColor.White);

            Message.BoxColor = Color.White;
            Message.CreateBox("", 15, 50, "[S]ave [C]ancel");

            string fn, mn, ln, user, pass, userType, lbl;


            lbl = "First Name  : ";
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2)-10, Console.CursorTop-12);
            Console.WriteLine(lbl, Color.Black);

            lbl = "Middle Name : ";
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) - 10, Console.CursorTop);
            Console.WriteLine(lbl, Color.Black);

            lbl = "Last Name   : ";
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) - 10, Console.CursorTop);
            Console.WriteLine(lbl, Color.Black);

            lbl = "Username    : ";
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) - 10, Console.CursorTop);
            Console.WriteLine(lbl, Color.Black);

            lbl = "Password    : ";
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) - 10, Console.CursorTop);
            Console.WriteLine(lbl, Color.Black);

            lbl = "UserType    : ";
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) - 10, Console.CursorTop);
            Console.WriteLine(lbl, Color.Black);

            
            //Console.SetCursorPosition((Console.WindowWidth - button.Length) / 2, Console.CursorTop + 1);
            //Console.WriteLine(button, Color.Black);
            //Console.BackgroundColor = Color.Black;

            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) + 4, Console.CursorTop - 6);
            fn = Console.ReadLine();
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) + 4, Console.CursorTop);
            mn = Console.ReadLine();
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) + 4, Console.CursorTop);
            ln = Console.ReadLine();
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) + 4, Console.CursorTop);
            user = Console.ReadLine();
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) + 4, Console.CursorTop);
            pass = Console.ReadLine();
            Console.SetCursorPosition(((Console.WindowWidth - lbl.Length) / 2) + 4, Console.CursorTop);
            userType = Console.ReadLine();
           

            select = Console.ReadKey().Key;

            

            if (select.Equals(ConsoleKey.S))
            {
                if (!db.checkUsername(user))
                {
                    if (db.Insert(fn, mn, ln, user, pass, userType) > 0)
                    {
                        Message.Show("Successfully Registered", "Press any key to continue....");
                    }
                }
                else
                {
                    Message.TitleBox("Username Already Exists! Press any key to continue..", 5, 70, ConsoleColor.Red, ConsoleColor.White);
                    Console.ReadKey();
                    userAccount();

                }
            }

            Console.ReadKey();
            Console.Clear();

        }
    



        Controller act = new Controller();

        public void Basic()
        {


            Console.Clear();
            Console.BackgroundColor = Color.SteelBlue;
            Console.ForegroundColor = Color.White;
            Console.Clear();

            Message.TitleBox(" B A S I C ", 3, 20, ConsoleColor.Red, ConsoleColor.White);
            Message.CreateBox("", 20, 30, "");

            Console.CursorTop = 7;
            Message.menuBox(3, 32, " [A]. S W A P ", ConsoleColor.Blue,ConsoleColor.White,1);
            Message.menuBox(3, 32, " [B]. M D A S ", ConsoleColor.Blue, ConsoleColor.White,1);
            Message.menuBox(3, 32, " [C]. HIGHEST NUMBER ", ConsoleColor.Blue, ConsoleColor.White,1);

            Console.WriteLine();
            Console.WriteLine();
            Message.menuBox(1, 32, " E N T E R  L E T T E R ", ConsoleColor.Red, ConsoleColor.White);
            Message.menuBox(1, 32, " O F  Y O U R  C H O I C E ", ConsoleColor.Red, ConsoleColor.White);
            Message.menuBox(1, 32, " [BACK SPACE] M E N U ", ConsoleColor.Red, ConsoleColor.White);
            select = Console.ReadKey().Key;

            Console.BackgroundColor = Color.Blue;
   
            

            if (select.Equals(ConsoleKey.A))
            {
                Console.Clear();
                double num1, num2;
                string lblnum1, lblnum2;


                Message.TitleBox(" S W A P P I N G ", 3, 25, ConsoleColor.Red, ConsoleColor.White);

                Message.CreateBox("", 14, 70, ". . . .");



                lblnum1 = "Enter first number  : ";
                TextCenter(lblnum1, -5,-11);
                Console.Write(lblnum1, Color.DarkRed);
                num1 = double.Parse(Console.ReadLine());


                lblnum2 = "Enter second number : ";
                TextCenter(lblnum2, -5);
                Console.Write(lblnum2, Color.DarkRed);
                num2 = double.Parse(Console.ReadLine());


                Divider();

                act.swap(num1, num2);
                Console.WriteLine();
                TextCenter("SWAPPED VALUES");
                Console.WriteLine("SWAPPED VALUES" , Color.Blue);

                Console.WriteLine();
                TextCenter(lblnum1, -5);
                Console.WriteLine("First number  : {0}", act.num1, Color.Blue);


                TextCenter(lblnum2, -5);
                Console.WriteLine("Second number : {0}", act.num2, Color.Blue);

                pressAnyKey();



            }
            else if (select.Equals(ConsoleKey.B))
            {
                Console.Clear();

                double num1, num2;

                string Op, lblnum1, lblnum2, lblOp;

                Message.TitleBox(" M D A S ", 3, 25, ConsoleColor.Red, ConsoleColor.White);

                Message.CreateBox("", 14, 70, ". . . .");


                lblnum1 = "Enter first number   : ";
                TextCenter(lblnum1, -5, -11);
                Console.Write(lblnum1, Color.DarkRed);
                num1 = double.Parse(Console.ReadLine());

                lblOp = "Enter Operator       : ";
                TextCenter(lblOp, -5);
                Console.Write(lblOp, Color.DarkRed);
                Op = Console.ReadLine();


                lblnum2 = "Enter second number  : ";
                TextCenter(lblnum2, -5);
                Console.Write(lblnum2, Color.DarkRed);
                num2 = double.Parse(Console.ReadLine());


                string result = 
                (Op == "+" || Op == "-" || Op == "/" || Op == "*" || Op == "%") ? $"RESULT {num1} {Op} {num2} = {act.MDAS(num1, Op, num2)}" : "INVALID OVERATOR";
                TextCenter(result,0,2);
                Console.WriteLine(result);

                pressAnyKey();


            }
            else if (select.Equals(ConsoleKey.C))
            {
                Console.Clear();
                double[] num = new double[3];

                Message.TitleBox(" HIGHEST NUMBER ", 3, 25, ConsoleColor.Red, ConsoleColor.White);

                Message.CreateBox("", 14, 70, ". . . .");
                for (int i = 0; i < num.Length; i++)
                {
                    if (i == 0) TextCenter("", -10, -11);
                    else TextCenter("", -10);
                    Console.Write($"Enter number {i + 1} : ");
                    num[i] = double.Parse(Console.ReadLine());
                }

                string res = $"The Highest number in {num[0]}, {num[1]} and {num[2]} is {num.Max()}";

                TextCenter(res, 0, +2);
                
                Console.WriteLine(res);

                pressAnyKey();

            }
            else if (select.Equals(ConsoleKey.Backspace))
            {
                SystemMenu();
            }
            else
            {
                Message.TitleBox("Invalid Choice Try Again", 5, 40, ConsoleColor.Red, ConsoleColor.White);
                Console.ReadKey();
                Basic();
            }

            Console.ReadKey();

        }


        public void Intermidiate()
        {


      


            Console.Clear();
            Console.BackgroundColor = Color.SteelBlue;
            Console.Clear();

            Message.TitleBox(" I N T E R M E D I A T E ", 3, 40, ConsoleColor.Red, ConsoleColor.White);
            Message.CreateBox("", 20, 36, "");

            Console.CursorTop = 7;
            Message.menuBox(3, 38, " [A]. STRING MANIPULATION ", ConsoleColor.Blue, ConsoleColor.White, 1);
            Message.menuBox(3, 38, " [B]. GRADE COMPUTATION ", ConsoleColor.Blue, ConsoleColor.White, 1);
            Message.menuBox(3, 38, " [C]. SALES TRANSACTION ", ConsoleColor.Blue, ConsoleColor.White, 1);


            Console.WriteLine();
            Console.WriteLine();

            Message.menuBox(1, 38, " E N T E R  L E T T E R " , ConsoleColor.Red, ConsoleColor.White);
            Message.menuBox(1, 38, " O F  Y O U R  C H O I C E ", ConsoleColor.Red, ConsoleColor.White);
            Message.menuBox(1, 38, " [BACK SPACE] M E N U ", ConsoleColor.Red, ConsoleColor.White);

            select = Console.ReadKey().Key;


     
            Console.WriteLine();


            if (select.Equals(ConsoleKey.A))
            {
                Console.BackgroundColor = Color.Blue;
                Console.Clear();

                string fname, mname, lname, lblf, lblm, lbll, result;


                Message.TitleBox(" STRING MANIPULATION ", 3, 25, ConsoleColor.Red, ConsoleColor.White);
                Message.CreateBox("", 10, 70, ". . . .");
                
             


                lblf = "Enter Firstname : ";
                TextCenter("", -15,-7);
                Console.Write(lblf, Color.Black);
                fname = Console.ReadLine();


                lblm = "Enter Middlename : ";
                TextCenter("", -15);
                Console.Write(lblm, Color.Black);
                mname = Console.ReadLine();

                lbll = "Enter Lastname : ";
                TextCenter("", -15);
                Console.Write(lbll, Color.Black);
                lname = Console.ReadLine();



                result = "Hi ! " + act.strManipulation(fname, mname, lname);



                Message.Show(result, "Press any key to continue....");


            }
            else if (select.Equals(ConsoleKey.B))
            {
                Console.BackgroundColor = Color.SteelBlue;
                Console.Clear();
                Message.TitleBox(" GRADE COMPUTATION", 3, 20, ConsoleColor.Red, ConsoleColor.White);
                Message.CreateBox("", 16, 30, "");
                Console.CursorTop = 7;
                Message.menuBox(3, 32, " [A]. INSERT STUDENT GRADE ", ConsoleColor.Blue, ConsoleColor.White, 1);
                Message.menuBox(3, 32, " [B]. DELETE STUDENT GRADE ", ConsoleColor.Blue, ConsoleColor.White, 1);

                Console.WriteLine();
                Console.WriteLine();
                Message.menuBox(1, 32, " E N T E R  L E T T E R ", ConsoleColor.Red, ConsoleColor.White);
                Message.menuBox(1, 32, " O F  Y O U R  C H O I C E ", ConsoleColor.Red, ConsoleColor.White);
                Message.menuBox(1, 32, " [BACK SPACE] M E N U ", ConsoleColor.Red, ConsoleColor.White);
             
                ConsoleKey sel = Console.ReadKey().Key;

                if (sel.Equals(ConsoleKey.A))
                {
                    Console.Clear();
                    insertStudent();
                }
                else if (sel.Equals(ConsoleKey.B))
                {
                    Console.Clear();
                    deleteStudentGrade();
                }
                else if (sel.Equals(ConsoleKey.Backspace))
                {
                    SystemMenu();
                }
               



            }
            else if (select.Equals(ConsoleKey.C))
            {
                Console.BackgroundColor = Color.SteelBlue;
                Console.Clear();

    
                Message.TitleBox(" SALES TRANSACTION ", 3, 23, ConsoleColor.Red, ConsoleColor.White);
                Message.CreateBox("", 16, 30, "");
                Console.CursorTop = 7;
                Message.menuBox(3, 32, " [A]. INSERT CUSTOMER ", ConsoleColor.Blue, ConsoleColor.White, 1);
                Message.menuBox(3, 32, " [B]. DELETE CUSTOMER ", ConsoleColor.Blue, ConsoleColor.White, 1);


                Console.WriteLine();
                Console.WriteLine();
                Message.menuBox(1, 32, " E N T E R  L E T T E R ", ConsoleColor.Red, ConsoleColor.White);
                Message.menuBox(1, 32, " O F  Y O U R  C H O I C E ", ConsoleColor.Red, ConsoleColor.White);
                Message.menuBox(1, 32, " [BACK SPACE] M E N U ", ConsoleColor.Red, ConsoleColor.White);
            


                ConsoleKey sel = Console.ReadKey().Key;

                if (sel.Equals(ConsoleKey.A))
                {
                    Console.Clear();
                    insertCustomer();
                }
                else if (sel.Equals(ConsoleKey.B))
                {
                    Console.Clear();
                    deleteCustomer();
                  
                }
                else if (sel.Equals(ConsoleKey.Backspace))
                {
                    SystemMenu();
                }

                


            }
            else if (select.Equals(ConsoleKey.Backspace))
            {
                SystemMenu();
            }
            else
            {
                Message.TitleBox("Invalid Choice Try Again", 5, 40, ConsoleColor.Red, ConsoleColor.White);
                Console.ReadKey();
                Intermidiate();
            }

            Console.ReadKey();
        }
        

        public void Entertainement()
        {
            Console.Clear();
            Console.BackgroundColor = Color.SteelBlue;
            Console.Clear();

            Message.TitleBox(" E N T E R T A I N M E N T ", 3, 40, ConsoleColor.Red, ConsoleColor.White);
            Message.BoxColor = Color.White;

            Message.CreateBox("", 16, 30, "");



            Console.CursorTop = 7;
            Message.menuBox(3, 32, " [A]. S N A K E ", ConsoleColor.Blue, ConsoleColor.White, 1);
            Message.menuBox(3, 32, " [B]. C O L O R  G A M E ", ConsoleColor.Blue, ConsoleColor.White, 1);

            Console.WriteLine();
            Console.WriteLine();
            Message.menuBox(1, 32, " E N T E R  L E T T E R ", ConsoleColor.Red, ConsoleColor.White);
            Message.menuBox(1, 32, " O F  Y O U R  C H O I C E ", ConsoleColor.Red, ConsoleColor.White);
            Message.menuBox(1, 32, " [BACK SPACE] M E N U ", ConsoleColor.Red, ConsoleColor.White);
            select = Console.ReadKey().Key;
            if (select.Equals(ConsoleKey.A))
            {
                
                Snake snake = new Snake(USERNAME);
                snake.Initialize();
            }
            else if (select.Equals(ConsoleKey.B))
            {
                Console.BackgroundColor = Color.Black;
                Console.Clear();
                ColorGame cg = new ColorGame();
                cg.gameStart();
            }
            else if (select.Equals(ConsoleKey.Backspace))
            {
                SystemMenu();
            }
            else
            {
                Message.TitleBox("Invalid Choice Try Again", 5, 40, ConsoleColor.Red, ConsoleColor.White);
                Console.ReadKey();
                Entertainement();
            }

            Console.ReadKey(true);

        }


        public void Credits()
        {
            Console.BackgroundColor = Color.Blue;
            Console.Clear();

            Message.TitleBox(" C R E D I T S ", 3, 20, ConsoleColor.Red, ConsoleColor.White);

            Message.BoxColor = Color.White;

            Message.CreateBox("", 15, 50, "");

            string text, name, section,prof, lblProf, library, libname1, libname2;

            text = "Developed and Designed by";
            name = "John Nehry C. Dedoro";
            section = "BSIT 1 - 1A";
            prof = "M R.  A L K I N G  S U N G A";
            lblProf = " P R O F F E S O R ";
            library = "C# Custom Library Used :";
            libname1 = "Colorful.Console by Tomakitaa";
            libname2 = "ConsoleTables by Khalidabuhakmeh";


            Console.SetCursorPosition(((Console.WindowWidth - text.Length) / 2), Console.CursorTop - 13);
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i], Color.Black);
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(((Console.WindowWidth - name.Length) / 2), Console.CursorTop+1);
            for (int i = 0; i < name.Length; i++)
            {
                Console.Write(name[i], Color.Black);
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(((Console.WindowWidth - section.Length) / 2), Console.CursorTop + 1);
            for (int i = 0; i < section.Length; i++)
            {
                Console.Write(section[i], Color.Black);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            Console.SetCursorPosition(((Console.WindowWidth - prof.Length) / 2), Console.CursorTop + 1);
            for (int i = 0; i < prof.Length; i++)
            {
                Console.Write(prof[i], Color.Black);
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(((Console.WindowWidth - lblProf.Length) / 2), Console.CursorTop + 1);
            for (int i = 0; i < lblProf.Length; i++)
            {
                Console.Write(lblProf[i], Color.Black);
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(((Console.WindowWidth - library.Length) / 2), Console.CursorTop + 1);
            for (int i = 0; i < library.Length; i++)
            {
                Console.Write(library[i], Color.Black);
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(((Console.WindowWidth - libname1.Length) / 2), Console.CursorTop + 1);
            for (int i = 0; i < libname1.Length; i++)
            {
                Console.Write(libname1[i], Color.Black);
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(((Console.WindowWidth - libname2.Length) / 2), Console.CursorTop + 1);
            for (int i = 0; i < libname2.Length; i++)
            {
                Console.Write(libname2[i], Color.Black);
                Thread.Sleep(50);
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
            
            Message.menuBox(1, 20, " T H A N K  Y O U ", ConsoleColor.Blue, ConsoleColor.White);

        
            pressAnyKey();
            Console.ReadKey();

        }



        public void insertStudent()
        {
            Console.BackgroundColor = Color.Blue;
            Console.Clear();


            string sname, lblnosubj, lblsname, lblsubj, lblp, lblm, lblf, count;
            int subjNO;


            Message.TitleBox(" GRADE COMPUTATION ", 3, 22, ConsoleColor.Red, ConsoleColor.White);
            Message.CreateBox("", 12, 70, ". . . .");



            lblnosubj = "Enter Number of Subject: ";
            TextCenter(lblnosubj, 0, -9);
            Console.Write(lblnosubj, Color.Black);
            subjNO = int.Parse(Console.ReadLine());

            lblsname = "Enter Student name: ";
            TextCenter(lblsname, -5);
            Console.Write(lblsname, Color.Black);
            sname = Console.ReadLine();

            Console.Clear();

            double[] pre = new double[subjNO];
            double[] mid = new double[subjNO];
            double[] fin = new double[subjNO];
            double[] ave = new double[subjNO];
            string[] subjName = new string[subjNO];
            string[] remarks = new string[subjNO];
            var stgrList = new List<StudentGradeModel>();

            if (subjNO > 0)
            {

                for (int i = 0; i < subjNO; i++)
                {
                    Console.BackgroundColor = Color.Blue;
                    Console.Clear();

                    Message.CreateBox(" INPUTING OF GRADES ", 12, 70, ". . . .");

                    count = $"Subject No. {i + 1}";
                    TextCenter(count, 0, -10);
                    Console.Write(count, Color.White);
                    Console.WriteLine();

                    lblsubj = "Enter Subj Name    : ";
                    TextCenter("", -15);
                    Console.Write(lblsubj, Color.Black);
                    subjName[i] = Console.ReadLine();

                    lblp = "Enter Prelim Grade : ";
                    TextCenter("", -15);
                    Console.Write(lblp, Color.Black);
                    pre[i] = double.Parse(Console.ReadLine());

                    lblm = "Enter Midterm Grade: ";
                    TextCenter("", -15);
                    Console.Write(lblm, Color.Black);
                    mid[i] = double.Parse(Console.ReadLine());

                    lblf = "Enter Midterm Grade: ";
                    TextCenter("", -15);
                    Console.Write(lblf, Color.Black);
                    fin[i] = double.Parse(Console.ReadLine());

                    ave[i] = Math.Round(((pre[i] + mid[i] + fin[i]) / 3), 2);

                    remarks[i] = (ave[i] <= 3.0) ? "PASSED" : "FAILED";

                    stgrList.Add(new StudentGradeModel
                    {
                        sname = sname,
                        subj = subjName[i],
                        prelim = pre[i],
                        midterm = mid[i],
                        finals = fin[i],
                        ave = ave[i],
                        remarks = remarks[i]

                    });

                }

                db.insertStudentGrade(stgrList);
                Console.BackgroundColor = Color.Black;
                Console.ForegroundColor = Color.White;
                Console.Clear();
                var table = new ConsoleTable("S T U D E N T  N A M E", "S U B J E C T", "P R E L I M", "M I D T E R M ", "F I N A L S", " A V E R A G E", "R E M A R K S");
                Console.WriteLine();
                Console.WriteLine(" STUDENT GRADE TABLE", Color.White);
                foreach (var stgrades in db.getStudentGradeList())
                {
                    table.AddRow(stgrades.sname, stgrades.subj, stgrades.prelim, stgrades.midterm, stgrades.finals, stgrades.ave, stgrades.remarks);
                }

                table.Write();
                Console.WriteLine();

            }
        }

        public void deleteStudentGrade()
        {

            System.Console.WriteLine();
            Console.Write(" ENTER THE ID TO DELETE : ");

            System.Console.WriteLine();
            System.Console.WriteLine();
            var table = new ConsoleTable("ID","S T U D E N T  N A M E", "S U B J E C T", "P R E L I M", "M I D T E R M ", "F I N A L S", " A V E R A G E", "R E M A R K S");

            foreach (var stgrades in db.getStudentGradeList())
            {
                table.AddRow(stgrades.id, stgrades.sname, stgrades.subj, stgrades.prelim, stgrades.midterm, stgrades.finals, stgrades.ave, stgrades.remarks);
            }


            table.Write();
            Console.CursorTop = 1;
            Console.CursorLeft = 30;
            int id = int.Parse(Console.ReadLine());


            Message.TitleBox(" Are you sure you want to delete [Y]es/[N]o ",5,50,ConsoleColor.Red,ConsoleColor.White);

            ConsoleKey sel = Console.ReadKey().Key;
            if (sel.Equals(ConsoleKey.Y))
            {
                db.deleteStudent(id);
                Message.TitleBox(" Do you want to delete another ? [Y]es/[N]o ", 5, 50, ConsoleColor.White, ConsoleColor.Black);
                ConsoleKey key = Console.ReadKey().Key;

                if (key.Equals(ConsoleKey.Y))
                {
                    Console.Clear();
                    deleteStudentGrade();
                }
                else
                {

                }
            }
            else
            {
                Intermidiate();
            }
            

        


        }

        public void insertCustomer()
        {
            string lblCustNo, lblcname, lbltp, lblpay, count;
            int noCust;

            Console.BackgroundColor = Color.Blue;
            Console.Clear();

            Message.TitleBox(" INPUTING OF CUSTOMER ", 3, 24, ConsoleColor.Red, ConsoleColor.White);

            Message.CreateBox("", 7, 70, ". . . .");


            lblCustNo = "Enter Customer Number : ";
            TextCenter(lblCustNo, 0, -4);
            Console.Write(lblCustNo, Color.Black);
            noCust = int.Parse(Console.ReadLine());



            Console.Clear();

            double[] totalPurch = new double[noCust];
            double[] disc = new double[noCust];
            double[] totalDue = new double[noCust];
            double[] change = new double[noCust];
            double[] cpay = new double[noCust];
            string[] custName = new string[noCust];

            var custList = new List<CustomerModel>();

            if (noCust > 0)
            {

                for (int i = 0; i < noCust; i++)
                {

                    Console.BackgroundColor = Color.Black;
                    Console.Clear();
                    Message.CreateBox(" INPUTING OF CUSTOMERS ", 12, 70, ". . . .");

                    count = $"Customer No. {i + 1}";
                    TextCenter(count);
                    Console.Write(count, Color.White);
                    Console.WriteLine();

                    lblcname = "Enter Customer name : ";
                    TextCenter("", -15, -10);
                    Console.Write(lblcname, Color.Black);
                    custName[i] = Console.ReadLine();

                    lbltp = "Enter Total Purchase: ";
                    TextCenter("", -15);
                    Console.Write(lbltp, Color.Black);
                    totalPurch[i] = double.Parse(Console.ReadLine());

                    disc[i] = (totalPurch[i] > 1000) ? totalPurch[i] * 0.05 : totalPurch[i] * 0.01;

                    totalDue[i] = totalPurch[i] - disc[i];


                    lblpay = "Enter Cash payment  : ";
                    TextCenter("", -15);
                    Console.Write(lblpay, Color.Black);
                    cpay[i] = double.Parse(Console.ReadLine());


                    change[i] = cpay[i] - totalDue[i];


                    custList.Add(new CustomerModel
                    {
                        CustName = (string)custName[i],
                        totalPurch = (double)totalPurch[i],
                        disc = (double)disc[i],
                        totalDue = (double)totalDue[i],
                        cpay = (double)cpay[i],
                        change = (double)change[i]
                    }
                    );

                }

                db.insertCustomer(custList);


                Console.BackgroundColor = Color.Black;
                Console.ForegroundColor = Color.White;
                Console.Clear();

                Console.WriteLine();


                Console.WriteLine(" SALES TRANSACTION TABLE", Color.White);

                Console.WriteLine();

                var table = new ConsoleTable(" C U S T O M E R  N A M E ", " T O T A L  P U R C H A S E ", " D I S C O U N T ", " T O T A L  D U E ", " C A S H  P A Y M E N T ", " C H A N G E ");



                foreach (var cust in db.getCUstomerList())
                {
                    table.AddRow(cust.CustName, cust.totalPurch, cust.disc, cust.totalDue, cust.cpay, cust.change);
                }

                table.Write();
                Console.WriteLine();


            }

        }

        public void deleteCustomer()
        {

            System.Console.WriteLine();
            Console.Write(" ENTER THE ID TO DELETE : ");

            System.Console.WriteLine();
            System.Console.WriteLine();

            var table = new ConsoleTable(" ID "," C U S T O M E R  N A M E ", " T O T A L  P U R C H A S E ", " D I S C O U N T ", " T O T A L  D U E ", " C A S H  P A Y M E N T ", " C H A N G E ");



            foreach (var cust in db.getCUstomerList())
            {
                table.AddRow(cust.ID, cust.CustName, cust.totalPurch, cust.disc, cust.totalDue, cust.cpay, cust.change);
            }

            table.Write();
            Console.WriteLine();

            Console.CursorTop = 1;
            Console.CursorLeft = 30;
            int id = int.Parse(Console.ReadLine());


            Message.TitleBox(" Are you sure you want to delete [Y]es/[N]o ", 5, 50, ConsoleColor.Red, ConsoleColor.White);

            ConsoleKey sel = Console.ReadKey().Key;
            if (sel.Equals(ConsoleKey.Y))
            {
                db.deleteCustomer(id);
                Message.TitleBox(" Do you want to delete another ? [Y]es/[N]o ", 5, 50, ConsoleColor.White, ConsoleColor.Black);
                ConsoleKey key = Console.ReadKey().Key;

                if (key.Equals(ConsoleKey.Y))
                {
                    Console.Clear();
                    deleteCustomer();
                }
                else
                {

                }
            }
            else
            {
                Intermidiate();
            }





        }

        public void exit()
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.BackgroundColor = Color.Red;
                Console.Clear();
                Console.CursorTop = 7;
                Message.TitleBox(" S Y S T E M    E X I T ", 6, 60, ConsoleColor.Red, ConsoleColor.White);
                Console.CursorTop = 11;
                Console.CursorLeft = (Console.WindowWidth / 2) - 8;
                Console.WriteLine("E X I T T I N G  I N  {0}", i);
                Thread.Sleep(1000);

            }
            System.Environment.Exit(0);
        }
        // POSITIONING OF THE CURSOR

        public void pressAnyKey()
        {
            Console.WriteLine();
            string lblkey = "PRESS ANY KEY TO CONTINUE";
            TextCenter(lblkey);
            Console.WriteLine(lblkey);
        }
        public void cursorPosLeft(string text)
        {
            Console.CursorLeft = ((Console.WindowWidth - 30) / 2) + text.Length;
        }
        public void TextCenter(string text, int addLeft = 0,int addTop = 0)
        {
            Console.SetCursorPosition(((Console.WindowWidth - text.Length) / 2) + addLeft, Console.CursorTop+addTop);
            
        }
        public void Divider()
        {
            string divider = "_____________________________________________________";

            TextCenter(divider);
 
            Console.WriteLine(divider);

        }
    }
}
