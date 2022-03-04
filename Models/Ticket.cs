namespace CodePractice.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        internal bool IsProcessed { get; set; }
        public float Cost { get; set; }

        public virtual float CalculateCost(float cost = 0)
        {
            return IsProcessed ? Cost : cost;
        }

        public Ticket CreateNew(int id, string description, int assigneeId)
        {
            return new Ticket()
            {
                Id = id,
                Description = description,
                AssigneeId = assigneeId,
                IsProcessed = false,
                Cost = CalculateCost()
            };
        }

        public virtual void UpdateTicket(string description, int assigneeId)
        {
            Description = description;
            AssigneeId = assigneeId;
            Cost = CalculateCost();
        }
        
        public virtual void TicketIsProcessed()
        {
            IsProcessed = true;
        }
    }
}