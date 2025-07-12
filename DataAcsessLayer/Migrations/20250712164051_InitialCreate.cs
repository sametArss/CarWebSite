using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAcsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    BrandStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    ModelStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "PieceStatuses",
                columns: table => new
                {
                    PieceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PieceStatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceStatuses", x => x.PieceId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    KiloMetre = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CarStatus = table.Column<bool>(type: "boolean", nullable: false),
                    CarDescription = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    ExpertiseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    KaputStatusId = table.Column<int>(type: "integer", nullable: false),
                    TavanStatusId = table.Column<int>(type: "integer", nullable: false),
                    BagajStatusId = table.Column<int>(type: "integer", nullable: false),
                    SolOnKapıStatusId = table.Column<int>(type: "integer", nullable: false),
                    SagOnKapıStatusId = table.Column<int>(type: "integer", nullable: false),
                    SolArkaKapıStatusId = table.Column<int>(type: "integer", nullable: false),
                    SagArkaKapıStatusId = table.Column<int>(type: "integer", nullable: false),
                    SolOnCamurlukStatusId = table.Column<int>(type: "integer", nullable: false),
                    SagOnCamurlukStatusId = table.Column<int>(type: "integer", nullable: false),
                    SolArkaCamurlukStatusId = table.Column<int>(type: "integer", nullable: false),
                    SagArkaCamurlukStatusId = table.Column<int>(type: "integer", nullable: false),
                    OnTamponDurum = table.Column<int>(type: "integer", nullable: false),
                    OnTamponStatusPieceId = table.Column<int>(type: "integer", nullable: false),
                    ArkaTampon = table.Column<int>(type: "integer", nullable: false),
                    ArkaTamponStatusPieceId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.ExpertiseId);
                    table.ForeignKey(
                        name: "FK_Expertises_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_ArkaTamponStatusPieceId",
                        column: x => x.ArkaTamponStatusPieceId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_BagajStatusId",
                        column: x => x.BagajStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_KaputStatusId",
                        column: x => x.KaputStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_OnTamponStatusPieceId",
                        column: x => x.OnTamponStatusPieceId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SagArkaCamurlukStatusId",
                        column: x => x.SagArkaCamurlukStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SagArkaKapıStatusId",
                        column: x => x.SagArkaKapıStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SagOnCamurlukStatusId",
                        column: x => x.SagOnCamurlukStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SagOnKapıStatusId",
                        column: x => x.SagOnKapıStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SolArkaCamurlukStatusId",
                        column: x => x.SolArkaCamurlukStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SolArkaKapıStatusId",
                        column: x => x.SolArkaKapıStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SolOnCamurlukStatusId",
                        column: x => x.SolOnCamurlukStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_SolOnKapıStatusId",
                        column: x => x.SolOnKapıStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expertises_PieceStatuses_TavanStatusId",
                        column: x => x.TavanStatusId,
                        principalTable: "PieceStatuses",
                        principalColumn: "PieceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_ArkaTamponStatusPieceId",
                table: "Expertises",
                column: "ArkaTamponStatusPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_BagajStatusId",
                table: "Expertises",
                column: "BagajStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_CarId",
                table: "Expertises",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_KaputStatusId",
                table: "Expertises",
                column: "KaputStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_OnTamponStatusPieceId",
                table: "Expertises",
                column: "OnTamponStatusPieceId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SagArkaCamurlukStatusId",
                table: "Expertises",
                column: "SagArkaCamurlukStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SagArkaKapıStatusId",
                table: "Expertises",
                column: "SagArkaKapıStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SagOnCamurlukStatusId",
                table: "Expertises",
                column: "SagOnCamurlukStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SagOnKapıStatusId",
                table: "Expertises",
                column: "SagOnKapıStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SolArkaCamurlukStatusId",
                table: "Expertises",
                column: "SolArkaCamurlukStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SolArkaKapıStatusId",
                table: "Expertises",
                column: "SolArkaKapıStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SolOnCamurlukStatusId",
                table: "Expertises",
                column: "SolOnCamurlukStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_SolOnKapıStatusId",
                table: "Expertises",
                column: "SolOnKapıStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_TavanStatusId",
                table: "Expertises",
                column: "TavanStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "PieceStatuses");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
