using Microsoft.EntityFrameworkCore;
using ScriptRunner.Core.Models;

namespace ScriptRunner.Data
{
    public class ContextDB : DbContext
    {
        #region Constructor
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }
        #endregion


        #region DbSets
        public DbSet<ConnectionProfile> TsyProfiles { get; set; }
        public DbSet<ExecutedScripts> TsyScripts { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ConnectionProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);
                entity.HasIndex(e => e.ConnectionName).IsUnique();
            });

            modelBuilder.Entity<ExecutedScripts>(entity =>
             {
                 entity.HasKey(e => e.ScriptId);
             });
        }
        #endregion


    }
}
