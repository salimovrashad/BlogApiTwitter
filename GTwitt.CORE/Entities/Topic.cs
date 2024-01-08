using GTwitt.CORE.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.CORE.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TopicsPosts>? TopicsPosts { get; set; }

        [NotMapped]
        public override DateTime ModifiedTime { get => base.ModifiedTime; set => base.ModifiedTime = value; }
    }
}
