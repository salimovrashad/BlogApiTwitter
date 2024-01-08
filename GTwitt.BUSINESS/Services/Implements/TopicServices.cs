using AutoMapper;
using GTwitt.BUSINESS.DTOs.TopicDTOs;
using GTwitt.BUSINESS.Exceptions.Common;
using GTwitt.BUSINESS.Exceptions.Topic;
using GTwitt.BUSINESS.Repositories.Interfaces;
using GTwitt.BUSINESS.Services.Interfaces;
using GTwitt.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTwitt.BUSINESS.Services.Implements
{
    public class TopicServices : ITopicServices
    {
        ITopicRepository _repo { get; }
        IMapper _mapper { get; }

        public TopicServices(ITopicRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(TopicCreateDTO dto)
        {
            if(await _repo.IsExistAsync (r => r.Name.ToLower() == dto.Name.ToLower()))
            {
                throw new TopicExistException();
            }
           await _repo.CreateAsync(_mapper.Map<Topic>(dto));
           await _repo.SaveAsync();
        }

        public IEnumerable<TopicListItemDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<TopicListItemDTO>>(_repo.GetAll());
        }

        public async Task<TopicDetailDTO> GetByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id);
            if (data == null) throw new NotFoundException<Topic>();
            return _mapper.Map<TopicDetailDTO>(data);
        }

        public async Task RemoveAsync(int id)
        {
            if(id <=0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Topic>();
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(int id, TopicUpdateDTO dto)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Topic>();
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
            {
                throw new TopicExistException();
            }
            data = _mapper.Map(dto, data);
            await _repo.SaveAsync();
        }
    }
}   
