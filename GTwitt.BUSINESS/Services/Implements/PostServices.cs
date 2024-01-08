using AutoMapper;
using GTwitt.BUSINESS.DTOs.PostDTOs;
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
    public class PostServices : IPostServices
    {
        IPostRepository _repo { get; }
        IMapper _mapper { get; }

        public PostServices(IPostRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(PostCreateDTO dto)
        {
            await _repo.CreateAsync(_mapper.Map<Post>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<PostListItemDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PostListItemDTO>>(_repo.GetAll());
        }

        public async Task<PostDetailDTO> GetByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id);
            if (data == null) throw new NotFoundException<Post>();
            return _mapper.Map<PostDetailDTO>(data);
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Post>();
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(int id, PostUpdateDTO dto)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Post>();
            data = _mapper.Map(dto, data);
            await _repo.SaveAsync();
        }
    }
}
