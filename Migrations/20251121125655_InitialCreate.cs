using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Name", "Price", "Specifications", "Stock" },
                values: new object[] { 1, "Apple", "iPhone 15 Pro Max với chip A17 Pro mạnh mẽ", "/images/iphone15.jpg", "iPhone 15 Pro Max", 29990000m, "6.7 inch, 256GB, Camera 48MP", 50 });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Name", "Price", "Specifications", "Stock" },
                values: new object[] { 2, "Samsung", "Galaxy S24 Ultra với S Pen tích hợp", "/images/s24ultra.jpg", "Samsung Galaxy S24 Ultra", 26990000m, "6.8 inch, 256GB, Camera 200MP", 40 });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "Name", "Price", "Specifications", "Stock" },
                values: new object[] { 3, "Xiaomi", "Xiaomi 14 Pro camera Leica chuyên nghiệp", "/images/xiaomi14.jpg", "Xiaomi 14 Pro", 18990000m, "6.73 inch, 256GB, Camera 50MP", 60 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
