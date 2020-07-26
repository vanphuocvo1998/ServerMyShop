using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServerMyShop.Models
{
    public partial class BookShopContext : DbContext
    {
        public BookShopContext()
        {
        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Billdetails> Billdetails { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Booktypes> Booktypes { get; set; }
        public virtual DbSet<Composed> Composed { get; set; }
        public virtual DbSet<Guess> Guess { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesUsertype> RolesUsertype { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Usertypes> Usertypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UI72F66\\PHUOCVO;Database=BookShop;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Billdetails>(entity =>
            {
                entity.HasKey(e => new { e.Bill, e.Book })
                    .HasName("PK__Billdeta__07473C1740DEE081");

                entity.HasOne(d => d.BillNavigation)
                    .WithMany(p => p.Billdetails)
                    .HasForeignKey(d => d.Bill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Billdetail__Bill__7F2BE32F");

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.Billdetails)
                    .HasForeignKey(d => d.Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Billdetail__Book__00200768");
            });

            modelBuilder.Entity<Bills>(entity =>
            {
                entity.Property(e => e.Deliveryplace).HasMaxLength(255);

                entity.Property(e => e.Deliverytime).HasMaxLength(255);

                entity.Property(e => e.Gmail).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('false')");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bills__UserId__797309D9");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Deleted)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.NameBook).HasMaxLength(255);

                entity.Property(e => e.Quantity).HasDefaultValueSql("((5))");

                entity.Property(e => e.Sale).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('true')");

                entity.HasOne(d => d.BooktypeNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Booktype)
                    .HasConstraintName("FK__Books__Booktype__5FB337D6");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Provider)
                    .HasConstraintName("FK__Books__Provider__60A75C0F");

                entity.HasOne(d => d.PublisherNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Publisher)
                    .HasConstraintName("FK__Books__Publisher__619B8048");
            });

            modelBuilder.Entity<Booktypes>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Composed>(entity =>
            {
                entity.HasKey(e => new { e.Book, e.Author });
            });

            modelBuilder.Entity<Guess>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Gmail).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);
            });

            modelBuilder.Entity<Providers>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Content).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RolesUsertype>(entity =>
            {
                entity.HasKey(e => new { e.Role, e.Usertype })
                    .HasName("PK__RolesUse__29CB59AE063F79DA");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.RolesUsertype)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RolesUsert__Role__72C60C4A");

                entity.HasOne(d => d.UsertypeNavigation)
                    .WithMany(p => p.RolesUsertype)
                    .HasForeignKey(d => d.Usertype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RolesUser__Usert__73BA3083");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Gmail).HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.HasOne(d => d.UsertypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Usertype)
                    .HasConstraintName("FK__Users__Usertype__76969D2E");
            });

            modelBuilder.Entity<Usertypes>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
