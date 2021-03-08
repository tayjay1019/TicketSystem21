using System;
using System.Collections.Generic;

namespace TicketSystem21
{
    public class Ticket
    {
        public UInt64 ticketId { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set;}
        public List<string> watching { get; set; }

        public Ticket()
        {
            watching = new List<string>();
        }

        public virtual string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmiter: {submitter}\nWatching: {string.Join(", ", watching)}\n";
        }
    }
}
