using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopOnlineApi.Migrations
{
    public partial class ShopDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "newshop");

            migrationBuilder.CreateTable(
                name: "category",
                schema: "newshop",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    add_data = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    empty = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "newshop",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    register_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "newshop",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "product_category_id_fkey",
                        column: x => x.category_id,
                        principalSchema: "newshop",
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adress",
                schema: "newshop",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    house_number = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("adress_pkey", x => x.user_id);
                    table.ForeignKey(
                        name: "adress_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "newshop",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                schema: "newshop",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    email_adress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("contact_pkey", x => x.user_id);
                    table.ForeignKey(
                        name: "contact_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "newshop",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "newshop",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    order_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    product_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "orders_product_id_fkey",
                        column: x => x.product_id,
                        principalSchema: "newshop",
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "orders_user_id_fkey",
                        column: x => x.user_id,
                        principalSchema: "newshop",
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "category",
                columns: new[] { "id", "add_data", "empty", "name" },
                values: new object[,]
                {
                    { 1, null, false, "Electronics" },
                    { 2, null, true, "Books" }
                });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "users",
                columns: new[] { "id", "name", "register_date" },
                values: new object[] { 1, "James Bond", new DateOnly(2015, 6, 15) });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "adress",
                columns: new[] { "user_id", "city", "country", "house_number", "id", "street" },
                values: new object[] { 1, "Lublin", "Poland", 14, 1, "Puławska" });

            migrationBuilder.CreateIndex(
                name: "IX_orders_product_id",
                schema: "newshop",
                table: "orders",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                schema: "newshop",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                schema: "newshop",
                table: "product",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adress",
                schema: "newshop");

            migrationBuilder.DropTable(
                name: "contact",
                schema: "newshop");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "newshop");

            migrationBuilder.DropTable(
                name: "product",
                schema: "newshop");

            migrationBuilder.DropTable(
                name: "users",
                schema: "newshop");

            migrationBuilder.DropTable(
                name: "category",
                schema: "newshop");
        }
    }
}
