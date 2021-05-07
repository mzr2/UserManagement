using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatenamatablerole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_roleaccounts_tb_m_accounts_RoleId",
                table: "tb_t_roleaccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "tb_m_accounts",
                newName: "tb_m_roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_roleaccounts_tb_m_roles_RoleId",
                table: "tb_t_roleaccounts",
                column: "RoleId",
                principalTable: "tb_m_roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_roleaccounts_tb_m_roles_RoleId",
                table: "tb_t_roleaccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles");

            migrationBuilder.RenameTable(
                name: "tb_m_roles",
                newName: "tb_m_accounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_roleaccounts_tb_m_accounts_RoleId",
                table: "tb_t_roleaccounts",
                column: "RoleId",
                principalTable: "tb_m_accounts",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
