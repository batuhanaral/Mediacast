namespace HaberAtolyesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KategoriAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Habers", "Kategori", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Habers", "Kategori");
        }
    }
}
