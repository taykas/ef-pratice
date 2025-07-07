using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

public static class Connect
{
    public static async Task<ExempleDbContext> BdConnection()
    {
        var connBuilder = new SqlConnectionStringBuilder
        {
            DataSource = "localhost",
            InitialCatalog = "EXERCISE",
            IntegratedSecurity = true,
            TrustServerCertificate = true
        };

        var stringConnection = connBuilder.ToString();

        var optsBuilder = new DbContextOptionsBuilder();

        optsBuilder.UseSqlServer(stringConnection);

        var options = optsBuilder.Options;

        var db = new ExempleDbContext(options);

        await db.Database.EnsureCreatedAsync();

        return db;
    }
}

public class ExempleDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserData> UserData => Set<UserData>();

    public DbSet<Sale> Sale => Set<Sale>();
    public DbSet<ProductItem> ProductItem => Set<ProductItem>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<UserData>();

        model.Entity<Sale>()
            .HasOne(c => c.UserData)
            .WithMany(u => u.Sales)
            .HasForeignKey(c => c.UserDataId)
            .OnDelete(DeleteBehavior.Cascade);

        model.Entity<Sale>()
            .HasOne(c => c.ProductItem)
            .WithMany(u => u.Sales)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
            
    }
}