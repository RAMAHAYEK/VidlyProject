namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0be43d03-9a2a-43f4-8039-96ff96411b28', N'admin@Vidly.com', 0, N'AIj796H2AWpn1SmT/TntaR5vHXZSaACEpU0QZUlkNYGKwhCB1ely6mSt+MmaZt/bhg==', N'39f4a212-26bf-4ff2-b934-1b5f5fbc3f6c', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b015a6b9-af7f-42a6-9c7a-4dda99d252fe', N'guest@Vidly.com', 0, N'ADhNehgqIf0GDCBjr8PHFv5lrqbuFM28+n0igKDOzzdQKwDX2txpFqfTwT7Wc1RIQg==', N'9e7c7c82-7845-475a-9b8a-e7ba95b605ae', NULL, 0, 0, NULL, 1, 0, N'guest@Vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'65ca7c36-c0a9-46b8-a5da-6bfbc8ef66c9', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0be43d03-9a2a-43f4-8039-96ff96411b28', N'65ca7c36-c0a9-46b8-a5da-6bfbc8ef66c9')

");

        }
        
        public override void Down()
        {
        }
    }
}
