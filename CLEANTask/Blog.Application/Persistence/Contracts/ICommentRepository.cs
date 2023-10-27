using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain;

namespace Blog.Application.Persistence.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {

    }
}
