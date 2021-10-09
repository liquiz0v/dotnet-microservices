using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Contracts;
using PlatformService.Data.Impl;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private IMapper _mapper;
        private IPlatformRepository _repo;
        public PlatformController(IMapper mapper, IPlatformRepository repository)
        {
            _mapper = mapper;
            _repo = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platforms = _repo.GetAllPlatforms();

            return Ok(_mapper.Map<List<PlatformReadDto>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var result = _repo.GetPlatformById(id);

            if (result != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(result));
            }

            return NotFound();
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformWriteDto platform)
        {
            var createdPlatform = _mapper.Map<Platform>(platform);
            
            _repo.CreatePlatform(createdPlatform);
            _repo.SaveChanges();

            return CreatedAtRoute( // Generates 201 Created http code
                nameof(GetPlatformById),
                new { id = createdPlatform.Id}, // It requires id of a resource and path to the created resource
                _mapper.Map<PlatformReadDto>(createdPlatform));
        }
    }
}