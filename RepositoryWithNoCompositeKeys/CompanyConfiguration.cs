using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryWithNoCompositeKeys;
using System;

namespace RepositoryWithNoCompositeKeys
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(new Company { Id = Guid.Parse("00000000-0000-0000-0000-000000000010") });
        }
    }
}