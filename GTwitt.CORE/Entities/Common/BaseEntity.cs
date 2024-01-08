using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.CORE.Entities.Common
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public virtual DateTime CreatedTime { get; set; }
        public virtual DateTime ModifiedTime { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
