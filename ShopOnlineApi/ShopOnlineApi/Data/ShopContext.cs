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
            modelBuilder.Entity<Adress>()
                .HasData(new Adress { Id = 1, City = "Lublin", Country = "Poland", Street = "Puławska", HouseNumber = 14, UserId = 1 });
            modelBuilder.Entity<User>()
                .HasData(new User { Id = 1, Name = "James Bond", RegisterDate = DateOnly.ParseExact("15/06/2015", "dd/MM/yyyy") });
            modelBuilder.Entity<Category>()
                .HasData(new Category { Id = 1, Name = "Electronics", AddData = null, Empty = false });
            modelBuilder.Entity<Category>()
                .HasData(new Category { Id = 2, Name = "Books", AddData = null, Empty = true });
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


