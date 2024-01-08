using GTwitt.CORE.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.CORE.Entities
{
    public class Files : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        [NotMapped]
        public override DateTime CreatedTime { get => base.CreatedTime; set => base.CreatedTime = value; }
        [NotMapped]
        public override DateTime ModifiedTime { get => base.ModifiedTime; set => base.ModifiedTime = value; }
    }
}
