using System.Collections.Generic;

namespace Twoishday.Models.ViewModels
{
    public class DashboardViewModel
    {
        public Company Company { get; set; }
        public List<Project> Projects { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<TDUser> Members { get; set; }

        // KPI Data
        public int TotalProjects { get; set; }
        public int TotalTickets { get; set; }
        public int OpenTickets { get; set; }
        public int ClosedTickets { get; set; }
        public int InProgressTickets { get; set; }
        public int UnassignedTickets { get; set; }

        // My Assigned Tickets
        public List<Ticket> MyAssignedTickets { get; set; }

        // Chart Data
        public Dictionary<string, int> TicketsByStatus { get; set; }
        public Dictionary<string, int> TicketsByPriority { get; set; }

        // Recent Activity
        public List<Ticket> RecentTickets { get; set; }
    }
}
