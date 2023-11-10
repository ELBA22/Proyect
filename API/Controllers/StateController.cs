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
    public class StateController :BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StateController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<StateDto>>>Get()
        {
            var state = await _unitOfWork.States.GetAllAsync();
            return _mapper.Map<List<StateDto>>(state);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<State>>Get (int id)
        {
            var state = await _unitOfWork.States.GetByIdAsync(id);
            if(state == null)
            {
                return NotFound();
            }
            return state;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State>> Post(StateDto stateDto)
        {
            var state =  _mapper.Map<State>(stateDto);

            this._unitOfWork.States.Add(state);
            await _unitOfWork.SaveAsync();

            if(stateDto == null)
            {
                return BadRequest();
            }
            stateDto.Id = state.Id;
            return CreatedAtAction(nameof(Post), new{id = stateDto.Id}, stateDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StateDto>> Put(int id, [FromBody]StateDto stateDto)
        {
            var state = _mapper.Map<State>(stateDto);
            if (state.Id == 0)
            {
                stateDto.Id = id;
            }
            if (state.Id != id)
            {
                return BadRequest();
            }
            if(state == null)
            {
                return NotFound();
            }
            stateDto.Id = state.Id;
            _unitOfWork.States.Update(state);
            await _unitOfWork.SaveAsync();
            return stateDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var state = await _unitOfWork.States.GetByIdAsync(id);
            if(state == null)
            {
                return NotFound();
            }
            _unitOfWork.States.Remove(state);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        
    }
}