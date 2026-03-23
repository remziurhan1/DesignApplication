using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Infrastructure.Configurations.Costing
{
    public class AD2000SalesPriceConfiguration : IEntityTypeConfiguration<AD2000SalesPrice>
    {
        public void Configure(EntityTypeBuilder<AD2000SalesPrice> builder)
        {
            builder.HasOne(x => x.AD2000Calculation)
                .WithMany(x => x.SalesPrices)
                .HasForeignKey(x => x.AD2000CalculationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AD2000CostAnalysis)
                .WithMany(x => x.SalesPrices)
                .HasForeignKey(x => x.AD2000CostAnalysisId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LaborRate)
                .WithMany()
                .HasForeignKey(x => x.LaborRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GugHourlyRate)
                .WithMany()
                .HasForeignKey(x => x.GugHourlyRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FinanceOverheadRate)
                .WithMany()
                .HasForeignKey(x => x.FinanceOverheadRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GeneralManagementOverheadRate)
                .WithMany()
                .HasForeignKey(x => x.GeneralManagementOverheadRateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.AD2000CostAnalysisId).IsUnique();
        }
    }
}
