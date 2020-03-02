using Microsoft.EntityFrameworkCore;

namespace people.api.Domain
{
    public partial class TechTestContext : DbContext
    {
        public TechTestContext()
        {
        }

        public TechTestContext(DbContextOptions<TechTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PersonSkills> PersonSkills { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonSkills>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.SkillId });

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonSkills)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonSkills_People");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.PersonSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonSkills_Skills");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
