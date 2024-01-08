﻿using GTwitt.BUSINESS.DTOs.PostDTOs;
using GTwitt.BUSINESS.DTOs.TopicDTOs;
using GTwitt.BUSINESS.Exceptions.Topic;
using GTwitt.BUSINESS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTwitt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostServices _services { get; }

        public PostsController(IPostServices services)
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
        public async Task<IActionResult> Post(PostCreateDTO dto)
        {
            try
            {
                await _services.CreateAsync(dto);
                return StatusCode(StatusCodes.Status201Created);
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
        public async Task<IActionResult> Update(int id, PostUpdateDTO dto)
        {
            await _services.UpdateAsync(id, dto);
            return Ok();
        }
    }
}
