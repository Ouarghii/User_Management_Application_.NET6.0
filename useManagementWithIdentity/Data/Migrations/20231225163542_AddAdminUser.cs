using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace useManagementWithIdentity.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture]) VALUES (N'3f1b5c7d - de9a - 4825 - 8e2f - da37d0d47bd3', N'Raslenouarghi2018', N'RASLENOUARGHI2018', N'Raslenouarghi2018@gmail.com', N'RASLENOUARGHI2018@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHmuekabktEeUW351tcb + tSI8E0tre20eWxEDW / wuq6 + zISE96Q4Z8bT9cG20lEtiA == ', N'LKVBOVOITJCUBQKXIWZJJVTZCQQCDWXX', N'2c90d05c - 122a - 4dfa - b19a - c08dbe333d90', N'58039513', 0, 0, NULL, 1, 0, N'Rassleeen', N'Ouarghiii', NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE ID = '70415136-963a-4750-8913-ff480dfcdd0a'");
        }
    }
}
