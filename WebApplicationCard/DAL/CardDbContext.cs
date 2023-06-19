using Microsoft.EntityFrameworkCore;
using WebApplicationCard.Models.DBEntities;

namespace WebApplicationCard.DAL
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
    }
}
