using System;
using System.Collections.Generic;

namespace TicketSystem21 {

    public class BugTicket : Ticket
    {
        public string severity {get; set;}

        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmiter: {submitter}\nWatching: {string.Join(", ", watching)}\nSeverity: {severity}";

        }
    }

}
