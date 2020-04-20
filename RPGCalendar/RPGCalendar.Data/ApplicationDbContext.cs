namespace RPGCalendar.Data
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApplicationDbContext : DbContext
    {
#nullable disable
        public DbSet<User> Users { get; set; }
        public DbSet<GameNote> GameNotes { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }
        public DbSet<GameItem> GameItems { get; set; }
        public DbSet<GameNotification> GameNotifications { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<GameCalendar> GameCalendars { get; set; }
        private IHttpContextAccessor HttpContextAccessor { get; set; }
#nullable enable

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext) { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    _ = modelBuilder?.Entity<UserGroup>().HasKey(ug => new { ug.UserId, ug.GroupId });

        //    modelBuilder?.Entity<UserGroup>().HasOne(ug => ug.User).WithMany(u => u.UserGroups).HasForeignKey(ug => ug.UserId);
        //    modelBuilder?.Entity<UserGroup>().HasOne(ug => ug.Group).WithMany(u => u.UserGroups).HasForeignKey(ug => ug.GroupId);
        }

        public override int SaveChanges()
        {
            AddFingerPrinting();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddFingerPrinting();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddFingerPrinting()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            var added = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

            foreach (EntityEntry entry in added)
            {
                if (entry.Entity is FingerPrintEntityBase fingerPrintEntry)
                {
                    fingerPrintEntry.CreatedOn = DateTime.UtcNow;
                    fingerPrintEntry.CreatedBy = string.Empty; //HttpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value ?? string.Empty;
                    fingerPrintEntry.ModifiedOn = DateTime.UtcNow;
                    fingerPrintEntry.ModifiedBy = string.Empty; // HttpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value ?? string.Empty;
                }
            }

            foreach (EntityEntry entry in modified)
            {
                if (entry.Entity is FingerPrintEntityBase fingerPrintEntry)
                {
                    ResetValue(entry, nameof(FingerPrintEntityBase.CreatedOn));
                    ResetValue(entry, nameof(FingerPrintEntityBase.CreatedBy));

                    fingerPrintEntry.ModifiedOn = DateTime.UtcNow;
                    fingerPrintEntry.ModifiedBy = string.Empty; // HttpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value ?? string.Empty;
                }
            }
        }

        private static void ResetValue(EntityEntry entry, string propertyName)
        {
            PropertyEntry property = entry.Property(propertyName);
            property.CurrentValue = property.OriginalValue;
        }
    }
}