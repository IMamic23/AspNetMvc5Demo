namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies2 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, InStock, GenreId) VALUES (2, 'Die Hard', '1998-03-05', '2017-10-04', 0, 2)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, InStock, GenreId) VALUES (3, 'The Terminator', '1999-06-11', '2017-10-04', 1, 2)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, InStock, GenreId) VALUES (4, 'Toy Story', '2001-01-17', '2017-10-01', 1, 5)");
            Sql("INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, InStock, GenreId) VALUES (5, 'Titanic', '2002-09-14', '2017-10-01', 4, 6)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }
        
        public override void Down()
        {
        }
    }
}
