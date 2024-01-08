using GTwitt.BUSINESS.Repositories.Interfaces;
using GTwitt.CORE.Entities;
using GTwitt.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Repositories.Implements
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(GTwittDbContext context) : base(context)
        {
        }
    }
}
