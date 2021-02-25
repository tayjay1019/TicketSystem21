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

            string ticketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
            TicketFile ticketFile = new TicketFile(ticketFilePath);
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
                     Ticket ticket = new Ticket();
                    Console.WriteLine("Enter a summary -");
                    ticket.summary = Console.ReadLine();

                    Console.WriteLine("Enter a priority level -");
                    ticket.priority = Console.ReadLine();

                    Console.WriteLine("Enter your name -");
                    ticket.submitter = Console.ReadLine();

                    Console.WriteLine("Enter who this is assigned to -");
                    ticket.assigned = Console.ReadLine();

                    String input;
                    do
                    {
                        Console.WriteLine("Enter a watcher (or done to quit)");
                        input = Console.ReadLine();
                        if (input != "done" && input.Length > 0)
                        {
                            ticket.watching.Add(input);
                        }
                    } while (input != "done");

                    if (ticket.watching.Count == 0)
                    {
                        ticket.watching.Add("(no one watching)");
                    }
                    ticketFile.AddTicket(ticket);
                 }
                 else if (choice =="2")
                 {
                     foreach(Ticket m in ticketFile.Tickets)
                    {Console.WriteLine(m.Display());}
                 }

            } while (choice == "1" || choice == "2");

            logger.Info("Program ended");
        }
    }
}
