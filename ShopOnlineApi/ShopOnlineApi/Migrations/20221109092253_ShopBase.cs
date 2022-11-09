using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopOnlineApi.Migrations
{
    public partial class ShopBase : Migration
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
                    add_data = table.Column<DateOnly>(type: "date", nullable: true),
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
                    order_date = table.Column<DateOnly>(type: "date", nullable: true),
                    price = table.Column<int>(type: "integer", nullable: true),
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
                    { 1, new DateOnly(2018, 9, 4), false, "Books" },
                    { 2, new DateOnly(2021, 10, 5), false, "Newspappers" },
                    { 3, new DateOnly(2022, 8, 4), false, "Audibooks" },
                    { 4, new DateOnly(2020, 7, 15), false, "Toys" },
                    { 5, new DateOnly(2022, 12, 6), true, "Cd's" },
                    { 6, new DateOnly(2020, 12, 30), false, "Games" },
                    { 7, new DateOnly(2022, 10, 6), true, "Others" }
                });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "users",
                columns: new[] { "id", "name", "register_date" },
                values: new object[,]
                {
                    { 1, "Robert Lewandowski", new DateOnly(2022, 1, 6) },
                    { 2, "Paweł Dawidowicz", new DateOnly(2022, 1, 31) },
                    { 3, "Natalia Miłosz", new DateOnly(2022, 2, 5) },
                    { 4, "Kate Ramirez", new DateOnly(2022, 11, 4) },
                    { 5, "Steve Gerrard", new DateOnly(2022, 5, 1) },
                    { 6, "Tommy Varcetti", new DateOnly(2022, 5, 4) },
                    { 7, "Niko Kovac", new DateOnly(2022, 4, 7) },
                    { 8, "Sergio Roberto", new DateOnly(2020, 7, 6) },
                    { 9, "Fernando Romani", new DateOnly(2021, 12, 6) },
                    { 10, "Petr Czech", new DateOnly(2021, 12, 5) }
                });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "adress",
                columns: new[] { "user_id", "city", "country", "house_number", "id", "street" },
                values: new object[,]
                {
                    { 1, "Lublin", "Poland", 14, 1, "Puławska" },
                    { 2, "Kraków", "Poland", 12, 2, "Zielona" },
                    { 3, "Gdańsk", "Poland", 19, 3, "Lipowa" },
                    { 4, "Gdynia", "Poland", 95, 4, "Sosnowa" },
                    { 5, "Liverpool", "United Kingdom", 44, 5, "Sunny Street" },
                    { 6, "Saloniki", "Greece", 66, 6, "Athens Street" },
                    { 7, "Pirovac", "Croatia", 41, 7, "Biograd Street" },
                    { 8, "Barcelona", "Spain", 59, 8, "Espanol Street" },
                    { 9, "Rome", "Italy", 77, 9, "Blue Street" },
                    { 10, "Prague", "Czech Republic", 94, 10, "Zatecky Street" }
                });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "contact",
                columns: new[] { "user_id", "email_adress", "id", "phone_number" },
                values: new object[,]
                {
                    { 1, "robercik1234@xd.com", 1, "+48 858 495 321" },
                    { 2, "pablo@xd.com", 2, "+48 842 412 123" },
                    { 3, "natalka33@xp.com", 3, "+48 555 491 978" },
                    { 4, "kasia_95@vista.com", 4, "+48 123 412 777" },
                    { 5, "brad555@ad.com", 5, "+55 495 455 890" },
                    { 6, "paula@cx.com", 6, "+44 855 546 999" },
                    { 7, "kathrina@kp.com", 7, "+32 859 123 001" },
                    { 8, "anna@qr.com", 8, "+34 787 562 123" },
                    { 9, "peter_sql@gr.com", 9, "+31 898 495 345" },
                    { 10, "milan_api@gd.com", 10, "+22 838 495 312" }
                });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "product",
                columns: new[] { "id", "category_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "Harry Potter: Globet of Fire" },
                    { 2, 1, "Dr.No" },
                    { 3, 2, "Easy English" },
                    { 4, 2, "New York Times" },
                    { 5, 2, "Automagazine" },
                    { 6, 2, "Football" },
                    { 7, 3, "Witcher I" },
                    { 8, 3, "Golden Eye" },
                    { 9, 4, "Monopoly" },
                    { 10, 4, "Rebel" },
                    { 11, 4, "Uno" },
                    { 12, 4, "Vtech cars" },
                    { 13, 4, "Smily Play house" },
                    { 14, 4, "Doll house" },
                    { 15, 6, "Need for speed: Most Wanted" },
                    { 16, 6, "Fifa 21" },
                    { 17, 5, "Doll house" }
                });

            migrationBuilder.InsertData(
                schema: "newshop",
                table: "orders",
                columns: new[] { "id", "order_date", "price", "product_id", "user_id" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 3, 4), 14, 1, 1 },
                    { 2, new DateOnly(2022, 4, 4), 111, 2, 2 },
                    { 3, new DateOnly(2022, 5, 6), 40, 3, 2 },
                    { 4, new DateOnly(2022, 6, 6), 12, 4, 2 },
                    { 5, new DateOnly(2022, 6, 30), 56, 5, 3 },
                    { 6, new DateOnly(2022, 7, 12), 12, 6, 6 },
                    { 7, new DateOnly(2022, 7, 18), 44, 7, 9 },
                    { 8, new DateOnly(2022, 8, 31), 95, 8, 10 },
                    { 9, new DateOnly(2022, 9, 9), 12, 9, 4 },
                    { 10, new DateOnly(2022, 10, 11), 50, 10, 4 },
                    { 11, new DateOnly(2022, 10, 15), 70, 11, 6 },
                    { 12, new DateOnly(2022, 10, 30), 50, 10, 9 },
                    { 13, new DateOnly(2022, 11, 3), 95, 8, 8 },
                    { 14, new DateOnly(2022, 11, 10), 95, 8, 7 }
                });

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
