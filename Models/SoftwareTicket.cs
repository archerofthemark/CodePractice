namespace CodePractice.Models
{
    public class SoftwareTicket : Ticket
    {
        public int DatabaseId { get; set; }
        public float HoursWorked { get; set; }

        public SoftwareTicket(){}

        private SoftwareTicket(Ticket ticket)
        {
            Id = ticket.Id;
            Description = ticket.Description;
            AssigneeId = ticket.AssigneeId;
        }

        private new float CalculateCost(float hoursWorked)
        {
            if (IsProcessed) return Cost;
            return hoursWorked * Constants.Constants.DevCost;
        }

        public SoftwareTicket CreateNew(int id, string description, int assigneeId, int databaseId, float hoursWorked)
        {
            var ticket = FromBase(base.CreateNew(id, description, assigneeId));
            ticket.DatabaseId = databaseId;
            ticket.HoursWorked = hoursWorked;
            ticket.Cost = CalculateCost(hoursWorked);
            return ticket;
        }

        public void UpdateTicket(string description, int assigneeId, int databaseId, float hoursWorked)
        {
            base.UpdateTicket(description, assigneeId);
            DatabaseId = databaseId;
            HoursWorked = hoursWorked;
            Cost = CalculateCost(hoursWorked);
        }

        private static SoftwareTicket FromBase(Ticket ticket)
        {
            return new SoftwareTicket(ticket);
        }
    }
}