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
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(GTwittDbContext context) : base(context)
        {
        }
    }
}
