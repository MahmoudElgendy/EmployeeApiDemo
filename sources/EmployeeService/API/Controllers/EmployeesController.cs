using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var employees = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return (employee == null) ? NotFound() : Ok(_mapper.Map<EmployeeDto>(employee));
        }
        [HttpPost]
        public async Task<ActionResult> Insert(EmployeeDto employeeDto)
        {
            await _repository.InsertAsync(_mapper.Map<Employee>(employeeDto));
            return CreatedAtAction(nameof(GetById), new { id = employeeDto.Id }, employeeDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
                return BadRequest();
            await _repository.UpdateAsync(_mapper.Map<Employee>(employeeDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employeeToDelete = await _repository.GetByIdAsync(id);
            if (employeeToDelete == null)
                return NotFound();
            await _repository.DeleteAsync(_mapper.Map<Employee>(employeeToDelete));
            return NoContent();

        }
    }
}
