using CasgemMicroservice.Discount.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CasgemMicroservice.Discount.Context
{
    public class DapperContext : DbContext
    {
        public DapperContext(DbSet<DiscountCoupons> discountCouponses)
        {
            DiscountCouponses = discountCouponses;
        }

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CasgemDiscountDb;User=sa;Password=123456Aa*");
        }

        public DbSet<DiscountCoupons> DiscountCouponses { get; set; }


        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
