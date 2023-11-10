using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CountryController :BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
        {
            var country = await _unitOfWork.Countrys.GetAllAsync();
            return _mapper.Map<List<CountryDto>>(country);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Country>>Get (int id)
        {
            var country = await _unitOfWork.Countrys.GetByIdAsync(id);
            if(country == null)
            {
                return NotFound();
            }
            return country;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Country>> Post(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);

            this._unitOfWork.Countrys.Add(country);
            await _unitOfWork.SaveAsync();

            if (country == null)
            {
                return BadRequest();
            }
            countryDto.Id = country.Id;
            return CreatedAtAction(nameof(Post), new {id = countryDto.Id}, countryDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            if(country.Id == 0)
            {
                country.Id = id;
            }
            if (country.Id != id)
            {
                return BadRequest();
            }
            if (country == null)
            {
                return NotFound();
            }
            countryDto.Id = country.Id;
            _unitOfWork.Countrys.Update(country);
            await _unitOfWork.SaveAsync();
            return countryDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var country = await _unitOfWork.Countrys.GetByIdAsync(id);
            if(country == null)
            {
                return NotFound();
            }
            _unitOfWork.Countrys.Remove(country);
            await _unitOfWork.SaveAsync();
            return NoContent();
        
        }
    }
}