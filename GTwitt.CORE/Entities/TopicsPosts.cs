using GTwitt.CORE.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.CORE.Entities
{
    public class TopicsPosts : BaseEntity
    {
        public int TopicID { get; set; }
        public int PostID { get; set; }
        public Topic? Topic { get; set; }
        public Post? Post { get; set; }
        [NotMapped]
        public override DateTime CreatedTime { get => base.CreatedTime; set => base.CreatedTime = value; }
        [NotMapped]
        public override DateTime ModifiedTime { get => base.ModifiedTime; set => base.ModifiedTime = value; }
    }
}
