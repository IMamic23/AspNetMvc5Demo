namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4cae83d4-639d-4c59-a27d-03f46091d875', N'guest@vidly.com', 0, N'AKEN0GN3z22hjYnIyXhVvVUueFADy6XP/DoCWCnnG1kBUP2GUWcP5UZpAAuxHyJuxg==', N'81388d42-5a97-43a6-86a2-1a7210c4e74a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'78020b5e-eae2-455c-8908-122c55d9fcaf', N'admin@vidly.com', 0, N'AM33mYPjfo23fSqnXFnZTa4mUafjHwkSlb4Y7xDxnz3qHdhkMVSH4LVRH+61oSfATA==', N'15c23965-399b-442c-8a47-d0bae82ff4b9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                ");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'355ca96a-f529-4011-b286-4e810873bea1', N'CanManageMovies')
                ");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'78020b5e-eae2-455c-8908-122c55d9fcaf', N'355ca96a-f529-4011-b286-4e810873bea1')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
