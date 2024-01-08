using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Exceptions.Topic
{
    public class TopicExistException : Exception
    {
        public TopicExistException(): base("Topic already added.")
        {
        }

        public TopicExistException(string? message) : base(message)
        {
        }
    }
}
