using ApplicationLayer.Services.TaskService;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 
using System.Threading.Tasks;
using System.Linq; 
using System; 

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly TaskService _service; 

        public TareasController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Response<Tareas>>> GetTaskAllAsync() =>
            await _service.GetTaskAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Tareas>>> GetTaskByIdAllAsync(int id) =>
            await _service.GetTaskByIdAllAsync(id);


        [HttpGet("filter")] 
        public async Task<ActionResult<Response<IEnumerable<Tareas>>>> GetFilteredTasks(
               [FromQuery] string status = null,
               [FromQuery] DateTime? dueDate = null) =>
               await _service.GetFilteredTasksAsync(status, dueDate);

        [HttpPost]
        public async Task<ActionResult<Response<string>>> AddTaskAllAsync([FromBody] Tareas tarea)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorResponse = new Response<string> { Successful = false, Errors = errors, Message = "Datos de entrada inválidos." };
                return BadRequest(errorResponse);
            }
            return await _service.AddTaskAllAsync(tarea);
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> UpdateTaskAllAsync([FromBody] Tareas tarea)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                var errorResponse = new Response<string> { Successful = false, Errors = errors, Message = "Datos de entrada inválidos." };
                return BadRequest(errorResponse);
            }
            return await _service.UpdateTaskAllAsync(tarea);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<string>>> DeleteTaskAllAsync(int id) =>
            await _service.DeleteTaskAllAsync(id);
    }
}
