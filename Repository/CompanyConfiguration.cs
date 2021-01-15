using RepositoryWithCompositeKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace RepositoryWithCompositeKeys
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CompanyId);

            builder.HasData(new Company { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), CompanyId = 1 });
        }
    }
}