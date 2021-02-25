using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace TicketSystem21
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info("Program started");

            string choice = "";

            do
            {
                Console.WriteLine("1) Add Ticket");
                Console.WriteLine("2) Display All Tickets");
                Console.WriteLine("Enter to quit");

                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);
                 if (choice == "1")
                 {

                 }
                 else if (choice =="2")
                 {
                     
                 }

            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
