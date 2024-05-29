using GProyectosEmpleados.Models.DTOs;
using GProyectosEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.AspNetCore.Authorization;

namespace GProyectosEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TareaController : ControllerBase
    {
        private readonly DataContext _context;

        public TareaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult GetTareas()
        {
            var tareas = _context.Tareas.ToList();

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Listado de tareas.",
                result = tareas
            });
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public IActionResult GetRol(int id)
        {
            var tarea = _context.Tareas.FirstOrDefault(e => e.IdTarea == id);

            if (tarea == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Tarea no encontrada",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Tarea encontrada",
                result = tarea
            });
        }

        // PUT: api/Competencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTarea(int id, [FromBody] TareaDTO tareaDTO)
        {
            var tarea = _context.Tareas.FirstOrDefault(e => e.IdTarea == id);

            try
            {
                if (tarea != null)
                {
                    tarea.Descripcion = tareaDTO.Descripcion;
                    tarea.Estado = tareaDTO.Estado;
                    tarea.EmpleadoIdEmpleado = tareaDTO.EmpleadoIdEmpleado;
                    tarea.ProyectoIdProyecto = tareaDTO.ProyectoIdProyecto;
                }
                _context.SaveChanges();


            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrio un error inesperado.",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Tarea actualizada",
                result = ""
            });
        }

        // POST: api/Competencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTarea(TareaDTO tareaDTO)
        {
            Tarea tarea = new Tarea();
            tarea.Descripcion = tareaDTO.Descripcion;
            tarea.Estado = tareaDTO.Estado;
            tarea.EmpleadoIdEmpleado = tareaDTO.EmpleadoIdEmpleado;
            tarea.ProyectoIdProyecto = tareaDTO.ProyectoIdProyecto;

            try
            {
                _context.Tareas.Add(tarea);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrio un error inesperado.",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Tarea agregada.",
                result = ""
            });
        }

        // DELETE: api/Competencias/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTarea(int id)
        {
            var tarea = _context.Tareas.FirstOrDefault(e => e.IdTarea == id);
            if (tarea == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Tarea no encontrada",
                    result = ""
                });
            }

            try
            {
                _context.Tareas.Remove(tarea);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrio un error inesperado.",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Tarea eliminada.",
                result = ""
            });
        }
    }
}
