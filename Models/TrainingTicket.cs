namespace CodePractice.Models
{
    public class TrainingTicket : Ticket
    {
        public TrainingTicket() { }
        private TrainingTicket(Ticket ticket)
        {
            Id = ticket.Id;
            Description = ticket.Description;
            AssigneeId = ticket.AssigneeId;
        }
        
        public override float CalculateCost(float cost = 0)
        {
            return IsProcessed ? Cost : cost;
        }

        public TrainingTicket CreateNew(int id, string description, int assigneeId, float cost)
        {
            var ticket = FromBase(base.CreateNew(id, description, assigneeId));
            ticket.Cost = CalculateCost(cost);
            return ticket;
        }

        public void UpdateTicket(string description, int assigneeId, float cost)
        {
            base.UpdateTicket(description, assigneeId);
            Cost = CalculateCost(cost);
        }

        private static TrainingTicket FromBase(Ticket ticket)
        {
            return new TrainingTicket(ticket);
        }
    }
}