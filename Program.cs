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

            //string ticketfilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
            string bugTicketFilePath = Directory.GetCurrentDirectory() + "\\bugTickets.csv";
            string taskTicketFilePath = Directory.GetCurrentDirectory() + "\\taskTickets.csv";
            string eTicketFilePath = Directory.GetCurrentDirectory() + "\\eTickets.csv";
            //TicketFile ticketFile = new TicketFile(ticketFilePath);
            BugTicketFile bugTicketFile = new BugTicketFile(bugTicketFilePath);
            TaskTicketFile taskTicketFile = new TaskTicketFile(taskTicketFilePath);
            EnhancementTicketFile eTicketFile = new EnhancementTicketFile(eTicketFilePath);
            string choice = "";
            string secondChoice = "";


            do
            {
                Console.WriteLine("Select a type of ticket");
                Console.WriteLine("1) Bug Tickets");
                Console.WriteLine("2) Task Tickets");
                Console.WriteLine("3) Enhancement Tickets");

                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);

                if (choice == "1")
                {
                    do
                    {
                        Console.WriteLine("Bug Tickets");
                        Console.WriteLine("1) Add Bug Ticket");
                        Console.WriteLine("2) Display all Bug Tickets");
                        Console.WriteLine("Type 'done' to exit");

                        secondChoice = Console.ReadLine();
                        logger.Info("User second choice: {SecondChoice}", secondChoice);

                        if (secondChoice == "1")
                        {
                            BugTicket bugTicket = new BugTicket();
                            Console.WriteLine("Enter a summary -");
                            bugTicket.summary = Console.ReadLine();

                            Console.WriteLine("Enter a priority level -");
                            bugTicket.priority = Console.ReadLine();

                            Console.WriteLine("Enter your name -");
                            bugTicket.submitter = Console.ReadLine();

                            Console.WriteLine("Enter who this is assigned to -");
                            bugTicket.assigned = Console.ReadLine();

                             String input;
                             do
                            {
                                Console.WriteLine("Enter a watcher (or 'done' to quit)");
                                input = Console.ReadLine();
                                if (input != "done" && input.Length > 0)
                                {
                                    bugTicket.watching.Add(input);
                                 }
                             } while (input != "done");

                             if (bugTicket.watching.Count == 0)
                            {
                                bugTicket.watching.Add("(no one watching)");
                            }

                             Console.WriteLine("Enter severity -");
                             bugTicket.severity = Console.ReadLine();

                             bugTicketFile.AddTicket(bugTicket);

                        }
                        else if (secondChoice == "2")
                        {
                            foreach(BugTicket t in bugTicketFile.BugTickets)
                            {Console.WriteLine(t.Display());}
                        }

                    } while (secondChoice == "1" || secondChoice == "2");

                }
                else if (choice == "2")
                {
                    do
                    {
                        Console.WriteLine("Task Tickets");
                        Console.WriteLine("1) Add Task Ticket");
                        Console.WriteLine("2) Display all Task Tickets");
                        Console.WriteLine("Type 'done' to exit");

                        secondChoice = Console.ReadLine();
                        logger.Info("User second choice: {SecondChoice}", secondChoice);

                        if (secondChoice == "1")
                        {
                            TaskTicket taskTicket = new TaskTicket();
                            Console.WriteLine("Enter a summary -");
                            taskTicket.summary = Console.ReadLine();

                            Console.WriteLine("Enter a priority level -");
                            taskTicket.priority = Console.ReadLine();

                            Console.WriteLine("Enter your name -");
                            taskTicket.submitter = Console.ReadLine();

                            Console.WriteLine("Enter who this is assigned to -");
                            taskTicket.assigned = Console.ReadLine();

                             String input;
                             do
                            {
                                Console.WriteLine("Enter a watcher (or 'done' to quit)");
                                input = Console.ReadLine();
                                if (input != "done" && input.Length > 0)
                                {
                                    taskTicket.watching.Add(input);
                                 }
                             } while (input != "done");

                             if (taskTicket.watching.Count == 0)
                            {
                                taskTicket.watching.Add("(no one watching)");
                            }

                             Console.WriteLine("Enter Project Name -");
                             taskTicket.projectName = Console.ReadLine();

                             Console.WriteLine("Enter Due Date -");
                             taskTicket.dueDate = DateTime.Parse(Console.ReadLine());

                             taskTicketFile.AddTicket(taskTicket);

                        }
                        else if (secondChoice == "2")
                        {
                            foreach(TaskTicket t in taskTicketFile.TaskTickets)
                            {Console.WriteLine(t.Display());}
                        }

                    } while (secondChoice == "1" || secondChoice == "2");
                }
                else if (choice == "3")
                {
                    do
                    {
                        Console.WriteLine("Enhancement Tickets");
                        Console.WriteLine("1) Add Enhancement Ticket");
                        Console.WriteLine("2) Display all Enhancement Tickets");
                        Console.WriteLine("Type 'done' to exit");

                        secondChoice = Console.ReadLine();
                        logger.Info("User second choice: {SecondChoice}", secondChoice);

                        if (secondChoice == "1")
                        {
                            EnhancementTicket eTicket = new EnhancementTicket();
                            Console.WriteLine("Enter a summary -");
                            eTicket.summary = Console.ReadLine();

                            Console.WriteLine("Enter a priority level -");
                            eTicket.priority = Console.ReadLine();

                            Console.WriteLine("Enter your name -");
                            eTicket.submitter = Console.ReadLine();

                            Console.WriteLine("Enter who this is assigned to -");
                            eTicket.assigned = Console.ReadLine();

                             String input;
                             do
                            {
                                Console.WriteLine("Enter a watcher (or 'done' to quit)");
                                input = Console.ReadLine();
                                if (input != "done" && input.Length > 0)
                                {
                                    eTicket.watching.Add(input);
                                 }
                             } while (input != "done");

                             if (eTicket.watching.Count == 0)
                            {
                                eTicket.watching.Add("(no one watching)");
                            }

                             Console.WriteLine("Enter the software -");
                             eTicket.software = Console.ReadLine();

                             Console.WriteLine("Enter Cost -");
                             eTicket.cost = UInt64.Parse(Console.ReadLine());

                             Console.WriteLine("Enter Reason for Enhancement -");
                             eTicket.reason = Console.ReadLine();

                             Console.WriteLine("Enter Estimate -");
                             eTicket.estimate = UInt64.Parse(Console.ReadLine());

                             eTicketFile.AddTicket(eTicket);

                        }
                        else if (secondChoice == "2")
                        {
                            foreach(EnhancementTicket t in eTicketFile.ETickets)
                            {Console.WriteLine(t.Display());}
                        }

                    } while (secondChoice == "1" || secondChoice == "2");
                }

            }while (choice == "1" || choice == "2" || choice == "3");

            /* do
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
                     foreach(Ticket t in ticketFile.Tickets)
                    {Console.WriteLine(t.Display());}
                 }

            } while (choice == "1" || choice == "2"); */

            logger.Info("Program ended");
        }
    }
}
