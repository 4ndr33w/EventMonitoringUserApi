namespace UsersAPI.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserProfile> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
              .HasCharSet("utf8");

            modelBuilder.Entity<UserProfile>(e =>
            {
                e.ToTable("UserProfile");
                e.Property(x => x.Id).HasColumnType("integer(4)").HasConversion<int>();
                e.Property(x => x.TelegramId).HasColumnType("bigint(20)").HasConversion<long>();

                e.Property(x => x.Name).HasColumnType("varchar(50)").HasConversion<string>();
                e.Property(x => x.Region).HasColumnType("varchar(50)").HasConversion<string>();
                e.Property(x => x.City).HasColumnType("varchar(50)").HasConversion<string>();
                e.Property(x => x.Company).HasColumnType("varchar(50)").HasConversion<string>();

                e.Property(x => x.Age).HasColumnType("int(3)").HasConversion<int>();
                e.Property(x => x.Gender).HasMaxLength(1).IsFixedLength(); //.HasConversion<char>();

                e.Property(x => x.TotalResult).HasColumnType("decimal(10,2)").HasConversion<decimal>();
                e.Property(x => x.LastAddedResult).HasColumnType("decimal(10,2)").HasConversion<decimal>();

                e.Property(x => x.CreatedAt).HasColumnType("datetime").HasConversion<DateTime>();
                e.Property(x => x.UpdatedAt).HasColumnType("datetime").HasConversion<DateTime>();
            });
        }
    }
}
