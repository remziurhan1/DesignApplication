using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC.ProductManagement.Domain.Entities.Costing;

namespace MVC.ProductManagement.Infrastructure.Configurations.Costing
{
    public class EN13458SalesPriceConfiguration : IEntityTypeConfiguration<EN13458SalesPrice>
    {
        public void Configure(EntityTypeBuilder<EN13458SalesPrice> builder)
        {
            builder.HasOne(x => x.EN13458Calculation)
                .WithMany(x => x.SalesPrices)
                .HasForeignKey(x => x.EN13458CalculationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.EN13458CostAnalysis)
                .WithMany(x => x.SalesPrices)
                .HasForeignKey(x => x.EN13458CostAnalysisId)
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

            builder.HasIndex(x => x.EN13458CostAnalysisId).IsUnique();
        }
    }
}
