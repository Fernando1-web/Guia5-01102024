using FJMA.API.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace FJMA.API.Models.DAL
{
    public class FJMAContext : DbContext
    {
        public FJMAContext(DbContextOptions<FJMAContext> options) : base(options)
        {
        }

        public DbSet<ProductFJMA> ProductsFJMA { get; set; }
    }
}
