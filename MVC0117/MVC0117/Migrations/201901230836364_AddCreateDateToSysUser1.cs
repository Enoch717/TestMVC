namespace MVC0117.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateDateToSysUser1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SysUser", "UserName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SysUser", "UserName", c => c.String());
        }
    }
}
