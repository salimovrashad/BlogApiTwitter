using GTwitt.CORE.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Exceptions.Common
{
    public class NotFoundException<T> : Exception where T : BaseEntity
    {
        public NotFoundException() : base(typeof(T).Name + " not found.")
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
