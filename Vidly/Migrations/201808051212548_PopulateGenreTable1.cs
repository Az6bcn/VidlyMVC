namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MovieGenres (Name) values ('Comedy') ");
            Sql("Insert into MovieGenres (Name) values ('Action') ");
            Sql("Insert into MovieGenres (Name) values ('Romance') ");
            Sql("Insert into MovieGenres (Name) values ('Family') ");
        }
        
        public override void Down()
        {
        }
    }
}
