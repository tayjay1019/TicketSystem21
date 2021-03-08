using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystem21
{

    public class EnhancementTicketFile
    {
        public string filePath { get; set; }
        public List<EnhancementTicket> ETickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public EnhancementTicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            ETickets = new List<EnhancementTicket>();

            try{
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    EnhancementTicket ticket = new EnhancementTicket();
                    string line = sr.ReadLine();
                    string[] ticketDetails = line.Split(',');
                    ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.submitter = ticketDetails[4];
                    ticket.assigned = ticketDetails[5];
                    ticket.watching = ticketDetails[6].Split('|').ToList();
                    ticket.software = ticketDetails[7];
                    ticket.cost = UInt64.Parse(ticketDetails[8]);
                    ticket.reason = ticketDetails[9];
                    ticket.estimate = UInt64.Parse(ticketDetails[10]);

                    ETickets.Add(ticket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", ETickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        public void AddTicket(EnhancementTicket ticket)
        {
            try{
                ticket.ticketId = ETickets.Max(m => m.ticketId) +1;
                StreamWriter sw = new StreamWriter(filePath, true);
                // TODO add the data into the list
                sw.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|", ticket.watching)},{ticket.software},{ticket.cost},{ticket.reason},{ticket.estimate}");
                sw.Close();
                ETickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketId);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }


    }
}
