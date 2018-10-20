namespace BackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 250),
                        Price = c.Single(nullable: false),
                        Country = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblProducts");
        }
    }
}
