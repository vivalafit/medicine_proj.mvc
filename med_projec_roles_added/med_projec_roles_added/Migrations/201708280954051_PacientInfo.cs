namespace med_projec_roles_added.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PacientInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PacientInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PacientInfo");
        }
    }
}
