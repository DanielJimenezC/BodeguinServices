using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bodeguin.Infraestructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    modified_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    url_image = table.Column<string>(maxLength: 2500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    modified_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    modified_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    ruc = table.Column<string>(maxLength: 11, nullable: false),
                    latitude = table.Column<float>(nullable: false),
                    longitude = table.Column<float>(nullable: false),
                    direction = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    modified_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    first_lastname = table.Column<string>(maxLength: 50, nullable: false),
                    second_lastname = table.Column<string>(maxLength: 50, nullable: false),
                    dni = table.Column<string>(maxLength: 100, nullable: false),
                    direction = table.Column<string>(maxLength: 200, nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(maxLength: 200, nullable: false),
                    is_admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    modified_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    url_image = table.Column<string>(maxLength: 2500, nullable: false),
                    category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    modified_at = table.Column<DateTime>(nullable: false),
                    payment_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vouchers_PaymentTypes_payment_id",
                        column: x => x.payment_id,
                        principalTable: "PaymentTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vouchers_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    is_active = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    modified_at = table.Column<DateTime>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    measure_unit = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Stores_store_id",
                        column: x => x.store_id,
                        principalTable: "Stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discount = table.Column<int>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    inventory_id = table.Column<int>(nullable: false),
                    voucher_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.id);
                    table.ForeignKey(
                        name: "FK_Details_Inventories_inventory_id",
                        column: x => x.inventory_id,
                        principalTable: "Inventories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Vouchers_voucher_id",
                        column: x => x.voucher_id,
                        principalTable: "Vouchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "create_at", "description", "is_active", "modified_at", "name", "url_image" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Verduras", true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Verduras", "https://www.saccosystem.com/public/imgCat2/big/100.jpg" },
                    { 2, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Carnes y Pollos", true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Carnes y Pollos", "https://images.jumpseller.com/store/eks-delivery/4918843/carnes-int.jpg" },
                    { 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Pescados y Mariscos", true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Pescados y Mariscos", "https://c6f2y5q5.rocketcdn.me/wp-content/uploads/2017/08/proveedores-de-pescado-y-marisco-1280x640.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "id", "create_at", "is_active", "modified_at", "name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Efectivo" },
                    { 2, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Tarjeta de Crédito/Débito" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "id", "create_at", "description", "direction", "is_active", "latitude", "longitude", "modified_at", "name", "ruc" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Bodega Familiar", "Av. Angamos 205", true, -12.113699f, -77.028984f, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Bodeguita Martinez", "20451798452" },
                    { 2, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Bodega Familiar", "Calle Lizardo Montero 299", true, -12.111534f, -77.02891f, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Don Pedrito", "10684751482" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "create_at", "direction", "dni", "email", "first_lastname", "is_active", "is_admin", "modified_at", "name", "password", "second_lastname" },
                values: new object[] { 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Calle Ciro Alegria Mz K Lote 20", "72183382", "danieljimenezcanales@gmail.com", "Jimenez", true, false, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Daniel", "g2Ix3bIy9j6NrGf7zJm1Mg==", "Canales" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category_id", "create_at", "description", "is_active", "modified_at", "name", "url_image" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Manzana", true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Manzana", "https://estaticos.miarevista.es/media/cache/1140x_thumb/uploads/images/article/5e53c4125bafe801dabfb62f/comer-semillas-manzana.jpg" },
                    { 2, 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Lechuga", true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Lechuga", "https://static3.abc.es/media/bienestar/2020/09/01/lechuga-k7y--1024x512@abc.jpg" },
                    { 3, 2, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Pollo", true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Pollo", "https://www.rebanando.com/cache/slideshow/31/72/02/e6/pollo1.jpg/2cb6823c975ee09b0d93e071c71c86d5.jpg" },
                    { 4, 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Camarones", true, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), "Camarones", "https://img.vixdata.io/pd/jpg-large/es/sites/default/files/imj/elgranchef/C/Camarones-florentinos-3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "id", "create_at", "is_active", "measure_unit", "modified_at", "price", "product_id", "quantity", "store_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), 2.5f, 1, 20, 1 },
                    { 2, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), 2.2f, 1, 18, 2 },
                    { 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), 1.8f, 2, 5, 1 },
                    { 4, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, 1, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), 1.5f, 2, 1, 2 },
                    { 5, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), 8.9f, 3, 12, 1 },
                    { 6, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), 14.2f, 4, 5, 1 },
                    { 7, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), true, 3, new DateTime(2020, 10, 25, 1, 13, 28, 201, DateTimeKind.Local).AddTicks(7396), 17.8f, 4, 12, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_inventory_id",
                table: "Details",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_Details_voucher_id",
                table: "Details",
                column: "voucher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_product_id",
                table: "Inventories",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_store_id",
                table: "Inventories",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_payment_id",
                table: "Vouchers",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_user_id",
                table: "Vouchers",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
