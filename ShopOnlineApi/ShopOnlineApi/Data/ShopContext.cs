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
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("ShopContext"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>().HasData(
                new { Id = 1, City = "Lublin", Country = "Poland", Street = "Puławska", HouseNumber = 14, UserId = 1 },
                new { Id = 2, City = "Kraków", Country = "Poland", Street = "Zielona", HouseNumber = 12, UserId = 2 },
                new { Id = 3, City = "Gdańsk", Country = "Poland", Street = "Lipowa", HouseNumber = 19, UserId = 3 },
                new { Id = 4, City = "Gdynia", Country = "Poland", Street = "Sosnowa", HouseNumber = 95, UserId = 4 },
                new { Id = 5, City = "Liverpool", Country = "United Kingdom", Street = "Sunny Street", HouseNumber = 44, UserId = 5 },
                new { Id = 6, City = "Saloniki", Country = "Greece", Street = "Athens Street", HouseNumber = 66, UserId = 6 },
                new { Id = 7, City = "Pirovac", Country = "Croatia", Street = "Biograd Street", HouseNumber = 41, UserId = 7 },
                new { Id = 8, City = "Barcelona", Country = "Spain", Street = "Espanol Street", HouseNumber = 59, UserId = 8 },
                new { Id = 9, City = "Rome", Country = "Italy", Street = "Blue Street", HouseNumber = 77, UserId = 9 },
                new { Id = 10, City = "Prague", Country = "Czech Republic", Street = "Zatecky Street", HouseNumber = 94, UserId = 10 }
                );
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Books", AddData = DateOnly.ParseExact("04/09/2018", "dd/MM/yyyy"), Empty = false },
                new { Id = 2, Name = "Newspappers", AddData = DateOnly.ParseExact("05/10/2021", "dd/MM/yyyy"), Empty = false },
                new { Id = 3, Name = "Audibooks", AddData = DateOnly.ParseExact("04/08/2022", "dd/MM/yyyy"), Empty = false },
                new { Id = 4, Name = "Toys", AddData = DateOnly.ParseExact("15/07/2020", "dd/MM/yyyy"), Empty = false },
                new { Id = 5, Name = "Cd's", AddData = DateOnly.ParseExact("06/12/2022", "dd/MM/yyyy"), Empty = true },
                new { Id = 6, Name = "Games", AddData = DateOnly.ParseExact("30/12/2020", "dd/MM/yyyy"), Empty = false },
                new { Id = 7, Name = "Others", AddData = DateOnly.ParseExact("06/10/2022", "dd/MM/yyyy"), Empty = true }
                );
            //modelBuilder.Entity<User>()
            //    .HasData(new User { Id = 1, Name = "James Bond", RegisterDate = DateOnly.ParseExact("15/06/2015", "dd/MM/yyyy") });
            modelBuilder.Entity<Contact>().HasData(
                new { Id = 1, PhoneNumber = "+48 858 495 321", EmailAdress = "robercik1234@xd.com", UserId = 1 },
                new { Id = 2, PhoneNumber = "+48 842 412 123", EmailAdress = "pablo@xd.com", UserId = 2 },
                new { Id = 3, PhoneNumber = "+48 555 491 978", EmailAdress = "natalka33@xp.com", UserId = 3 },
                new { Id = 4, PhoneNumber = "+48 123 412 777", EmailAdress = "kasia_95@vista.com", UserId = 4 },
                new { Id = 5, PhoneNumber = "+55 495 455 890", EmailAdress = "brad555@ad.com", UserId = 5 },
                new { Id = 6, PhoneNumber = "+44 855 546 999", EmailAdress = "paula@cx.com", UserId = 6 },
                new { Id = 7, PhoneNumber = "+32 859 123 001", EmailAdress = "kathrina@kp.com", UserId = 7 },
                new { Id = 8, PhoneNumber = "+34 787 562 123", EmailAdress = "anna@qr.com", UserId = 8 },
                new { Id = 9, PhoneNumber = "+31 898 495 345", EmailAdress = "peter_sql@gr.com", UserId = 9 },
                new { Id = 10, PhoneNumber = "+22 838 495 312", EmailAdress = "milan_api@gd.com", UserId = 10 }
                );

            modelBuilder.Entity<Order>().HasData(
                new { Id = 1, OrderDate = DateOnly.ParseExact("04/03/2022", "dd/MM/yyyy"), Price = 14, UserId = 1, ProductId = 1 },
                new { Id = 2, OrderDate = DateOnly.ParseExact("04/04/2022", "dd/MM/yyyy"), Price = 111, UserId = 2, ProductId = 2 },
                new { Id = 3, OrderDate = DateOnly.ParseExact("06/05/2022", "dd/MM/yyyy"), Price = 40, UserId = 2, ProductId = 3 },
                new { Id = 4, OrderDate = DateOnly.ParseExact("06/06/2022", "dd/MM/yyyy"), Price = 12, UserId = 2, ProductId = 4 },
                new { Id = 5, OrderDate = DateOnly.ParseExact("30/06/2022", "dd/MM/yyyy"), Price = 56, UserId = 3, ProductId = 5 },
                new { Id = 6, OrderDate = DateOnly.ParseExact("12/07/2022", "dd/MM/yyyy"), Price = 12, UserId = 6, ProductId = 6 },
                new { Id = 7, OrderDate = DateOnly.ParseExact("18/07/2022", "dd/MM/yyyy"), Price = 44, UserId = 9, ProductId = 7 },
                new { Id = 8, OrderDate = DateOnly.ParseExact("31/08/2022", "dd/MM/yyyy"), Price = 95, UserId = 10, ProductId = 8 },
                new { Id = 9, OrderDate = DateOnly.ParseExact("09/09/2022", "dd/MM/yyyy"), Price = 12, UserId = 4, ProductId = 9 },
                new { Id = 10, OrderDate = DateOnly.ParseExact("11/10/2022", "dd/MM/yyyy"), Price = 50, UserId = 4, ProductId = 10 },
                new { Id = 11, OrderDate = DateOnly.ParseExact("15/10/2022", "dd/MM/yyyy"), Price = 70, UserId = 6, ProductId = 11 },
                new { Id = 12, OrderDate = DateOnly.ParseExact("30/10/2022", "dd/MM/yyyy"), Price = 50, UserId = 9, ProductId = 10 },
                new { Id = 13, OrderDate = DateOnly.ParseExact("03/11/2022", "dd/MM/yyyy"), Price = 95, UserId = 8, ProductId = 8 },
                new { Id = 14, OrderDate = DateOnly.ParseExact("10/11/2022", "dd/MM/yyyy"), Price = 95, UserId = 7, ProductId = 8 }
                );

            modelBuilder.Entity<Product>().HasData(
                new { Id = 1, Name = "Harry Potter: Globet of Fire", CategoryId = 1 },
                new { Id = 2, Name = "Dr.No", CategoryId = 1 },
                new { Id = 3, Name = "Easy English", CategoryId = 2 },
                new { Id = 4, Name = "New York Times", CategoryId = 2 },
                new { Id = 5, Name = "Automagazine", CategoryId = 2 },
                new { Id = 6, Name = "Football", CategoryId = 2 },
                new { Id = 7, Name = "Witcher I", CategoryId = 3 },
                new { Id = 8, Name = "Golden Eye", CategoryId = 3 },
                new { Id = 9, Name = "Monopoly", CategoryId = 4 },
                new { Id = 10, Name = "Rebel", CategoryId = 4 },
                new { Id = 11, Name = "Uno", CategoryId = 4 },
                new { Id = 12, Name = "Vtech cars", CategoryId = 4 },
                new { Id = 13, Name = "Smily Play house", CategoryId = 4 },
                new { Id = 14, Name = "Doll house", CategoryId = 4 },
                new { Id = 15, Name = "Need for speed: Most Wanted", CategoryId = 6 },
                new { Id = 16, Name = "Fifa 21", CategoryId = 6 },
                new { Id = 17, Name = "Doll house", CategoryId = 5 }
                );

            modelBuilder.Entity<User>().HasData(
                new { Id = 1, Name = "Robert Lewandowski", RegisterDate = DateOnly.ParseExact("06/01/2022", "dd/MM/yyyy") },
                new { Id = 2, Name = "Paweł Dawidowicz", RegisterDate = DateOnly.ParseExact("31/01/2022", "dd/MM/yyyy") },
                new { Id = 3, Name = "Natalia Miłosz", RegisterDate = DateOnly.ParseExact("05/02/2022", "dd/MM/yyyy") },
                new { Id = 4, Name = "Kate Ramirez", RegisterDate = DateOnly.ParseExact("04/11/2022", "dd/MM/yyyy") },
                new { Id = 5, Name = "Steve Gerrard", RegisterDate = DateOnly.ParseExact("01/05/2022", "dd/MM/yyyy") },
                new { Id = 6, Name = "Tommy Varcetti", RegisterDate = DateOnly.ParseExact("04/05/2022", "dd/MM/yyyy") },
                new { Id = 7, Name = "Niko Kovac", RegisterDate = DateOnly.ParseExact("07/04/2022", "dd/MM/yyyy") },
                new { Id = 8, Name = "Sergio Roberto", RegisterDate = DateOnly.ParseExact("06/07/2020", "dd/MM/yyyy") },
                new { Id = 9, Name = "Fernando Romani", RegisterDate = DateOnly.ParseExact("06/12/2021", "dd/MM/yyyy") },
                new { Id = 10, Name = "Petr Czech", RegisterDate = DateOnly.ParseExact("05/12/2021", "dd/MM/yyyy") }
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


