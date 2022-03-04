namespace CodePractice.Models
{
    public class HardwareTicket : Ticket
    {
        public string Address { get; set; }
        public int ItemTypeId { get; set; }
        public int Quantity { get; set; }
        
        public HardwareTicket(){}

        private HardwareTicket(Ticket ticket)
        {
            Id = ticket.Id;
            Description = ticket.Description;
            AssigneeId = ticket.AssigneeId;
        }
        

        private float CalculateCost(int quantity, int itemTypeId)
        {
            if (IsProcessed) return Cost;
            return quantity * itemTypeId;
        }

        public HardwareTicket CreateNew(int id, string description, int assigneeId, string address, int itemTypeId, int quantity)
        {
            var ticket = FromBase(base.CreateNew(id, description, assigneeId));
            ticket.Address = address;
            ticket.ItemTypeId = itemTypeId;
            ticket.Quantity = quantity;
            ticket.Cost = CalculateCost(quantity, itemTypeId);
            return ticket;
        }

        public void UpdateTicket(string description, int assigneeId, string address, int itemTypeId, int quantity)
        {
            base.UpdateTicket(description, assigneeId);
            Address = address;
            ItemTypeId = itemTypeId;
            Quantity = quantity;
            Cost = CalculateCost(quantity, itemTypeId);
        }

        private static HardwareTicket FromBase(Ticket ticket)
        {
            return new HardwareTicket(ticket);
        }
    }
}