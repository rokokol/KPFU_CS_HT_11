using System;
using System.Globalization;
using System.Threading;
using BankTools;
using BuildingMaster;

namespace Tymakov
{
    internal class Program
    {
        /// <summary>
        /// Writes "> " in start of the line.
        /// </summary>
        static void Offer()
        {
            Console.Write("> ");
        }

        /// <summary>
        /// Writes a number of the task.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="number">Number of the task.</param>
        static void Message(string message, int number)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number, message);
            Offer();
            Console.ReadKey();
        }
        
        public static void Main(string[] args)
        {
            #region Lab

            void Lab13_2()
            {
                Message("tests indexer for account type", 1);
                AccountTypeFabric fabric = new AccountTypeFabric();
                AccountType first = fabric.GetAccount(fabric.CreateAccount(200));
                AccountType second = fabric.GetAccount(fabric.CreateAccount(300));
                Console.WriteLine("First:");
                Console.WriteLine(first);
                Console.WriteLine("Second:");
                Console.WriteLine(second);
                Console.WriteLine("Get second from first:");
                Console.WriteLine(first[1]);
            }

            void Lab14_1()
            {
                Message("test the debugging attribute", 2);
                AccountTypeFabric fabric = new AccountTypeFabric();
                AccountType account = fabric.GetAccount(fabric.CreateAccount(200));
                Console.WriteLine("DEBUG attribute");
                #if(DEBUG)
                account.DumpToScreen();
                #else
                Console.WriteLine("Really sus");
                #endif

                Console.WriteLine("AMOGUSUSUS attribute");
                #if(AMOGUSUSUS)  
                account.DumpToScreen();
                #else
                Console.WriteLine("Really sus");
                #endif
            }

            #endregion

            #region HT

            void HT13_2()
            {
                Message("tests area class", 1);
                Area area = new Area();
                area[0] = Creator.GetBuilding(Creator.Create(100, 100, 10, 1));
                area[1] = Creator.GetBuilding(Creator.Create(200, 200, 20, 2));
                Console.WriteLine("First building in the area:");
                Console.WriteLine(area[0]);
                Console.WriteLine("Second building in the area:");
                Console.WriteLine(area[1]);
            }

            void HT14_1()
            {
                Message("tests build attribute", 2);
                Building first = Creator.GetBuilding(Creator.Create(100, 100, 10, 1));
                Building second = Creator.GetBuilding(Creator.Create(200, 200, 20, 2));
            }

            #endregion
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru");
            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("||===========================<\\\\>===========================||");
                Console.WriteLine("Please, input \"HT\", if you want to check the HT solutions  or type \"exit\" to stop");
                Offer();
                string respond = Console.ReadLine().ToLower().Trim();
                if (respond.Equals("exit"))
                {
                    run = false;
                    continue;
                }
                Console.WriteLine("Please, input a number of a task:");
                Console.WriteLine("(example: 11_1)");
                Offer();
                string number = Console.ReadLine();
                if (respond.Equals("ht") || respond.Equals("нт")) // and russian-letters case
                {
                    switch (number)
                    {
                        case "13_2": HT13_2(); break; 
                        case "14_1": HT14_1(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
                else
                {
                    switch (number)
                    {
                        case "13_2": Lab13_2(); break;
                        case "14_1": Lab14_1(); break;
                        default: Console.WriteLine("This is not a command or a number of task"); break;
                    }
                }
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadKey();
        }
    }
}