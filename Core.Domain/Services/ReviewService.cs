using System;
using System.Collections.Generic;
using System.Linq;
using Core.Core.IServices;
using Core.Core.Models;
using Core.Domain.IRepositories;

namespace Core.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;

        public ReviewService(IReviewRepository repo)
        {
            _repo = repo;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<BEReview> allReviews = _repo.GetAll();

            int count = 0;
            foreach (BEReview review in allReviews)
            {
                if (review.Reviewer == reviewer)
                    count++;
            }

            return count;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            List<BEReview> allReviews = _repo.GetAll();

            int count = 0;
            int totalGrade = 0;
            foreach (BEReview review in allReviews)
            {
                if (review.Reviewer == reviewer)
                {
                    count++;
                    totalGrade += review.Grade;
                }
            }

            return (double) totalGrade / count;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            List<BEReview> allReviews = _repo.GetAll();
            
            int count = 0;
            foreach (BEReview review in allReviews)
            {
                if (review.Reviewer == reviewer && review.Grade == rate)
                    count++;
            }

            return count;
        }

        public int GetNumberOfReviews(int movie)
        {
            List<BEReview> allReviews = _repo.GetAll();

            int count = 0;
            foreach (BEReview review in allReviews)
            {
                if (review.Movie == movie)
                    count++;
            }

            return count;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            List<BEReview> allReviews = _repo.GetAll();

            int count = 0;
            int totalGrade = 0;
            foreach (BEReview review in allReviews)
            {
                if (review.Movie == movie)
                {
                    count++;
                    totalGrade += review.Grade;
                }
            }

            return (double) totalGrade / count;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            List<BEReview> allReviews = _repo.GetAll();
            
            int count = 0;
            foreach (BEReview review in allReviews)
            {
                if (review.Movie == movie && review.Grade == rate)
                    count++;
            }

            return count;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            List<BEReview> allReviews = _repo.GetAll();
            int highestGrade = 5;

            IDictionary<int, int> assocList = new Dictionary<int, int>();

            List<int> returnList = new List<int>();

            foreach (BEReview review in allReviews)
            {
                if (review.Grade == highestGrade)
                {
                    if (assocList.ContainsKey(review.Movie))
                        assocList[review.Movie]++;
                    else
                        assocList.Add(review.Movie, 1);
                }
            }
            
            var ordered = assocList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int highestCount = ordered[ordered.First().Key];

            foreach (KeyValuePair<int, int> entry in ordered)
            {
                if (entry.Value == highestCount)
                    returnList.Add(entry.Key);
            }

            return returnList;
        }
    }
}