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

        Message msg = new Message();
        private ConsoleKey select;
        private string lblSelect, lblBack;
        SpeechSynthesizer syn = new SpeechSynthesizer();

        public string USERNAME;
        

        public void Initialize()
        {
           
            LoginScreen();
        }


        Database db = new Database();
        int counter = 0;

        public void LoginScreen()
        {
            Console.BackgroundColor = Color.Black;
            Console.Clear();
            Console.Title = "(Z.E.T.A.) Zero sa Exam Terminal Application";
            string username, password, lblUsername, lblPassword, divider;

            string[] login =
            {
               " ██       ██████  ██████   ██ ███    ██ ",
               " ██      ██    ██ ██       ██ ████   ██ ",
               " ██      ██    ██ ██   ███ ██ ██ ██  ██ ",
               " ██      ██    ██ ██    ██ ██ ██  ██ ██ ",
               " ███████  ██████   ██████  ██ ██   ████ "

            };
            int DA = 244;
            int V = 212;
            int ID = 255;
            System.Console.WriteLine();
            for (int i = 0; i < login.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - login[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(login[i], Color.FromArgb(DA, V, ID));

                DA -= 18;
                V -= 36;
                Thread.Sleep(30);
            }


            divider = "_____________________________________________________";

            TextCenter(divider);
            Console.WriteLine(divider);
            divider = "__________________________________________________";
            TextCenter(divider);
            Console.WriteLine(divider);


            Console.WriteLine("\n");
            
            
            lblUsername = "Username : ";
            TextCenter(lblUsername, -5);
            Console.Write(lblUsername, Color.Aquamarine);

            syn.SetOutputToDefaultAudioDevice();
            //syn.Speak("Enter your username");
            username = Console.ReadLine();


            lblPassword = "Password : ";
            TextCenter(lblPassword, -5);
            Console.Write(lblPassword, Color.Aquamarine);
            //syn.Speak("Enter your password");
            password = Console.ReadLine();



            if (db.isRegistered(username, password))
            {

                USERNAME = username;

                Console.Clear();
                //syn.Speak("Success, Please wait");
                SystemMenu();

            }
            else
            {
                //syn.Speak("Error, Invalid username or password");
                counter++;
                if(counter < 3)
                {
                    Console.Clear();
                    LoginScreen();
                }
                else
                {
                    
                }
            }

        }


        public void SystemMenu()
        {
            Console.Title = "(Z.E.T.A.) Zero sa Exam Terminal Application";
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;
            string lblSelect;
            ConsoleKey select, ok;

            Console.BackgroundColor = Color.DarkRed;
            Console.ForegroundColor = Color.Black;
            Console.Clear();

            string[] menu =
            {
              " ███╗   ███╗███████╗███╗   ██╗██╗   ██╗ ",
              " ████╗ ████║██╔════╝████╗  ██║██║   ██║ ",
              " ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║ ",
              " ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║ ",
              " ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝ ",
              " ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝  "

            };
            
            System.Console.WriteLine();
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - menu[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(menu[i], Color.White);

             
            }
            

            Formatter[] menus = new Formatter[]
            {
                new Formatter("USER ACCOUNT", Color.LightGoldenrodYellow),
                new Formatter("BASIC", Color.Pink),
                new Formatter("INTERMEDIATE", Color.PeachPuff),
                new Formatter("ENTERTAINMENT", Color.Yellow),
                new Formatter("CREDITS", Color.White),

            };

            System.Console.WriteLine();
            
            int x = -10;
            TextCenter("", x);

            TextCenter("", x);
            Console.WriteLineFormatted("[A]. {0}", Color.Blue, menus);
            TextCenter("", x);
            Console.WriteLineFormatted("[B]. {1}", Color.Blue, menus);
            TextCenter("", x);
            Console.WriteLineFormatted("[C]. {2}", Color.Blue, menus);
            TextCenter("", x);
            Console.WriteLineFormatted("[D]. {3}", Color.Blue, menus);
            TextCenter("", x);
            Console.WriteLineFormatted("[E]. {4}", Color.Blue, menus);

            lblSelect = "SELECT THE LETTER OF YOUR CHOICE";
            TextCenter(lblSelect);
            Console.WriteLine(lblSelect, Color.White);

            select = Console.ReadKey().Key;

            if (select.Equals(ConsoleKey.A)) { userAccount();  }
            else if (select.Equals(ConsoleKey.B)) { Basic(); }
            else if (select.Equals(ConsoleKey.C)) { Intermidiate(); }
            else if (select.Equals(ConsoleKey.D)) { Entertainement(); }
            else if (select.Equals(ConsoleKey.E)) { Credits(); }

            else
            {
          
                msg.Show("Invalid Selection", "[O]K");
                ok = Console.ReadKey().Key;
                SystemMenu();

            }

            msg.Show("Do you want to exit or go to Menu ?", "[E]xit : [Any key] Menu");

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


            msg.BoxColor = Color.White;
            msg.box(" CREATE NEW USER ACCOUNT ", 15, 50, "[S]ave [C]ancel");

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
                if(db.Insert(fn,mn,ln,user,pass,userType) > 0)
                {
                    msg.ShowDark("Successfully Registered", "Press any key to continue....");
                }
            }

            Console.ReadKey();
            Console.Clear();

        }
    



        Controller act = new Controller();

        public void Basic()
        {

            int x = -10;

            

            Console.Clear();
            Console.BackgroundColor = Color.Blue;
            Console.ForegroundColor = Color.White;
            Console.Clear();

            msg.box(" BASIC ", 10, 70, "PRESS THE LETTER OF YOUR CHOICE OR [BACK SPACE] TO GO BACK");

            Formatter[] subMenus = new Formatter[]
            {
                new Formatter("SWAP", Color.Black),
                new Formatter("MDAS", Color.Black),
                new Formatter("HIGHEST NUMBER", Color.Black),
            };

            TextCenter("", x, -7);
            Console.WriteLineFormatted("[A]. {0}", Color.Blue, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[B]. {1}", Color.Blue, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[C]. {2}", Color.Blue, subMenus);
            select = Console.ReadKey().Key;

            Console.BackgroundColor = Color.Blue;
   
            Console.Clear();

            if (select.Equals(ConsoleKey.A))
            {
                double num1, num2;
                string lblnum1, lblnum2;

                msg.box(" SWAPPING ", 14, 70, ". . . .");



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

                double num1, num2;

                string Op, lblnum1, lblnum2, lblOp;

                msg.box(" MDAS ", 14, 70, ". . . .");


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
                (Op == "+" || Op == "-" || Op == "/" || Op == "*" || Op == "%") ? $"RESULT : {act.MDAS(num1, Op, num2)}" : "INVALID OVERATOR";
                TextCenter(result,0,2);
                Console.WriteLine(result);

                pressAnyKey();


            }
            else if (select.Equals(ConsoleKey.C))
            {
                double[] num = new double[3];


                msg.box(" HIGHEST NUMBER ", 14, 70, ". . . .");
                for (int i = 0; i < num.Length; i++)
                {
                    if (i == 0) TextCenter("", -10, -11);
                    else TextCenter("", -10);
                    Console.Write($"Enter number {i + 1} : ");
                    num[i] = double.Parse(Console.ReadLine());
                }

                string res = $"The Highest number is {num.Max()}";

                TextCenter(res, -10, +2);
                
                Console.WriteLine(res);

                pressAnyKey();

            }
            else if (select.Equals(ConsoleKey.Backspace))
            {
                SystemMenu();
            }

            Console.ReadKey();

        }


        public void Intermidiate()
        {


            int x = -12;



            Console.Clear();
            Console.BackgroundColor = Color.Blue;
            Console.Clear();

            Console.WriteLine();

            Formatter[] subMenus = new Formatter[]
            {
                new Formatter("STRING MANIPULATION", Color.Black),
                new Formatter("GRADE COMPUTATION", Color.Black),
                new Formatter("SALES TRANSACTION", Color.Black),
            };

            msg.BoxColor = Color.White;
    

            msg.box(" INTERMIDIATE ", 10, 70, "PRESS THE LETTER OF YOUR CHOICE OR [BACK SPACE] TO GO BACK");

            TextCenter("", x,-7);
            Console.WriteLineFormatted("[A]. {0}", Color.Blue, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[B]. {1}", Color.Blue, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[C]. {2}", Color.Blue, subMenus);

            lblSelect = "SELECT THE LETTER OF YOUR CHOICE";
            TextCenter(lblSelect);
            Console.WriteLine(lblSelect, Color.White);
            lblBack = "[BACK SPACE] TO GO BACK";
            TextCenter(lblBack);
            Console.WriteLine(lblBack, Color.White);
            select = Console.ReadKey().Key;


     
            Console.WriteLine();


            if (select.Equals(ConsoleKey.A))
            {
                Console.BackgroundColor = Color.Blue;
                Console.Clear();

                string fname, mname, lname, lblf, lblm, lbll, result;


                msg.box(" HIGHEST NUMBER ", 10, 70, ". . . .");

             


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



                msg.Show(result, "Press any key to continue....");






            }
            else if (select.Equals(ConsoleKey.B))
            {
                Console.BackgroundColor = Color.Blue;
                Console.Clear();


                string sname, lblnosubj, lblsname, lblsubj, lblp, lblm, lblf, count;
                int subjNO;



                msg.box(" GRADE COMPUTATION ", 12, 70, ". . . .");

           

                lblnosubj = "Enter Number of Subject: ";
                TextCenter(lblnosubj,0,-9);
                Console.Write(lblnosubj, Color.Black);
                subjNO = int.Parse(Console.ReadLine());

                lblsname = "Enter Student name: ";
                TextCenter(lblsname,-5);
                Console.Write(lblsname, Color.Black);
                sname = Console.ReadLine();

                Console.Clear();

                double[] pre = new double[subjNO];
                double[] mid = new double[subjNO];
                double[] fin = new double[subjNO];
                double[] ave = new double[subjNO];
                string[] subjName = new string[subjNO];
                string[] remarks = new string[subjNO];

                if (subjNO > 0)
                {

                    for (int i = 0; i < subjNO; i++)
                    {
                        Console.BackgroundColor = Color.Blue;
                        Console.Clear();

                        msg.box(" INPUTING OF GRADES ", 12, 70, ". . . .");

                        count = $"Subject No. {i + 1}";
                        TextCenter(count,0, -10);
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

                        ave[i] = Math.Round(((pre[i] + mid[i] + fin[i]) / 3),2);

                        remarks[i] = (ave[i] <= 3.0) ? "PASSED" : "FAILED";

                        

                    }
                    Console.BackgroundColor = Color.Black;
                    Console.ForegroundColor = Color.White;
                    Console.Clear();
                    var table = new ConsoleTable("SUBJECT", "PRELIM", "MIDTERM", "FINALS", "AVERAGE", "REMARKS");
                    Console.WriteLine();
                    Console.WriteLine(" GRADE COMPUTATION TABLE", Color.White);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("  Hello !{0}", sname);
                    for (int i = 0; i < subjNO; i++)
                    {
                        table.AddRow(subjName[i], pre[i], mid[i], fin[i], ave[i], remarks[i]);
                    }

                    table.Write();
                    Console.WriteLine();

                }







            }
            else if (select.Equals(ConsoleKey.C))
            {
                Console.BackgroundColor = Color.Black;
                Console.Clear();

                string lblCustNo, lblcname, lbltp, lblpay, count;
                int noCust;


                msg.box(" INPUTING OF GRADES ", 7, 70, ". . . .");


                lblCustNo = "Enter Customer Number : ";
                TextCenter(lblCustNo,0,-4);
                Console.Write(lblCustNo, Color.Black);
                noCust = int.Parse(Console.ReadLine());



                Console.Clear();

                double[] totalPurch = new double[noCust];
                double[] disc = new double[noCust];
                double[] totalDue = new double[noCust];
                double[] change = new double[noCust];
                double[] cpay = new double[noCust];
                string[] custName = new string[noCust];

                if (noCust > 0)
                {

                    for (int i = 0; i < noCust; i++)
                    {

                        Console.BackgroundColor = Color.Black;
                        Console.Clear();
                        msg.box(" INPUTING OF CUSTOMERS ", 12, 70, ". . . .");

                        count = $"Customer No. {i + 1}";
                        TextCenter(count);
                        Console.Write(count, Color.White);
                        Console.WriteLine();

                        lblcname = "Enter Customer name : ";
                        TextCenter("", -15,-10);
                        Console.Write(lblcname, Color.Black);
                        custName[i] = Console.ReadLine();

                        lbltp =    "Enter Total Purchase: ";
                        TextCenter("", -15);
                        Console.Write(lbltp, Color.Black);
                        totalPurch[i] = double.Parse(Console.ReadLine());

                        disc[i] = (totalPurch[i] > 1000) ? totalPurch[i] * 0.05 : totalPurch[i] * 0.01;

                        totalDue[i] = totalPurch[i] - disc[i];


                        lblpay =   "Enter Cash payment  : ";
                        TextCenter("", -15);
                        Console.Write(lblpay, Color.Black);
                        cpay[i] = double.Parse(Console.ReadLine());


                        change[i] = cpay[i] - totalDue[i];


                 

                    }

                    Console.BackgroundColor = Color.Black;
                    Console.ForegroundColor = Color.White;
                    Console.Clear();

                    Console.WriteLine();
                    
                
                    Console.WriteLine(" SALES TRANSACTION TABLE", Color.White);

                    Console.WriteLine();

                    var table = new ConsoleTable("CUSTOMER NAME", "TOTAL PURCHASE", "DISCOUNT", "TOTAL DUE", "CASH PAYMENT", "CHANGE");


                    for (int i = 0; i < noCust; i++)
                    {
                        table.AddRow(custName[i], totalPurch[i], disc[i], totalDue[i], cpay[i], change[i]);
                    }

                    table.Write();
                    Console.WriteLine();


                }


                }
            else if (select.Equals(ConsoleKey.Backspace))
            {
                SystemMenu();
            }

            Console.ReadKey();
        }
        

        public void Entertainement()
        {
            Console.Clear();
            Console.BackgroundColor = Color.Blue;
            Console.Clear();
            msg.BoxColor = Color.White;

            msg.box(" Entertainment ", 10, 40, "SELECT THE KEY OF YOUR CHOICE");


           

            string[] text =
            {
                "[A]. Snake Game",
            };

            Console.SetCursorPosition((Console.WindowWidth - text[0].Length) / 2, Console.CursorTop - 8);
            Console.Write(text[0]);

            Console.SetCursorPosition((Console.WindowWidth - text[0].Length) / 2, Console.CursorTop+5);
            select = Console.ReadKey().Key;
            Console.Clear();
            if (select.Equals(ConsoleKey.A))
            {
                
                Snake snake = new Snake(USERNAME);
                snake.Initialize();
            }


            Console.ReadKey(true);

        }


        public void Credits()
        {
            Console.BackgroundColor = Color.Blue;
            Console.Clear();

            msg.BoxColor = Color.White;
            msg.BoxtextColor = Color.Black;
            msg.box(" CREDITS ", 15, 50, "THANK YOU");

            string text, name, section, library, libname1, libname2;

            text = "Developed and Designed by";
            name = "John Nehry C. Dedoro";
            section = "BSIT 1 - 1A";
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

            Console.ReadKey();

        }


        



        // POSITIONING OF THE CURSOR

        public void pressAnyKey()
        {
            Console.WriteLine();
            string lblkey = "PRESS ANY KEY TO CONTINUE...";
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
