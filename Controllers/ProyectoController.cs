using GProyectosEmpleados.Models.DTOs;
using GProyectosEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GProyectosEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProyectoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Proyecto
        [HttpGet]
        public IActionResult GetProyectos()
        {
            var proyectos = _context.Proyectos.ToList();

            List<ProyectoDTO> proyectosDTO = new List<ProyectoDTO>();

            foreach (var proyecto in proyectos)
            {
                ProyectoDTO proyectoDTO = new ProyectoDTO();
                proyectoDTO.Nombre = proyecto.Nombre;
                proyectoDTO.FechaInicio = proyecto.FechaInicio;
                proyectoDTO.FechaFinalizacion = proyecto.FechaFinalizacion;
                proyectoDTO.DptoIdDpto = proyecto.DptoIdDpto;

                proyectosDTO.Add(proyectoDTO);
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Listado de proyectos.",
                result = proyectosDTO
            });
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public IActionResult GetProyecto(int id)
        {
            var proyecto = _context.Proyectos.FirstOrDefault(e => e.IdProyecto == id);

            if (proyecto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Proyecto no encontrado",
                    result = ""
                });
            }

            ProyectoDTO proyectoDTO = new ProyectoDTO();
            proyectoDTO.Nombre = proyecto.Nombre;
            proyectoDTO.FechaInicio = proyecto.FechaInicio;
            proyectoDTO.FechaFinalizacion = proyecto.FechaFinalizacion;
            proyectoDTO.DptoIdDpto = proyecto.DptoIdDpto;

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Proyecto encontrado",
                result = proyectoDTO
            });
        }

        // PUT: api/Competencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCompetencia(int id, [FromBody] ProyectoDTO proyectoDTO)
        {
            var proyecto = _context.Proyectos.FirstOrDefault(e => e.IdProyecto == id);

            try
            {
                if (proyecto != null)
                {
                    proyecto.Nombre = proyectoDTO.Nombre;
                    proyecto.FechaInicio = proyectoDTO.FechaInicio;
                    proyecto.FechaFinalizacion = proyectoDTO.FechaFinalizacion;
                    proyecto.DptoIdDpto = proyectoDTO.DptoIdDpto;
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
                message = "Proyecto actualizado",
                result = ""
            });
        }

        // POST: api/Competencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostProyecto(ProyectoDTO proyectoDTO)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.Nombre = proyectoDTO.Nombre;
            proyecto.FechaInicio = proyectoDTO.FechaInicio;
            proyecto.FechaFinalizacion = proyectoDTO.FechaFinalizacion;
            proyecto.DptoIdDpto = proyectoDTO.DptoIdDpto;

            try
            {
                _context.Proyectos.Add(proyecto);
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
                message = "Proyecto agregado.",
                result = ""
            });
        }

        // DELETE: api/Competencias/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProyecto(int id)
        {
            var proyecto = _context.Proyectos.FirstOrDefault(e => e.IdProyecto == id);
            if (proyecto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Proyecto no encontrada",
                    result = ""
                });
            }

            try
            {
                _context.Proyectos.Remove(proyecto);
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
                message = "Proyecto eliminada.",
                result = ""
            });
        }
    }
}
