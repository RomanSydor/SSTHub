using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Enums;

namespace SSTHub.Infrastucture.EntityConfigurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(e => e.Id);

            builder.HasData(
                new Event
                {
                    Id = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 16, 16, 0, 0),
                    StartAt = new DateTime(2024, 1, 18, 16, 0, 0),
                    Status = EventStatuses.Created,
                    CustomerId = 1,
                    EmployeeId = 1,
                    HubId = 1,
                    ServiceId = 1,
                },
                new Event
                {
                    Id = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 14, 16, 0, 0),
                    StartAt = new DateTime(2024, 1, 16, 15, 0, 0),
                    Status = EventStatuses.Finished,
                    CustomerId = 2,
                    EmployeeId = 2,
                    HubId = 2,
                    ServiceId = 2,
                }
            );
        }
    }
}
