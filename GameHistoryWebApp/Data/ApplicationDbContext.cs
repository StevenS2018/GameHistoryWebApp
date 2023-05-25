using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GameHistoryWebApp.Models;

namespace GameHistoryWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GameHistoryWebApp.Models.GameHistoryModel> GameHistoryModel { get; set; } = default!;
    }
}