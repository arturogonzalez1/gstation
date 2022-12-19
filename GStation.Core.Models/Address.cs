﻿namespace GStation.Core.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Subdivision { get; set; }
        public string City { get; set; }
        public State State { get; set; }
    }
}
