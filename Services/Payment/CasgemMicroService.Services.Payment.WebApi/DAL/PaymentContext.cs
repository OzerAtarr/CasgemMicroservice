using Microsoft.EntityFrameworkCore;

namespace CasgemMicroService.Services.Payment.WebApi.DAL
{
    public class PaymentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1433;database=CasgemPaymentDb;user=sa;password=123456Aa*");
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
