using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NpgsqlProblem;

public class DbConfiguration : IEntityTypeConfiguration<DummyDataClass>
{
    public void Configure(EntityTypeBuilder<DummyDataClass> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s=>s.Field1).HasColumnType("text");
        builder.Property(s=>s.Field2).HasColumnType("text");
        builder.Property(s=>s.Field3).HasColumnType("text");
        builder.HasGeneratedTsVectorColumn(a => a.SearchVector, "turkish", a => new
        {
            a.Field1,
            a.Field2,
            a.Field3
        })
        .HasIndex(s => s.SearchVector).HasMethod("GIN");
    }
}