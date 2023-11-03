using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCRUDTestControllerBased.Models;
using WebApplicationCRUDTestControllerBased.Services;

namespace WebApplicationCRUDTestControllerBased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            this._student = student;
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _student.GetAllAsync());
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _student.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add(Student student)
        {
            return Ok(await _student.AddAsync(student));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(Student student)
        {
            return Ok(await _student.UpdateAsync(student));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _student.DeleteByIdAsync(id));
        }
    }
}
