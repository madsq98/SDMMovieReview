using System.Collections.Generic;
using Core.Core.Models;

namespace Core.Core.IServices
{
    public interface IReviewService
    {
        int GetNumberOfReviewsFromReviewer(int reviewer);
        
        double GetAverageRateFromReviewer(int reviewer);
        
        int GetNumberOfRatesByReviewer(int reviewer, int rate);
        
        int GetNumberOfReviews(int movie);
        
        double GetAverageRateOfMovie(int movie);
        
        int GetNumberOfRates(int movie, int rate);
        
        List<int> GetMoviesWithHighestNumberOfTopRates();

        List<int> GetMostProductiveReviewers();

        List<int> GetTopRatedMovies(int amount);
    }
}