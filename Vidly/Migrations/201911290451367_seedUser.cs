namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'25959d1d-e651-492e-ab64-a49b304580bc', N'kpkanimozhi97@gmail.com', 0, N'ALoRag8/k4A0uVUmwxAco4caGUy4SsP2GwUmFRUH+5DyrTI5OvcGjeDJaIVGBkqUrQ==', N'5f76f0a9-ee52-42ce-b3b6-2bd5ec167389', NULL, 0, 0, NULL, 1, 0, N'kpkanimozhi97@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6e5cdf67-fa0e-40a6-b02e-3498a030a6ed', N'user1@gmail.com', 0, N'APX2F/XLESYeU5PzIctIpBN40LGiXO/q31UlLez9iPvX5XhisCyjl/OyBQBhG/6qCQ==', N'fbae35df-bde5-43ba-8666-05dd9ab50a01', NULL, 0, 0, NULL, 1, 0, N'user1@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ff3c7b11-6ded-4795-b62f-40818ded29dd', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'25959d1d-e651-492e-ab64-a49b304580bc', N'ff3c7b11-6ded-4795-b62f-40818ded29dd')

");
        }
        
        public override void Down()
        {
        }
    }
}
