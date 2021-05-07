using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updatenamatableroledanroleaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccounts_Roles_RoleId",
                table: "RoleAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccounts_tb_t_accounts_NIK",
                table: "RoleAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleAccounts",
                table: "RoleAccounts");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "RoleAccounts",
                newName: "tb_t_roleaccounts");

            migrationBuilder.RenameIndex(
                name: "IX_RoleAccounts_RoleId",
                table: "tb_t_roleaccounts",
                newName: "IX_tb_t_roleaccounts_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_t_roleaccounts",
                table: "tb_t_roleaccounts",
                columns: new[] { "NIK", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_roleaccounts_tb_m_accounts_RoleId",
                table: "tb_t_roleaccounts",
                column: "RoleId",
                principalTable: "tb_m_accounts",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_roleaccounts_tb_t_accounts_NIK",
                table: "tb_t_roleaccounts",
                column: "NIK",
                principalTable: "tb_t_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_roleaccounts_tb_m_accounts_RoleId",
                table: "tb_t_roleaccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_roleaccounts_tb_t_accounts_NIK",
                table: "tb_t_roleaccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_t_roleaccounts",
                table: "tb_t_roleaccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "tb_t_roleaccounts",
                newName: "RoleAccounts");

            migrationBuilder.RenameTable(
                name: "tb_m_accounts",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_tb_t_roleaccounts_RoleId",
                table: "RoleAccounts",
                newName: "IX_RoleAccounts_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleAccounts",
                table: "RoleAccounts",
                columns: new[] { "NIK", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccounts_Roles_RoleId",
                table: "RoleAccounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccounts_tb_t_accounts_NIK",
                table: "RoleAccounts",
                column: "NIK",
                principalTable: "tb_t_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
