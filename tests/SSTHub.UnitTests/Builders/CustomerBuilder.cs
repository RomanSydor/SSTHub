using SSTHub.Domain.Entities;

namespace SSTHub.UnitTests.Builders
{
    public class CustomerBuilder
    {
        private Customer _customer;

        public int Id => 0;
        public DateTime CreatedAt => new(2024, 1, 1);
        public string FirstName => "TestFN";
        public string LastName => "TestLN";
        public string Email => "test@email.com";
        public string Phone => "0632223344";
        public List<Event> Events => new();

        public CustomerBuilder() 
        {
            _customer = WithDefaultValues();
        }

        public Customer WithDefaultValues()
        {
            _customer = new Customer
            {
                Id = Id,
                CreatedAt = CreatedAt,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Events = Events,
            };

            return _customer;
        }
    }
}
