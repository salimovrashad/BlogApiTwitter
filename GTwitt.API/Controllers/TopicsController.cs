using GTwitt.BUSINESS.DTOs.TopicDTOs;
using GTwitt.BUSINESS.Exceptions.Common;
using GTwitt.BUSINESS.Exceptions.Topic;
using GTwitt.BUSINESS.Repositories.Interfaces;
using GTwitt.BUSINESS.Services.Interfaces;
using GTwitt.CORE.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTwitt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        ITopicServices _services { get; }

        public TopicsController(ITopicServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_services.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _services.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TopicCreateDTO dto) 
        {
            try
            {
                await _services.CreateAsync(dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(TopicExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _services.RemoveAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TopicUpdateDTO dto)
        {
            await _services.UpdateAsync(id, dto);
            return Ok();
        }
    }
}
