using GTwitt.BUSINESS.DTOs.PostDTOs;
using GTwitt.BUSINESS.DTOs.TopicDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Services.Interfaces
{
    public interface IPostServices
    {
        public IEnumerable<PostListItemDTO> GetAll();
        public Task<PostDetailDTO> GetByIdAsync(int id);
        public Task CreateAsync(PostCreateDTO dto);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(int id, PostUpdateDTO dto);
    }
}
