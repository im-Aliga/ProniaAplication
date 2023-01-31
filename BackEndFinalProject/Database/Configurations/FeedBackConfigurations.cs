using BackEndFinalProject.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BackEndFinalProject.Database.Configurations
{
    public class FeedBackConfigurations : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder
                .ToTable("Feedbacks");
        }
    }
}
