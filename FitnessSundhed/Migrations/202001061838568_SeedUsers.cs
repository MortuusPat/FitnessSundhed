namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4d0043f0-18bd-4e8b-947e-6b041f87c877', N'guest@guest.com', 0, N'ADu9XcPuKtE+mr4M3RaZN8/h3Pz7kGUODtpBMPhcxJxfw2vRIR1Lt5Zk5Hk0WvLKtg==', N'f57f27f6-0b1b-434c-b146-d46660eea9e9', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a7b1c212-0f8c-42d8-bcfb-3bbf76b82d70', N'admin@admin.com', 0, N'AEU0mOhnn2lSNDxb9nPryHs1Nh6xUZ9/46+fCoxbeFb9G6Bv38hZeDHlYDK+r0RQWA==', N'df9b9a58-ed90-420b-bd50-7b8d1e090fb5', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf2228c3-6403-4e0a-8478-124fa49d4357', N'CanManageAdmin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a7b1c212-0f8c-42d8-bcfb-3bbf76b82d70', N'bf2228c3-6403-4e0a-8478-124fa49d4357')

");
        }
        
        public override void Down()
        {
        }
    }
}
