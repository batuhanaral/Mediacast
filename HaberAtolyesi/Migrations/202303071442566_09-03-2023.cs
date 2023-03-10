namespace HaberAtolyesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09032023 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bolumlers", "Kategori", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bolumlers", "Kategori");
        }
    }
}
