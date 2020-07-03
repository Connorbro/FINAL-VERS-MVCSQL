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
                string sQuery = @"INSERT INTO MovieModel(MovieID, Title, Genre, Rating, ReleaseDate, IMDbscore) VALUES(@MovieID, @Title, @Genre, @Rating, @ReleaseDate, @IMDbscore)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, newMovie);
            }
        }



        public IEnumerable<Movie> GetAllMovies()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"EXEC MovieViewAll";
                dbConnection.Open();
                return dbConnection.Query<Movie>(sQuery);
            }
        }



        public Movie GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM MovieModel WHERE MovieID=@Id";
                dbConnection.Open();
                return dbConnection.Query<Movie>(sQuery, new { Id = id }).FirstOrDefault();
            }

        

        }
    }
}
