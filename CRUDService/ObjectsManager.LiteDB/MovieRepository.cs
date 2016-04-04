using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Interfaces;
using ObjectsManager.Model;
using LiteDB;
using ObjectsManager.LiteDB.Model;

namespace ObjectsManager.LiteDB
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _movieConnection = DatabaseConnections.MoviesConnection;

        List<Movie> IMovieRepository.GetAll()
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<MovieDB>("authors");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<MovieDB>("authors");
                if (repository.FindById(movie.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        Movie IMovieRepository.Get(int id)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<MovieDB>("movies");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                return repository.Delete(id);
            }
        }

        internal List<MovieDB> GetMovies(int[] ids)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                var results = repository.FindAll().Where(x => ids.Contains(x.Id));

                return results.ToList();
            }
        }

        internal Movie Map(MovieDB dbMovie)
        {
            if (dbMovie == null)
                return null;
            return new Movie() { Id = dbMovie.Id, Title = dbMovie.Title, ReleaseYear = dbMovie.ReleaseYear };
        }

        internal MovieDB InverseMap(Movie movie)
        {
            if (movie == null)
                return null;
            return new MovieDB() { Id = movie.Id, Title = movie.Title, ReleaseYear = movie.ReleaseYear };
        }
    }
}
