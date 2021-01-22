using System;

namespace Core.Classes
{
    public class Address
    {
        public Guid Id { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }

        public Address(Guid id, string country, string zipCode, string state, string city, string street)
        {
            Id = id;
            Country = country;
            ZipCode = zipCode;
            State = state;
            City = city;
            Street = street;
        }
    }
}