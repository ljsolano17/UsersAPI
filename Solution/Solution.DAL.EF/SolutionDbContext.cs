using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.EF
{
    public partial class SolutionDbContext : DbContext
    {
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FF74EE521");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");
                entity.Property(e => e.RegistrationDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
