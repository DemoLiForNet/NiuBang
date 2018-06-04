namespace NiuBang.DbMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPermission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureName = c.String(nullable: false, maxLength: 30),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        CreatedByUserId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedByUserId = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        IsDelete = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "DisplayName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "DisplayName");
            DropTable("dbo.Permission");
        }
    }
}
