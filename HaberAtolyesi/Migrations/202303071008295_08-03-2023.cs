namespace HaberAtolyesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _08032023 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolumlers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Link = c.String(),
                        Create_Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bolumlers");
        }
    }
}
