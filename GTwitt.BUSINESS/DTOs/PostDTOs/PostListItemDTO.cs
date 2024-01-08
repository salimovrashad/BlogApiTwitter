using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.DTOs.PostDTOs
{
    public class PostListItemDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
    }
}
