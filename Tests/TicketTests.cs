using System.Security.Cryptography;
using CodePractice.Models;
using NUnit.Framework;

namespace CodePractice.Tests
{
    [TestFixture]
    public class TicketTests
    {
        [Test]
        public void GetBasicTicket_ReturnsTicket()
        {
            const int id = 9999;
            const string description = "Example Ticket";
            const int assigneeId = 10000;
            var ticket = new Ticket().CreateNew(id, description, assigneeId);
            Assert.IsNotNull(ticket);
            Assert.AreEqual(id, ticket.Id);
            Assert.AreEqual(description, ticket.Description);
            Assert.AreEqual(assigneeId, ticket.AssigneeId);
            Assert.IsFalse(ticket.IsProcessed);
            Assert.AreEqual(0, ticket.Cost);
        }

        [Test]
        public void GetSoftwareTicket_ReturnsTicket()
        {
            const int id = 1;
            const string description = "software ticket description";
            const int assigneeId = 3;
            const int databaseId = 1;
            const float hoursWorked = 5;
            const float expectedCost = hoursWorked * Constants.Constants.DevCost;
            var ticket = new SoftwareTicket().CreateNew(id, description, assigneeId, databaseId, hoursWorked);
            Assert.IsNotNull(ticket);
            Assert.AreEqual(id, ticket.Id);
            Assert.AreEqual(description, ticket.Description);
            Assert.AreEqual(assigneeId, ticket.AssigneeId);
            Assert.IsFalse(ticket.IsProcessed);
            Assert.AreEqual(databaseId, ticket.DatabaseId);
            Assert.AreEqual(hoursWorked, ticket.HoursWorked);
            Assert.AreEqual(expectedCost, ticket.Cost);
        }

        [Test]
        public void GetHardwareTicket_ReturnsTicket()
        {
            const int id = 2;
            const string description = "hardware ticket description";
            const int assigneeId = 1;
            const string address = "short street, disneyland";
            const int itemTypeId = 1;
            const int quantity = 2;
            const float cost = quantity * itemTypeId;

            var ticket = new HardwareTicket().CreateNew(id, description, assigneeId, address, itemTypeId, quantity);
            Assert.IsNotNull(ticket);
            Assert.AreEqual(id, ticket.Id);
            Assert.AreEqual(description, ticket.Description);
            Assert.AreEqual(assigneeId, ticket.AssigneeId);
            Assert.AreEqual(cost, ticket.Cost);
            Assert.AreEqual(address, ticket.Address);
            Assert.AreEqual(itemTypeId, ticket.ItemTypeId);
            Assert.AreEqual(quantity, ticket.Quantity);
        }

        [Test]
        public void GetTrainingTicket_ReturnsTicket()
        {
            const int id = 4;
            const string description = "training ticket description";
            const int assigneeId = 2;
            const float cost = 100;

            var ticket = new TrainingTicket().CreateNew(id, description, assigneeId, cost);
            Assert.IsNotNull(ticket);
            Assert.AreEqual(id, ticket.Id);
            Assert.AreEqual(description, ticket.Description);
            Assert.AreEqual(assigneeId, ticket.AssigneeId);
            Assert.AreEqual(cost, ticket.Cost);
        }

        [Test]
        public void UpdateTicket_ValuesUpdated()
        {
            const int id = 9999;
            const string description = "Example Ticket";
            const int assigneeId = 10000;
            const string newDescription = "Changed the name";
            const int newAssignee = 1;

            var ticket = new Ticket().CreateNew(id, description, assigneeId);
            ticket.UpdateTicket(newDescription, newAssignee);
            Assert.AreEqual(newDescription, ticket.Description);
            Assert.AreEqual(newAssignee, ticket.AssigneeId);
        }
        
        [Test]
        public void UpdateSoftwareTicket_ValuesUpdated()
        {
            const int id = 1;
            const string description = "software ticket description";
            const string newDescription = "Changed the name";
            const int assigneeId = 3;
            const int newAssignee = 1;
            const int databaseId = 1;
            const int updatedDatabaseId = 2;
            const int hoursWorked = 5;
            const int updatedHoursWorked = 10;
            const float expectedCost = updatedHoursWorked * Constants.Constants.DevCost;

            var ticket = new SoftwareTicket().CreateNew(id, description, assigneeId, databaseId, hoursWorked);
            ticket.UpdateTicket(newDescription, newAssignee, updatedDatabaseId, updatedHoursWorked);
            Assert.AreEqual(newDescription, ticket.Description);
            Assert.AreEqual(newAssignee, ticket.AssigneeId);
            Assert.AreEqual(updatedDatabaseId, ticket.DatabaseId);
            Assert.AreEqual(updatedHoursWorked, ticket.HoursWorked);
            Assert.AreEqual(expectedCost, ticket.Cost);
        }

        [Test]
        public void UpdateHardwareTicket_ValuesUpdated()
        {
            const int id = 1;
            const string description = "hardware ticket description";
            const string newDescription = "Changed the name";
            const int assigneeId = 3;
            const int newAssignee = 1;
            const string address = "short street, disneyland";
            const string updatedAddress = "long street, disneyland";
            const int itemTypeId = 1;
            const int updatedItemTypeId = 2;
            const int quantity = 2;
            const int updatedQuantity = 5;
            const float expectedCost = updatedQuantity * updatedItemTypeId;

            var ticket = new HardwareTicket().CreateNew(id, description, assigneeId, address, itemTypeId, quantity);
            ticket.UpdateTicket(newDescription, newAssignee, updatedAddress, updatedItemTypeId, updatedQuantity);
            Assert.IsNotNull(ticket);
            Assert.AreEqual(id, ticket.Id);
            Assert.AreEqual(newDescription, ticket.Description);
            Assert.AreEqual(newAssignee, ticket.AssigneeId);
            Assert.AreEqual(expectedCost, ticket.Cost);
            Assert.AreEqual(updatedAddress, ticket.Address);
            Assert.AreEqual(updatedItemTypeId, ticket.ItemTypeId);
            Assert.AreEqual(updatedQuantity, ticket.Quantity);
        }
    }
}