using System;
using System.Collections.Generic;

namespace Core.Classes
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Address FromAddress { get; private set; }
        public Address ToAddress { get; private set; }
        public Address NexusAddress { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Shipping { get; private set; }
        public IEnumerable<LineItem> Items { get; private set; }

        public Order(Guid id, Address fromAddress, Address toAddress, Address nexusAddress, decimal amount, decimal shipping, IEnumerable<LineItem> items)
        {
            Id = id;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            NexusAddress = nexusAddress;
            Amount = amount;
            Shipping = shipping;
            Items = items;
        }
    }
}