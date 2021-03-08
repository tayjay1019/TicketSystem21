using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystem21
{

    public class TaskTicketFile
    {

        public string filePath { get; set; }
        public List<TaskTicket> TaskTickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TaskTicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            TaskTickets = new List<TaskTicket>();

            try{
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    TaskTicket ticket = new TaskTicket();
                    string line = sr.ReadLine();
                    string[] ticketDetails = line.Split(',');
                    ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.submitter = ticketDetails[4];
                    ticket.assigned = ticketDetails[5];
                    ticket.watching = ticketDetails[6].Split('|').ToList();
                    ticket.projectName = ticketDetails[7];
                    ticket.dueDate = DateTime.Parse(ticketDetails[8]);

                    TaskTickets.Add(ticket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", TaskTickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        public void AddTicket(TaskTicket ticket)
        {
            try{
                ticket.ticketId = TaskTickets.Max(m => m.ticketId) +1;
                StreamWriter sw = new StreamWriter(filePath, true);
                // TODO add the data into the list
                sw.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|", ticket.watching)},{ticket.projectName},{ticket.dueDate}");
                sw.Close();
                TaskTickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketId);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

    }
}