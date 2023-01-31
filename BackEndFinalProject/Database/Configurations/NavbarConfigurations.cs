using BackEndFinalProject.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BackEndFinalProject.Database.Configurations
{
    public class NavbarConfigurations : IEntityTypeConfiguration<Navbar>
    {
        public void Configure(EntityTypeBuilder<Navbar> builder)
        {
            builder
                .ToTable("Navbars");
        }
    }
}
