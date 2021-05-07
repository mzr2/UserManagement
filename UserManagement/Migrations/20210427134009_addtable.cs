using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class addtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_universities",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_universities", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_accounts",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_accounts", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_t_accounts_tb_m_persons_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_persons",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_Educations_tb_m_universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "tb_m_universities",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_profilings",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_profilings", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_t_profilings_tb_t_accounts_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_t_accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_t_profilings_tb_t_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "tb_t_Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_Educations_UniversityId",
                table: "tb_t_Educations",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_profilings_EducationId",
                table: "tb_t_profilings",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_t_profilings");

            migrationBuilder.DropTable(
                name: "tb_t_accounts");

            migrationBuilder.DropTable(
                name: "tb_t_Educations");

            migrationBuilder.DropTable(
                name: "tb_m_universities");
        }
    }
}
