using System;
using System.Collections.Generic;

namespace TicketSystem21 {

    public class TaskTicket : Ticket
    {
        public string projectName {get; set;}

        public DateTime dueDate {get; set;}

        public override string Display()
        {
            return $"Id: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmiter: {submitter}\nWatching: {string.Join(", ", watching)}\nProjectName: {projectName}\nDueDate: {dueDate}\n";

        }
    }

}