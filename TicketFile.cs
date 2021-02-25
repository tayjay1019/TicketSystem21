using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystem21
{

    public class TicketFile
    {

        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();

            try{
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    Ticket ticket = new Ticket();
                    string line = sr.ReadLine();
                }
                sr.Close();
                logger.Info("Tickets in file {Count}", Tickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        public void AddTicket(Ticket ticket)
        {
            try{
                ticket.ticketId = Tickets.Max(m => m.ticketId) +1;
                StreamWriter sw = new StreamWriter(filePath, true);
                // TODO add the data into the list
                //
                sw.Close();
                Tickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketId);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
            }
        }


    }
}