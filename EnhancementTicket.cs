using System;
using System.Collections.Generic;

namespace TicketSystem21 {

    public class EnhancementTicket : Ticket
    {
        public string software {get; set;}

        public UInt64 cost {get; set;}

        public string reason {get; set;}

        public UInt64 estimate {get; set;}

        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmiter: {submitter}\nWatching: {string.Join(", ", watching)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}\n";

        }
    }

}