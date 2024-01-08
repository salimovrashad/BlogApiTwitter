using GTwitt.BUSINESS.DTOs.TopicDTOs;
using GTwitt.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Services.Interfaces
{
    public interface ITopicServices
    {
        public IEnumerable<TopicListItemDTO> GetAll();
        public Task<TopicDetailDTO> GetByIdAsync(int id);
        public Task CreateAsync(TopicCreateDTO dto);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(int id, TopicUpdateDTO dto);
    }
}
