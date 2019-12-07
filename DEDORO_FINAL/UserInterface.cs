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
        private string lblSelect, lblSub, lblBack;
        SpeechSynthesizer syn = new SpeechSynthesizer();
        

        public void Initialize()
        {
            LoginScreen();
        }


        Database db = new Database();
        int counter = 0;

        public void LoginScreen()
        {
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
            string lblSelect;
            ConsoleKey select, ok;

            Console.BackgroundColor = Color.DarkRed;
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
                new Formatter("CREDITS", Color.Red),

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
            else if (select.Equals(ConsoleKey.D)) { System.Console.WriteLine("OK"); }
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
            //string[] box =
            //{
            //    "╔═════════════════ CREATE NEW USER ACCOUNT  ════════════════╗",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "║                                                           ║",
            //    "╚═══════════════════════════════════════════════════════════╝",

            //};
            //Console.WriteLine();
            //Console.BackgroundColor = Color.White;
            //for (int i = 0; i < box.Length; i++)
            //{
            //    Console.SetCursorPosition((Console.WindowWidth - box[i].Length) / 2, Console.CursorTop);
            //    Console.WriteLine(box[i], Color.Black);

            //}


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

            int x = -5;

            

            Console.Clear();
            Console.BackgroundColor = Color.Black;
            Console.ForegroundColor = Color.White;
            Console.Clear();

            Console.WriteLine();

            Formatter[] subMenus = new Formatter[]
            {
                new Formatter("SWAP", Color.LightGoldenrodYellow),
                new Formatter("MDAS", Color.Pink),
                new Formatter("HIGHEST NUMBER", Color.PeachPuff),
            };

            lblSub = "B A S I C";
            TextCenter(lblSub);
            Console.WriteLine(lblSub);
            TextCenter("", x);
            Console.WriteLineFormatted("[A]. {0}", Color.Yellow, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[B]. {1}", Color.Yellow, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[C]. {2}", Color.Yellow, subMenus);

            lblSelect = "SELECT THE LETTER OF YOUR CHOICE";
            TextCenter(lblSelect);
            Console.WriteLine(lblSelect, Color.White);
            lblBack = "[BACK SPACE] TO GO BACK";
            TextCenter(lblBack);
            Console.WriteLine(lblBack, Color.White);
            select = Console.ReadKey().Key;


            string lblSubMenus = "";
            Console.WriteLine();


            if (select.Equals(ConsoleKey.A))
            {
                double num1, num2;
                string lblnum1, lblnum2;

                lblSubMenus = "S W A P P I N N G";
                TextCenter(lblSubMenus);
                Console.WriteLine(lblSubMenus, Color.White);

                Divider();


                lblnum1 = "Enter first number : ";
                TextCenter(lblnum1, -5);
                Console.Write(lblnum1, Color.Aquamarine);
                num1 = double.Parse(Console.ReadLine());


                lblnum2 = "Enter second number : ";
                TextCenter(lblnum2, -5);
                Console.Write(lblnum2, Color.Aquamarine);
                num2 = double.Parse(Console.ReadLine());


                Divider();

                act.swap(num1, num2);


                TextCenter(lblnum1, -5);
                Console.WriteLine("First number : {0}", act.num1, Color.White);


                TextCenter(lblnum2, -5);
                Console.WriteLine("Second number : {0}", act.num2, Color.White);

                Console.ReadKey();



            }
            else if (select.Equals(ConsoleKey.B))
            {

                double num1, num2;
                string Op;




                Console.WriteLine("Enter First number :");
                num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Operator : ");
                Op = Console.ReadLine();
                Console.WriteLine("Enter Second number :");
                num2 = double.Parse(Console.ReadLine());

                if (Op == "+" || Op == "-" || Op == "/" || Op == "*" || Op == "%")
                {
                    Console.WriteLine(act.MDAS(num1, Op, num2));
                }
                else
                {
                    Console.WriteLine("Invalid Operator");
                }


            }
            else if (select.Equals(ConsoleKey.C))
            {
                double[] num = new double[3];

                for (int i = 0; i < num.Length; i++)
                {
                    Console.WriteLine($"Enter number {i + 1} : ");
                    num[i] = double.Parse(Console.ReadLine());
                }


                Console.WriteLine($"The Highest number is {num.Max()}");


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
            Console.BackgroundColor = Color.Black;
            Console.ForegroundColor = Color.White;
            Console.Clear();

            Console.WriteLine();

            Formatter[] subMenus = new Formatter[]
            {
                new Formatter("STRING MANIPULATION", Color.LightGoldenrodYellow),
                new Formatter("GRADE COMPUTATION", Color.Pink),
                new Formatter("SALES TRANSACTION", Color.PeachPuff),
            };

            lblSub = "I N T E R M I D I A T E";
            TextCenter(lblSub);
            Console.WriteLine(lblSub);
            TextCenter("", x);
            Console.WriteLineFormatted("[A]. {0}", Color.Yellow, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[B]. {1}", Color.Yellow, subMenus);
            TextCenter("", x);
            Console.WriteLineFormatted("[C]. {2}", Color.Yellow, subMenus);

            lblSelect = "SELECT THE LETTER OF YOUR CHOICE";
            TextCenter(lblSelect);
            Console.WriteLine(lblSelect, Color.White);
            lblBack = "[BACK SPACE] TO GO BACK";
            TextCenter(lblBack);
            Console.WriteLine(lblBack, Color.White);
            select = Console.ReadKey().Key;


            string lblSubMenus = "";
            Console.WriteLine();


            if (select.Equals(ConsoleKey.A))
            {
                Console.Clear();

                string fname, mname, lname, lblf, lblm, lbll, result;

                lblSubMenus = "STRING MANIPULATION";
                TextCenter(lblSubMenus);
                Console.WriteLine(lblSubMenus, Color.White);

                Divider();


                lblf = "Enter Firstname : ";
                TextCenter("", -15);
                Console.Write(lblf, Color.Aquamarine);
                fname = Console.ReadLine();


                lblm = "Enter Middlename : ";
                TextCenter("", -15);
                Console.Write(lblm, Color.Aquamarine);
                mname = Console.ReadLine();

                lbll = "Enter Lastname : ";
                TextCenter("", -15);
                Console.Write(lbll, Color.Aquamarine);
                lname = Console.ReadLine();


                Divider();

                result = "Hi ! " + act.strManipulation(fname, mname, lname);



                msg.Show(result, "Press any key to continue....");






            }
            else if (select.Equals(ConsoleKey.B))
            {
                Console.Clear();

                string sname, lblnosubj, lblsname, lblsubj, lblp, lblm, lblf, count;
                int subjNO;



                lblSubMenus = "GRADE COMPUTATION";
                TextCenter(lblSubMenus);
                Console.WriteLine(lblSubMenus, Color.White);

                Divider();

                lblnosubj = "Enter Number of Subject: ";
                TextCenter(lblnosubj);
                Console.Write(lblnosubj, Color.Aquamarine);
                subjNO = int.Parse(Console.ReadLine());

                lblsname = "Enter Student name: ";
                TextCenter(lblsname);
                Console.Write(lblsname, Color.Aquamarine);
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
                        lblSubMenus = "INPUTING OF GRADES";
                        TextCenter(lblSubMenus);
                        Console.WriteLine(lblSubMenus, Color.White);

                        count = $"Subject No. {i + 1}";
                        TextCenter(count);
                        Console.Write(count, Color.White);
                        Console.WriteLine();

                        lblsubj = "Enter Subj Name : ";
                        TextCenter("", -15);
                        Console.Write(lblsubj, Color.Aquamarine);
                        subjName[i] = Console.ReadLine();

                        lblp = "Enter Prelim Grade : ";
                        TextCenter("", -15);
                        Console.Write(lblp, Color.Aquamarine);
                        pre[i] = double.Parse(Console.ReadLine());

                        lblm = "Enter Midterm Grade : ";
                        TextCenter("", -15);
                        Console.Write(lblm, Color.Aquamarine);
                        mid[i] = double.Parse(Console.ReadLine());

                        lblf = "Enter Midterm Grade : ";
                        TextCenter("", -15);
                        Console.Write(lblf, Color.Aquamarine);
                        fin[i] = double.Parse(Console.ReadLine());

                        ave[i] = Math.Round(((pre[i] + mid[i] + fin[i]) / 3),2);

                        remarks[i] = (ave[i] <= 3.0) ? "PASSED" : "FAILED";

                        Console.Clear();

                    }
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
                Console.Clear();

                string lblCustNo, lblcname, lbltp, lblpay, count;
                int noCust;


                lblSubMenus = "SALES TRANSACTION";
                TextCenter(lblSubMenus);
                Console.WriteLine(lblSubMenus, Color.White);

                Divider();

                lblCustNo = "Enter Customer Number : ";
                TextCenter(lblCustNo);
                Console.Write(lblCustNo, Color.Aquamarine);
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

                        lblSubMenus = "INPUTING OF CUSTOMERS";
                        TextCenter(lblSubMenus);
                        Console.WriteLine(lblSubMenus, Color.White);

                        count = $"Customer No. {i + 1}";
                        TextCenter(count);
                        Console.Write(count, Color.White);
                        Console.WriteLine();

                        lblcname = "Enter Customer name: ";
                        TextCenter("", -15);
                        Console.Write(lblcname, Color.Aquamarine);
                        custName[i] = Console.ReadLine();

                        lbltp = "Enter Total Purchase : ";
                        TextCenter("", -15);
                        Console.Write(lbltp, Color.Aquamarine);
                        totalPurch[i] = double.Parse(Console.ReadLine());

                        disc[i] = (totalPurch[i] > 1000) ? totalPurch[i] * 0.05 : totalPurch[i] * 0.01;

                        totalDue[i] = totalPurch[i] - disc[i];


                        lblpay = "Enter Cash payment : ";
                        TextCenter("", -15);
                        Console.Write(lblpay, Color.Aquamarine);
                        cpay[i] = double.Parse(Console.ReadLine());


                        change[i] = cpay[i] - totalDue[i];


                        Console.Clear();

                    }
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
        


        public void Credits()
        {
            Console.BackgroundColor = Color.Blue;
            Console.Clear();

            msg.BoxColor = Color.DimGray;
            msg.BoxtextColor = Color.White;
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
        public void cursorPosLeft(string text)
        {
            Console.CursorLeft = ((Console.WindowWidth - 30) / 2) + text.Length;
        }
        public void TextCenter(string text, int addLeft = 0)
        {
            Console.SetCursorPosition(((Console.WindowWidth - text.Length) / 2) + addLeft, Console.CursorTop);
        }
        public void Divider()
        {
            string divider = "_____________________________________________________";

            TextCenter(divider);
 
            Console.WriteLine(divider);

        }
    }
}
