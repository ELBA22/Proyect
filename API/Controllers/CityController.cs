using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CityController :BaseControllerAPI
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CityController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CityDto>>> Get()
        {
            var city = await _unitOfWork.Citys.GetAllAsync();
            return _mapper.Map<List<CityDto>>(city);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>>Get(int id)
        {
            var city= await _unitOfWork.Citys.GetByIdAsync(id);
            if(city == null)
            {
                return NotFound();
            }
            return _mapper.Map<CityDto>(city);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>>Post(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            this._unitOfWork.Citys.Add(city);
            await _unitOfWork.SaveAsync();
            
            if(city == null)
            {
                return BadRequest();
            }
            cityDto.Id = city.Id;
            return CreatedAtAction(nameof(Post), new {id = cityDto.Id}, city);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>>Post(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
             

        }

    }
}