using System;

namespace UserTesting.Domain.Entities.Offices
{
    public class Office
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Office()
        {
            Id = new Guid();
            Name = string.Empty;
        }
    }
}
