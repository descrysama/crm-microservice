using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace userMicroService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Percentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tax_amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Siret = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TvaNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WebsiteUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentmethodId = table.Column<int>(type: "int", nullable: false),
                    BillingAddressId = table.Column<int>(type: "int", nullable: false),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDisabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_PaymentMethod_PaymentmethodId",
                        column: x => x.PaymentmethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    LastModifiedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<int>(type: "int", nullable: false, defaultValue: 10),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    IsBanned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MobilePhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeactivated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequiredAuthorization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsBanned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvoiceProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    TaxPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalWithTax = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalWithTaxWithDiscount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceProduct_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SerialNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeactivated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedById = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_User_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuoteUuid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalWithTax = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalWithTaxWithDiscount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequiredAuthorization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quote_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quote_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quote_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quote_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quote_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quote_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceUuid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuoteId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalWithTax = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalWithTaxWithDiscount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TaxPercentage = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequiredAuthorization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_Quote_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[,]
                {
                    { 1, "AL", "Albania" },
                    { 2, "AD", "Andorra" },
                    { 3, "AM", "Armenia" },
                    { 4, "AT", "Austria" },
                    { 5, "AZ", "Azerbaijan" },
                    { 6, "BY", "Belarus" },
                    { 7, "BE", "Belgium" },
                    { 8, "BA", "Bosnia and Herzegovina" },
                    { 9, "BG", "Bulgaria" },
                    { 10, "HR", "Croatia" },
                    { 11, "CY", "Cyprus" },
                    { 12, "CZ", "Czech Republic" },
                    { 13, "DK", "Denmark" },
                    { 14, "EE", "Estonia" },
                    { 15, "FI", "Finland" },
                    { 16, "FR", "France" },
                    { 17, "GE", "Georgia" },
                    { 18, "DE", "Germany" },
                    { 19, "GR", "Greece" },
                    { 20, "HU", "Hungary" },
                    { 21, "IS", "Iceland" },
                    { 22, "IE", "Ireland" },
                    { 23, "IT", "Italy" },
                    { 24, "KZ", "Kazakhstan" },
                    { 25, "XK", "Kosovo" },
                    { 26, "LV", "Latvia" },
                    { 27, "LI", "Liechtenstein" },
                    { 28, "LT", "Lithuania" },
                    { 29, "LU", "Luxembourg" },
                    { 30, "MT", "Malta" },
                    { 31, "MD", "Moldova" },
                    { 32, "MC", "Monaco" },
                    { 33, "ME", "Montenegro" },
                    { 34, "NL", "Netherlands" },
                    { 35, "MK", "North Macedonia" },
                    { 36, "NO", "Norway" },
                    { 37, "PL", "Poland" },
                    { 38, "PT", "Portugal" },
                    { 39, "RO", "Romania" },
                    { 40, "RU", "Russia" },
                    { 41, "SM", "San Marino" },
                    { 42, "RS", "Serbia" },
                    { 43, "SK", "Slovakia" },
                    { 44, "SI", "Slovenia" },
                    { 45, "ES", "Spain" },
                    { 46, "SE", "Sweden" },
                    { 47, "CH", "Switzerland" },
                    { 48, "TR", "Turkey" },
                    { 49, "UA", "Ukraine" },
                    { 50, "GB", "United Kingdom" },
                    { 51, "VA", "Vatican City" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "owner" },
                    { 2, "administrateur" },
                    { 10, "visiteur" }
                });

            migrationBuilder.InsertData(
                table: "Tax",
                columns: new[] { "Id", "Tax_amount" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 10 },
                    { 3, 15 },
                    { 4, 20 },
                    { 5, 25 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AddressId", "CreatedAt", "Email", "IsBanned", "LastName", "Name", "Password", "RoleId", "Title", "UpdatedAt", "Username" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "descry@gmail.com", false, "gmail", "descry", "$2a$10$R95unTXkGA/uYS7gMDc4oOOVWb5QtwqWITrTz9y.o6tRX3LkPKZUK", 10, "utilisateur", null, "descry" });

            migrationBuilder.CreateIndex(
                name: "IX_Account_BillingAddressId",
                table: "Account",
                column: "BillingAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_CreatedById",
                table: "Account",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Account_DeliveryAddressId",
                table: "Account",
                column: "DeliveryAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_OwnerId",
                table: "Account",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_PaymentmethodId",
                table: "Account",
                column: "PaymentmethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Siret",
                table: "Account",
                column: "Siret",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_UpdatedById",
                table: "Account",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CreatedById",
                table: "Address",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Address_LastModifiedById",
                table: "Address",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AccountId",
                table: "Contact",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CreatedById",
                table: "Contact",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_OwnerId",
                table: "Contact",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UpdatedById",
                table: "Contact",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_AccountId",
                table: "Invoice",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ContactId",
                table: "Invoice",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CreatedById",
                table: "Invoice",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PaymentMethodId",
                table: "Invoice",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_QuoteId",
                table: "Invoice",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UpdatedById",
                table: "Invoice",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserId",
                table: "Invoice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProduct_CreatedById",
                table: "InvoiceProduct",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProduct_UpdatedById",
                table: "InvoiceProduct",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedById",
                table: "Product",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LastModifiedById",
                table: "Product",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_AccountId",
                table: "Quote",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_ContactId",
                table: "Quote",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_CreatedById",
                table: "Quote",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_PaymentMethodId",
                table: "Quote",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_UpdatedById",
                table: "Quote",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_UserId",
                table: "Quote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Address_BillingAddressId",
                table: "Account",
                column: "BillingAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Address_DeliveryAddressId",
                table: "Account",
                column: "DeliveryAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_CreatedById",
                table: "Account",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_OwnerId",
                table: "Account",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UpdatedById",
                table: "Account",
                column: "UpdatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_CreatedById",
                table: "Address",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_LastModifiedById",
                table: "Address",
                column: "LastModifiedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Tax");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
