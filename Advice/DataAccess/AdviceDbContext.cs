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
                entity.HasKey(e => e.ID)
                     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                entity.Property(e => e.DEPT_NAME)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.DEPT_ACCESS)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    new
                    {
                        ID = 1,
                        DEPT_NAME = "Fun Zone",
                        DEPT_ACCESS = 9001
                    },
                    new
                    {
                        ID = 2,
                        DEPT_NAME = "Stranger Danger",
                        DEPT_ACCESS = 0
                    });
            });


            /* Accounts */
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
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
                    .HasForeignKey(e => e.DEPT_ID);


                entity.HasData(
                    new
                    {
                        ID = 1,
                        FNAME = "Nick",
                        LNAME = "Furgerson",
                        PASSWORD = "BLESSEDONE",
                        ACCESS_LEVEL = 17,
                        EMAIL = "nickfurgerson@email.com",
                        PHONE = "1(138)789-2123",
                        USERNAME = "soccerboy",
                        DEPT_ID = 1,
                    },
                    new
                    {
                        ID = 2,
                        FNAME = "Jay",
                        LNAME = "Lance",
                        PASSWORD = "firedup",
                        ACCESS_LEVEL = 1,
                        EMAIL = "jaylance@email.com",
                        PHONE = "765-5432",
                        USERNAME = "rayrance",
                        DEPT_ID = 2,
                    });
            });


            modelBuilder.Entity<Conversations>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                entity.Property(e => e.ACCOUNT_ID)
                    .IsRequired();
                entity.Property(e => e.CONVERSATION_TYPE)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.ACCESS_LEVEL)
                    .IsRequired();

                entity.HasOne(e => e.Accounts)
                    .WithMany(e => e.Conversations)
                    .HasForeignKey(e => e.ACCOUNT_ID);


                entity.HasData(
                    new
                    {
                        ID = 1,
                        ACCOUNT_ID = 1,
                        CONVERSATION_TYPE = 1,
                        ACCESS_LEVEL = 10,
                    },
                    new
                    {
                        ID = 2,
                        ACCOUNT_ID = 1,
                        CONVERSATION_TYPE = 2,
                        ACCESS_LEVEL = 5,
                    },
                    new
                    {
                        ID = 3,
                        ACCOUNT_ID = 2,
                        CONVERSATION_TYPE = 3,
                        ACCESS_LEVEL = 3,
                    });

            });


            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.ID);
                //.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                entity.Property(e => e.CONVERSATION_ID);
                entity.Property(e => e.DEPT_ID);
                entity.Property(e => e.ACCOUNT_ID);
                entity.Property(e => e.DATE_MADE);
                entity.Property(e => e.MESSAGE);
                entity.Property(e => e.MESSAGE_TYPE);
                entity.Property(e => e.TYPE);
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

                entity.HasData(
                    new
                    {
                        ID = 1,
                        CONVERSATION_ID = 1,
                        DEPT_ID = 1,
                        ACCOUNT_ID = 1,
                        DATE_MADE = DateTime.Now,
                        ACCESS_LEVEL = 10,
                        MESSAGE = new byte[] { 0, 1, 2 },
                        MESSAGE_TYPE = ".txt",
                        FILE_LOCATION = "C:\\Users\\JPOje\\OneDrive\\Documents\\CODE\\PROJECTS\\Advice App\\Notes",
                        TYPE = "NOTE",
                        KEYWORDS = "BLESSINGS",
                        UPVOTES = 100,
                        VIEWS = 117,
                        READ_ACCESS = 99,
                        WRITE_ACCESS = 4
                    },
                    new
                    {
                        ID = 2,
                        CONVERSATION_ID = 2,
                        DEPT_ID = 2,
                        ACCOUNT_ID = 2,
                        DATE_MADE = DateTime.Now,
                        ACCESS_LEVEL = 10,
                        MESSAGE = new byte[] { 1, 2, 3 },
                        MESSAGE_TYPE = ".png",
                        FILE_LOCATION = "C:\\Users\\JPOje\\OneDrive\\Documents\\CODE\\PROJECTS\\Advice App\\Notes",
                        TYPE = "QUESTION",
                        KEYWORDS = "funny",
                        UPVOTES = 56,
                        VIEWS = 70,
                        READ_ACCESS = 9,
                        WRITE_ACCESS = 5
                    },
                    new
                    {
                        ID = 3,
                        CONVERSATION_ID = 2,
                        DEPT_ID = 2,
                        ACCOUNT_ID = 2,
                        DATE_MADE = DateTime.Now,
                        ACCESS_LEVEL = 10,
                        MESSAGE = new byte[] { 2, 3, 4 },
                        MESSAGE_TYPE = ".png",
                        FILE_LOCATION = "C:\\Users\\JPOje\\OneDrive\\Documents\\CODE\\PROJECTS\\Advice App\\Notes",
                        TYPE = "ANSWER",
                        KEYWORDS = "funny",
                        UPVOTES = 7,
                        VIEWS = 12,
                        READ_ACCESS = 9,
                        WRITE_ACCESS = 10
                    });

            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
