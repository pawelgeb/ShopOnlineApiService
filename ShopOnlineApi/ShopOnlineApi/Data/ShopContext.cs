using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Data
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {

        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Adress> Adresses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=mysecretpassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>().HasData(
                new {Id = 1, City = "Lublin", Country = "Poland", Street ="Puławska", HouseNumber = 14, UserId = 1 },
                new {Id = 2, City = "Kraków", Country = "Poland", Street ="Zielona", HouseNumber = 12, UserId = 2},
                new {Id = 3, City = "Gdańsk", Country = "Poland", Street ="Lipowa", HouseNumber = 19, UserId = 3},
                new {Id = 4, City = "Gdynia", Country = "Poland", Street ="Sosnowa", HouseNumber = 95, UserId = 4},
                new {Id = 5, City = "Liverpool", Country = "United Kingdom", Street = "Sunny Street", HouseNumber = 44, UserId = 5},
                new {Id = 6, City = "Saloniki", Country = "Greece", Street = "Athens Street", HouseNumber = 66, UserId = 6},
                new {Id = 7, City = "Pirovac", Country = "Croatia", Street = "Biograd Street", HouseNumber = 41, UserId = 7},
                new {Id = 8, City = "Barcelona", Country = "Spain", Street = "Espanol Street", HouseNumber = 59, UserId = 8},
                new {Id = 9, City = "Rome", Country = "Italy", Street = "Blue Street", HouseNumber = 77, UserId = 9},
                new {Id = 10, City ="Prague", Country = "Czech Republic", Street = "Zatecky Street", HouseNumber = 94, UserId = 10}
                );
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Books", AddData = 2018-09-04, Empty = false},
                new { Id = 2, Name = "Newspappers", AddData = 2021 - 10 - 05, Empty = false },
                new { Id = 3, Name = "Audibooks", AddData = 2022 - 08 - 04, Empty = false },
                new { Id = 4, Name = "Toys", AddData = 2020 - 07 - 15, Empty = false },
                new { Id = 5, Name = "Cd's", AddData = 2022 -12 - 06, Empty = false },
                new { Id = 6, Name = "Games", AddData = 2020 - 12 - 30, Empty = false },
                new { Id = 7, Name = "Others", AddData = 2022 - 10 - 06, Empty = false }
                );
            //modelBuilder.Entity<User>()
            //    .HasData(new User { Id = 1, Name = "James Bond", RegisterDate = DateOnly.ParseExact("15/06/2015", "dd/MM/yyyy") });
            modelBuilder.Entity<Contact>().HasData(
                new {Id = 1, PhoneNumber = "+48 858 495 321", EmailAdress = "robercik1234@xd.com", UserId = 1 },
                new { Id = 2, PhoneNumber = "+48 842 412 123", EmailAdress = "pablo@xd.com", UserId = 2 },
                new { Id = 3, PhoneNumber = "+48 555 491 978", EmailAdress = "natalka33@xp.com", UserId = 3 },
                new { Id = 4, PhoneNumber = "+48 123 412 777", EmailAdress = "kasia_95@vista.com", UserId = 4 },
                new { Id = 5, PhoneNumber = "+55 495 455 890", EmailAdress = "brad555@ad.com", UserId = 5 },
                new { Id = 6, PhoneNumber = "+44 855 546 999", EmailAdress = "paula@cx.com", UserId = 6 },
                new { Id = 7, PhoneNumber = "+32 859 123 001", EmailAdress = "kathrina@kp.com", UserId = 7 },
                new { Id = 8, PhoneNumber = "+34 787 562 123", EmailAdress = "robercik1234@qr.com", UserId = 8 },
                new { Id = 9, PhoneNumber = "+31 898 495 345", EmailAdress = "robercik1234@gr.com", UserId = 9 },
                new { Id = 10, PhoneNumber = "+22 838 495 312", EmailAdress = "robercik1234@gd.com", UserId = 10 }
                );

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("adress_pkey");

                entity.ToTable("adress", "newshop");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.HouseNumber).HasColumnName("house_number");

                entity.Property(e => e.Id).HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Street).HasColumnName("street");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Adress)
                    .HasForeignKey<Adress>(d => d.UserId)
                    .HasConstraintName("adress_user_id_fkey");
            });

            modelBuilder.Entity<Category>(entity =>

            {
                entity.ToTable("category", "newshop");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AddData).HasColumnName("add_data");

                entity.Property(e => e.Empty).HasColumnName("empty");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("contact_pkey");

                entity.ToTable("contact", "newshop");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.EmailAdress).HasColumnName("email_adress");

                entity.Property(e => e.Id).HasColumnName("id")
                .ValueGeneratedOnAdd();

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Contact)
                    .HasForeignKey<Contact>(d => d.UserId)
                    .HasConstraintName("contact_user_id_fkey");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("orders", "newshop");

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("orders_product_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("orders_user_id_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "newshop");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_category_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "newshop");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.RegisterDate).HasColumnName("register_date");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


