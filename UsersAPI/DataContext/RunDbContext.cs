namespace UsersAPI.DataContext
{
    public class RunDbContext : DbContext
    {
        public RunDbContext(DbContextOptions<RunDbContext> options) : base(options) { }

        public DbSet<BackupResults> BackupResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
              .HasCharSet("utf8");

            modelBuilder.Entity<BackupResults>(e =>
            {
                e.ToTable("BackupResults");
                //e.Property(x => x.Id).HasColumnType("integer(4)").HasConversion<int>();
                e.Property(x => x.Id).HasColumnType("bigint(20)").HasConversion<long>();

                e.Property(x => x.Name).HasColumnType("varchar(50)").HasConversion<string>();
                //e.Property(x => x.Region).HasColumnType("varchar(50)").HasConversion<string>();
                e.Property(x => x.City).HasColumnType("varchar(50)").HasConversion<string>();
                e.Property(x => x.Company).HasColumnType("varchar(50)").HasConversion<string>();

                e.Property(x => x.Age).HasColumnType("int(3)").HasConversion<int>();
                e.Property(x => x.Gender).HasMaxLength(1).IsFixedLength(); //.HasConversion<char>();

                e.Property(x => x.Result).HasColumnType("decimal(10,2)").HasConversion<decimal>();
                e.Property(x => x.Veloresult).HasColumnType("decimal(10,2)").HasConversion<decimal>();

                e.Property(x => x.CreatedAt).HasColumnType("datetime").HasConversion<DateTime>();
                e.Property(x => x.UpdatedAt).HasColumnType("datetime").HasConversion<DateTime>();
            });
        }
    }
}
