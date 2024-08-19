using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APIPB301.Data.Entities;

namespace APIPB301.Data.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.PageCount).IsRequired();
    }
}
