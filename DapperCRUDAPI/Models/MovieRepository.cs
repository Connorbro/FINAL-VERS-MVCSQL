using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DapperCRUDAPI.Models
{
    public class MovieRepository
    {
        private string connectionString = @"User ID = sa;Password = Mypasswordisgreat;Initial catalog= Movies;Data Source=localhost, 1433;  ";
        

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }


        public void Add(Movie newMovie)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string linkToDB = @"INSERT INTO MovieModel(MovieID, Title, Genre, Rating, ReleaseDate, IMDbscore) VALUES(@MovieID, @Title, @Genre, @Rating, @ReleaseDate, @IMDbscore)";
                dbConnection.Open();
                dbConnection.Execute(linkToDB, newMovie);
                
            }
        }

        public Movie GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string linkToDB = @"SELECT * FROM MovieModel WHERE MovieID=@Id";
                dbConnection.Open();
                return dbConnection.Query<Movie>(linkToDB, new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string linkToDB = @"EXEC MovieViewAll";
                dbConnection.Open();
                return dbConnection.Query<Movie>(linkToDB);
            }
        }

        public void UpdateMovies(Movie newMovie)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string linkToDB = @"UPDATE MovieModel SET Title=@Title, Genre=@Genre, Rating=@Rating, ReleaseDate=@ReleaseDate, IMDbscore=@IMDbscore WHERE MovieID=@MovieID";
                dbConnection.Open();
                dbConnection.Query(linkToDB, newMovie);
            }
        }

        
        public void DeleteByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"EXEC DeleteMovieByID @MovieID=@id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }        
    }
}
