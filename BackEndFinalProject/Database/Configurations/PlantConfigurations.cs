using BackEndFinalProject.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BackEndFinalProject.Database.Configurations
{
    public class PlantConfigurations : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder
                .ToTable("Plants");
        }
    }
}
