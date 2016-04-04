using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;
using ObjectsManager.Model;

namespace CRUDService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ObjectsService : IObjectsService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;

        public ObjectsService()
        {
            this._personRepository = new PersonRepository();
            this._reviewRepository = new ReviewRepository();
            this._movieRepository = new MovieRepository();
        }
       
        public int AddMovies(Movie movie)
        {
            return this._movieRepository.Add(movie);
        }

        public Movie GetMovie(int id)
        {
            return this._movieRepository.Get(id);
        }

        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll();
        }

        public Movie UpadteMovie(Movie Movie)
        {
            return this._movieRepository.Update(Movie);
        }

        public bool DeleteMovie(int id)
        {
            return this._movieRepository.Delete(id);
        }

        public int AddReview(Review review)
        {
            return this._reviewRepository.Add(review);
        }

        public Review GetReview(int id)
        {
            return this._reviewRepository.Get(id);
        }

        public List<Review> GetAllReview()
        {
            return this._reviewRepository.GetAll();
        }

        public Review UpdateReview(Review review)
        {
            return this._reviewRepository.Update(review);
        }

        public int AddPerson(Person person)
        {
            return this._personRepository.Add(person);
        }

        public List<Person> GetAllPeople()
        {
            return this._personRepository.GetAll();
        }

        public Person UpdatePerson(Person person)
        {
            return this._personRepository.Update(person);
        }

        public Person GetPerson(int id)
        {
            return this._personRepository.Get(id);
        }

        public bool DeleteReview(int id)
        {
            return this._reviewRepository.Delete(id);
        }

        public bool DeletePerson(int id)
        {
            return this._personRepository.Delete(id);
        }
    }
}
