using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Core.Core.IServices;
using Core.Core.Models;
using Core.Domain.IRepositories;
using Core.Domain.Services;
using Moq;
using Xunit;

namespace Test.UnitTest
{
    public class UnitTest1
    {
        public List<BEReview> mockData = new List<BEReview>()
        {
            new BEReview { Grade = 5, Movie = 1, Reviewer = 1, ReviewDate = DateTime.Now },
            new BEReview { Grade = 4, Movie = 2, Reviewer = 1, ReviewDate = DateTime.Now },
            new BEReview { Grade = 3, Movie = 2, Reviewer = 1, ReviewDate = DateTime.Now },
            new BEReview { Grade = 2, Movie = 4, Reviewer = 1, ReviewDate = DateTime.Now },
            new BEReview { Grade = 1, Movie = 5, Reviewer = 1, ReviewDate = DateTime.Now },
            new BEReview { Grade = 2, Movie = 655, Reviewer = 1, ReviewDate = DateTime.Now },
            new BEReview { Grade = 3, Movie = 76, Reviewer = 2, ReviewDate = DateTime.Now },
            new BEReview { Grade = 2, Movie = 45, Reviewer = 2, ReviewDate = DateTime.Now },
            new BEReview { Grade = 5, Movie = 10, Reviewer = 2, ReviewDate = DateTime.Now },
            new BEReview { Grade = 4, Movie = 24, Reviewer = 2, ReviewDate = DateTime.Now },
            new BEReview { Grade = 4, Movie = 10, Reviewer = 3, ReviewDate = DateTime.Now }
        };

        [Theory]
        [InlineData(1,6)]
        [InlineData(2,4)]
        public void TestNumberOfReviewsFromReviewer(int reviewer, int expectedResult)
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            Assert.Equal(expectedResult, service.GetNumberOfReviewsFromReviewer(reviewer));
        }

        [Theory]
        [InlineData(1,3)]
        [InlineData(2,3.5)]
        public void TestAverageRateFromReviewer(int reviewer, double expectedResult)
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            Assert.Equal(expectedResult, service.GetAverageRateFromReviewer(reviewer));
        }

        [Theory]
        [InlineData(1, 5, 1)]
        [InlineData(2, 2, 1)]
        public void TestNumberOfRatesFromReviewer(int reviewer, int rate, int expectedResult)
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            Assert.Equal(expectedResult, service.GetNumberOfRatesByReviewer(reviewer,rate));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(11, 0)]
        public void TestNumberOfReviews(int movie, int expectedResult)
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            Assert.Equal(expectedResult, service.GetNumberOfReviews(movie));
        }
        
        [Theory]
        [InlineData(2,3.5)]
        [InlineData(1,5)]
        public void TestAverageRateMovie(int movie, double expectedResult)
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            Assert.Equal(expectedResult, service.GetAverageRateOfMovie(movie));
        }
        
        [Theory]
        [InlineData(2,4,1)]
        [InlineData(2,3,1)]
        public void TestNumberOfRatesMovie(int movie, int rate, int expectedResult)
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            Assert.Equal(expectedResult, service.GetNumberOfRates(movie,rate));
        }

        [Fact]
        public void TestMoviesWithTopRates()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            List<int> expectedResult = new List<int>() {1, 10};

            Assert.Equal(expectedResult, service.GetMoviesWithHighestNumberOfTopRates());
        }

        [Fact]
        public void TestMostProductiveReviewers()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            List<int> expectedResult = new List<int>() {1};

            Assert.Equal(expectedResult, service.GetMostProductiveReviewers());
        }

        [Fact]
        public void TestTopRatedMovies()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
            IReviewService service = new ReviewService(mock.Object);

            mock.Setup(m => m.GetAll()).Returns(() => mockData);

            int amount = 5;
            List<int> expectedResult = new List<int>() {1,10,24,2,76};
            
            Assert.Equal(expectedResult, service.GetTopRatedMovies(amount));
        }
    }
}