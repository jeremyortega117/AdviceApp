using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess
{
    /// <summary>
    /// Created a partial class to allow for
    /// * partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    /// This was in another DB example and placed in here.
    /// </summary>
    public partial class AdviceDbContext : DbContext
    {

        public AdviceDbContext() { }

        public AdviceDbContext(DbContextOptions<AdviceDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Created DBSet's to create tables based on entities/models.
        /// </summary>
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Conversations> Conversations { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            /* Departments */
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.DEPT_NAME)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.DEPT_ACCESS)
                    .IsRequired()
                    .HasMaxLength(100);
            });


            /* Accounts */
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.FNAME)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.LNAME)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.PASSWORD)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.ACCESS_LEVEL)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.EMAIL)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.PHONE)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.USERNAME)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.DEPT_ID)
                    .IsRequired();
                entity.HasOne(e => e.Departments)
                    .WithMany(e => e.Accounts)
                    .HasForeignKey(e => e.DEPT_ID)
                    .HasConstraintName("FK_Review_Department")
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CONVERSATION_ID);
                entity.Property(e => e.DEPT_ID);
                entity.Property(e => e.ACCOUNT_ID);
                entity.Property(e => e.DATE_MADE);
                entity.Property(e => e.MESSAGE);
                entity.Property(e => e.MESSAGE_TYPE);
                entity.Property(e => e.KEYWORDS);
                entity.Property(e => e.UPVOTES);
                entity.Property(e => e.VIEWS);
                entity.Property(e => e.READ_ACCESS);
                entity.Property(e => e.WRITE_ACCESS);
                entity.HasOne(e => e.Accounts)
                    .WithMany(e => e.Messages)
                    .HasForeignKey(e => e.ACCOUNT_ID) 
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Conversations)
                    .WithMany(e => e.Messages)
                    .HasForeignKey(e => e.CONVERSATION_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Departments)
                    .WithMany(e => e.Messages)
                    .HasForeignKey(e => e.DEPT_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<Conversations>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ACCOUNT_ID);
                entity.Property(e => e.CONVERSATION_TYPE);
                entity.Property(e => e.DEPT_ID);
                entity.Property(e => e.ACCESS_LEVEL);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
