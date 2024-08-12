using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn.Models;

namespace learn.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
    }
}