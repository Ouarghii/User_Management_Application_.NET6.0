using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace useManagementWithIdentity.Data.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] (UserId,RoleId) SELECT '3f1b5c7d - de9a - 4825 - 8e2f - da37d0d47bd3',Id FROM [security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId='3f1b5c7d - de9a - 4825 - 8e2f - da37d0d47bd3'");
        }
    }
}
