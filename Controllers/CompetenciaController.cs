using GProyectosEmpleados.Models.DTOs;
using GProyectosEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace GProyectosEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompetenciaController : ControllerBase
    {
        private readonly DataContext _context;

        public CompetenciaController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Competencias
        [HttpGet]
        public IActionResult GetCompetencias()
        {
            var competencias = _context.Competencias.ToList();

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Listado de Competencias.",
                result = competencias
            });
        }

        // GET: api/Competencias/5
        [HttpGet("{id}")]
        public IActionResult GetCompetencias(int id)
        {
            var competencia = _context.Competencias.FirstOrDefault(e => e.IdCompetencia == id);

            if (competencia == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Empleado no encontrado",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Competencia encontrado",
                result = competencia
            });
        }

        // PUT: api/Competencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCompetencia(int id, [FromBody] CompetenciaDTO competenciaDTO)
        {
            var competencia = _context.Competencias.FirstOrDefault(e => e.IdCompetencia == id);

            try
            {
                if (competencia != null)
                {
                    competencia.Nombre = competenciaDTO.Nombre;
                    competencia.Descripcion = competenciaDTO.Descripcion;
                    competencia.EmpleadoIdEmpleado = competenciaDTO.EmpleadoIdEmpleado;
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
                message = "Competencia actualizada",
                result = ""
            });
        }

        // POST: api/Competencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostCompetencia(CompetenciaDTO competenciaDTO)
        {
            Competencia competencia = new Competencia();
            competencia.Nombre = competenciaDTO.Nombre;
            competencia.Descripcion = competenciaDTO.Descripcion;
            competencia.EmpleadoIdEmpleado = competenciaDTO.EmpleadoIdEmpleado;

            try
            {
                _context.Competencias.Add(competencia);
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
                message = "Competencia agregada.",
                result = ""
            });
        }

        // DELETE: api/Competencias/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompetencia(int id)
        {
            var competencia = _context.Competencias.FirstOrDefault(e => e.IdCompetencia == id);
            if (competencia == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Competencia no encontrada",
                    result = ""
                });
            }

            try
            {
                _context.Competencias.Remove(competencia);
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
                message = "Competencia eliminada.",
                result = ""
            });
        }
    }
}
