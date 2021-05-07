using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatetableuniversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_Educations_tb_m_universities_UniversityId",
                table: "tb_t_Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_profilings_tb_t_Educations_EducationId",
                table: "tb_t_profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_t_Educations",
                table: "tb_t_Educations");

            migrationBuilder.RenameTable(
                name: "tb_t_Educations",
                newName: "tb_m_Educations");

            migrationBuilder.RenameIndex(
                name: "IX_tb_t_Educations_UniversityId",
                table: "tb_m_Educations",
                newName: "IX_tb_m_Educations_UniversityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_Educations",
                table: "tb_m_Educations",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_Educations_tb_m_universities_UniversityId",
                table: "tb_m_Educations",
                column: "UniversityId",
                principalTable: "tb_m_universities",
                principalColumn: "UniversityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_profilings_tb_m_Educations_EducationId",
                table: "tb_t_profilings",
                column: "EducationId",
                principalTable: "tb_m_Educations",
                principalColumn: "EducationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_Educations_tb_m_universities_UniversityId",
                table: "tb_m_Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_profilings_tb_m_Educations_EducationId",
                table: "tb_t_profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_Educations",
                table: "tb_m_Educations");

            migrationBuilder.RenameTable(
                name: "tb_m_Educations",
                newName: "tb_t_Educations");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_Educations_UniversityId",
                table: "tb_t_Educations",
                newName: "IX_tb_t_Educations_UniversityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_t_Educations",
                table: "tb_t_Educations",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_Educations_tb_m_universities_UniversityId",
                table: "tb_t_Educations",
                column: "UniversityId",
                principalTable: "tb_m_universities",
                principalColumn: "UniversityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_profilings_tb_t_Educations_EducationId",
                table: "tb_t_profilings",
                column: "EducationId",
                principalTable: "tb_t_Educations",
                principalColumn: "EducationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
