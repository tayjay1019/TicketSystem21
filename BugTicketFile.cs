using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystem21
{

    public class BugTicketFile
    {
        public string filePath { get; set; }
        public List<BugTicket> BugTickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();


        public BugTicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            BugTickets = new List<BugTicket>();

            try{
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    BugTicket ticket = new BugTicket();
                    string line = sr.ReadLine();
                    string[] ticketDetails = line.Split(',');
                    ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.submitter = ticketDetails[4];
                    ticket.assigned = ticketDetails[5];
                    ticket.watching = ticketDetails[6].Split('|').ToList();
                    ticket.severity = ticketDetails[7];

                    BugTickets.Add(ticket);
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", BugTickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        public void AddTicket(BugTicket ticket)
        {
            //try{
                if (BugTickets.Count == 0){
                    ticket.ticketId = 1;
                }else {

                    ticket.ticketId = BugTickets.Max(m => m.ticketId) +1;
                }
                StreamWriter sw = new StreamWriter(filePath, true);
                // TODO add the data into the list
                sw.WriteLine($"{ticket.ticketId},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|", ticket.watching)},{ticket.severity}");
                sw.Close();
                BugTickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketId);

            //}
            //catch(Exception ex)
            //{
                //logger.Error(ex.Message);
            //}
        }

    }

}
