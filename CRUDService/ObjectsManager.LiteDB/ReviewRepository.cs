using ObjectsManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Model;
using LiteDB;
using ObjectsManager.LiteDB.Model;

namespace ObjectsManager.LiteDB
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _reviewConnection = DatabaseConnections.ReviewsConnection;

        public int Add(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);

                var repository = db.GetCollection<ReviewDB>("reviews");
                if (repository.FindById(review.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                return repository.Delete(id);
            }
        }

        public Review Get(int id)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Review Update(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);

                var repository = db.GetCollection<ReviewDB>("reviews");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        internal List<ReviewDB> GetReviews(int[] ids)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.FindAll().Where(x => ids.Contains(x.Id));

                return results.ToList();
            }
        }

        internal Review Map(ReviewDB dbReviews)
        {
            if (dbReviews == null)
                return null;
            return new Review() { Id = dbReviews.Id, Content = dbReviews.Content, Author = dbReviews.Author, MovieId = dbReviews.MovieId, Score = dbReviews.Score };
        }

        internal ReviewDB InverseMap(Review review)
        {
            if (review == null)
                return null;
            return new ReviewDB() { Id = review.Id, Content = review.Content, Author = review.Author, MovieId = review.MovieId, Score = review.Score};
        }
    }
}
