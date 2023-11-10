using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSTHub.Admin.Domain.Entities;

namespace SSTHub.Admin.Infrastructure.EntityConfigurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        throw new NotImplementedException();
    }
}
