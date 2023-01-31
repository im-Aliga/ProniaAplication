using BackEndFinalProject.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BackEndFinalProject.Database.Configurations
{
    public class PlantImageConfigurations : IEntityTypeConfiguration<PlantImage>
    {
        public void Configure(EntityTypeBuilder<PlantImage> builder)
        {
            builder
                .ToTable("PlantImages");
            builder
               .HasOne(pi => pi.Plant)
               .WithMany(b => b.PlantImages)
               .HasForeignKey(pi => pi.PlantId);
        }
    }
}
