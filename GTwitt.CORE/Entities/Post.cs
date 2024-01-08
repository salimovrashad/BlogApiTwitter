using GTwitt.CORE.Entities.Common;

namespace GTwitt.CORE.Entities
{
    public class Post : BaseEntity
    {
        public string Text { get; set; }
        public int? UpdateCount { get; set; }
        public int? UserId { get; set; }
        //public AppUser? AppUser { get; set; }
        public ICollection<Files>? Files { get; set; }
        public ICollection<TopicsPosts>? TopicsPosts { get; set; }
    }
}
