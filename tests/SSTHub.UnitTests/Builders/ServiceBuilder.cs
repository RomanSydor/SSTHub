using SSTHub.Domain.Entities;

namespace SSTHub.UnitTests.Builders
{
    public class ServiceBuilder
    {
        private Service _service;

        public int Id => 0;
        public bool IsActive => false;
        public DateTime CreatedAt => new(2024, 1, 1);
        public string Name => "TestService";
        public int DurationInMinutes => 45;
        public int Price => 100;

        public ServiceBuilder()
        {
            _service = WithDefaultValues();
        }

        public Service WithDefaultValues()
        {
            _service = new Service
            {
                Id = Id,
                IsActive = IsActive,
                CreatedAt = CreatedAt,
                Name = Name,
                DurationInMinutes = DurationInMinutes,
                Price = Price,
            };

            return _service;
        }

        public Service WithId(int id)
        {
            var service = WithDefaultValues();
            service.Id = id;
            return service;
        }
    }
}
