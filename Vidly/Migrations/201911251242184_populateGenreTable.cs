namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name)VALUES('Action')");
            Sql("INSERT INTO Genres(Name)VALUES('Sports')");
            Sql("INSERT INTO Genres(Name)VALUES('Thriller')");
            Sql("INSERT INTO Genres(Name)VALUES('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
