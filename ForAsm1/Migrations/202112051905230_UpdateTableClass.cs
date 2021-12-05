namespace ForAsm1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableClass : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Classes", "Name", unique: true, name: "UniqueName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Classes", "UniqueName");
        }
    }
}
