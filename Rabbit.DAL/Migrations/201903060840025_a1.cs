namespace Rabbit.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 55),
                        Address = c.String(nullable: false, maxLength: 150),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MailLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Message = c.String(),
                        Subject = c.String(),
                        CustomerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MailLogs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MailLogs", new[] { "CustomerId" });
            DropTable("dbo.MailLogs");
            DropTable("dbo.Customers");
        }
    }
}
