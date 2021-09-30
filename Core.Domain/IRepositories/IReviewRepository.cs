using System.Collections.Generic;
using Core.Core.Models;

namespace Core.Domain.IRepositories
{
    public interface IReviewRepository
    {
        public List<BEReview> GetAll();
    }
}