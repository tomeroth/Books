using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;

namespace CRUDService
{
    [ServiceContract]
    public interface IObjectsService
    {
        [OperationContract]
        int AddMovies (Movie movie);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie UpadteMovie(Movie Movie);

        [OperationContract]
        bool DeleteMovie(int id);


        [OperationContract]
        int AddReview(Review review);

        [OperationContract]
        Review GetReview(int id);

        [OperationContract]
        List<Review> GetAllReview();

        [OperationContract]
        Review UpdateReview (Review review);

        [OperationContract]
        bool DeleteReview(int id);


        [OperationContract]
        int AddPerson(Person person);

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        List<Person> GetAllPeople();

        [OperationContract]
        Person UpdatePerson(Person person);

        [OperationContract]
        bool DeletePerson(int id);

    }
}
