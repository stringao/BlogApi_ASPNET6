using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // TABELA
            builder.ToTable("Category");

            // CHAVE PRIMÁRIA
            builder.HasKey( x=> x.Id);

            // IDENTITY
            builder.Property( x=> x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // PRIMARY KEY IDENTITY (1, 1)

            // PROPRIEDADES
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            //ÍNDICES
            builder.HasIndex(x=> x.Slug,"IX_Category_Slug")
                .IsUnique();

        }
    }
}
