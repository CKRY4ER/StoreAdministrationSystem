using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreAdministrationSystem.DataAccess.PostgresSql.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    total_price = table.Column<decimal>(type: "numeric", nullable: false),
                    order_status = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "product_categories",
                columns: table => new
                {
                    product_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    create_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_categories", x => x.product_category_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    login = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    is_admin = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    product_picture_url = table.Column<string>(type: "text", nullable: false),
                    parameters = table.Column<string>(type: "text", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    create_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_product_categories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "product_categories",
                        principalColumn: "product_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_documents",
                columns: table => new
                {
                    document_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_documents", x => new { x.user_id, x.document_id });
                    table.ForeignKey(
                        name: "FK_user_documents_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_positions",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    position_price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_positions", x => new { x.order_id, x.ProductId });
                    table.ForeignKey(
                        name: "FK_order_positions_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_positions_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_schopping_cart_positions",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_count = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_schopping_cart_positions", x => new { x.product_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_user_schopping_cart_positions_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_schopping_cart_positions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_positions_ProductId",
                table: "order_positions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductCategoryId",
                table: "products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_user_schopping_cart_positions_user_id",
                table: "user_schopping_cart_positions",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_positions");

            migrationBuilder.DropTable(
                name: "user_documents");

            migrationBuilder.DropTable(
                name: "user_schopping_cart_positions");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "product_categories");
        }
    }
}
