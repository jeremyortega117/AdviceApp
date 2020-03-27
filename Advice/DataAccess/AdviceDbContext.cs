using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    /// <summary>
    /// Created a partial class to allow for
    /// * partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    /// This was in another DB example and placed in here.
    /// </summary>
    public partial class AdviceDbContext : DbContext
    {
        public AdviceDbContext(DbContextOptions<AdviceDbContext> options) : base(options)
        {

        }
        public AdviceDbContext() { }

        /// <summary>
        /// Created DBSet's to create tables based on entities/models.
        /// </summary>
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Username);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);
                /* Created these entity elements for a foreign key/Primary
                 * Key relationship.  
                 * Example: 
                 *      entity.HasMany => // Accounts has many questions
                 *      .WithOne => // the questions has one Account
                 */
                entity.HasMany(e => e.Questions)
                    .WithOne(e => e.Accounts)
                    .HasForeignKey(e => e.Account_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasMany(e => e.Answers)
                    .WithOne(e => e.Accounts)
                    .HasForeignKey(e => e.Account_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                /* Create seed data */
                entity.HasData(new Accounts[]{
                    new Accounts()
                    {
                        ID = 1,
                        Email = "greg@mail.com",
                        Username = "gregory",
                        Password = "pass@word"
                    },
                    new Accounts()
                    {
                        ID = 2,
                        Email = "paul@mail.com",
                        Username = "paul",
                        Password = "pass@word1"
                    },
                    new Accounts()
                    {
                        ID = 3,
                        Email = "samantha@mail.com",
                        Username = "samantha",
                        Password = "pass@word2"
                    }
                });
            });
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Answers_)
                      .IsRequired();
                entity.Property(e => e.Question_ID)
                      .IsRequired()
                      .HasMaxLength(1000);
                entity.Property(e => e.Account_ID)
                      .IsRequired();
                entity.Property(e => e.Upvotes);
                entity.Property(e => e.Visited);
                entity.HasData(new Answers[]
                {
                    new Answers()
                    {
                        ID = 1,
                        Question_ID = 1,
                        Answers_ = "butter the outside of two pieces of bread and place a slice of cheese in the middle and cook on stove for 3 minutes on each side.",
                        Account_ID = 1
                    },
                    new Answers()
                    {
                        ID = 2,
                        Question_ID = 1,
                        Answers_ = "Place PB and Jelly in between two pieces of bread.",
                        Account_ID = 3,
                    }
                });
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Question);
                entity.Property(e => e.QuestionType);
                entity.Property(e => e.Account_ID);
                entity.Property(e => e.Upvotes);
                entity.Property(e => e.Visited);
                entity.HasMany(e => e.Answers)
                    .WithOne(e => e.Questions)
                    .HasForeignKey(e => e.Question_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasData(new Questions[] {
                    new Questions()
                    {
                        ID = 1,
                        Question = "How to make grilled cheese",
                        QuestionType = "cooking",
                        Account_ID = 1
                    },
                    new Questions()
                    {
                        ID = 2,
                        Question = "How to make PB&J",
                        QuestionType = "cooking",
                        Account_ID = 1
                    }
                });
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
