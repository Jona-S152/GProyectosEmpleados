using GProyectosEmpleados.Models.DTOs;
using GProyectosEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GProyectosEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartamentoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Departamentos
        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            var departamentos = _context.Departamentos.ToList();

            List<DepartamentoDTO> departamentosDTO = new List<DepartamentoDTO>();

            foreach (var dptoDTO in departamentos)
            {
                DepartamentoDTO departamentoDTO = new DepartamentoDTO();
                departamentoDTO.Nombre = dptoDTO.Nombre;
                departamentoDTO.Descripcion = dptoDTO.Descripcion;



                departamentosDTO.Add(departamentoDTO);
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Listado de departamentos.",
                result = departamentosDTO
            });
        }

        // GET: api/departamentos/5
        [HttpGet("{id}")]
        public IActionResult GetDepartamento(int id)
        {
            var departamento = _context.Departamentos.FirstOrDefault(e => e.IdDepartamento == id);

            if (departamento == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Departamento no encontrado",
                    result = ""
                });
            }

            DepartamentoDTO departamentoDTO = new DepartamentoDTO();
            departamentoDTO.Nombre = departamento.Nombre;
            departamentoDTO.Descripcion = departamento.Descripcion;

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Departamento encontrado",
                result = departamentoDTO
            });
        }

        // PUT: api/departamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEmpleado(int id, [FromBody] DepartamentoDTO departamentoDTO)
        {
            var departamento = _context.Departamentos.FirstOrDefault(e => e.IdDepartamento == id);

            try
            {
                if (departamento != null)
                {
                    departamento.Nombre = departamentoDTO.Nombre;
                    departamento.Descripcion = departamentoDTO.Descripcion;
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
                message = "Departamento actualizado",
                result = ""
            });
        }

        // POST: api/departamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDepartamento(DepartamentoDTO departamentoDTO)
        {
            Departamento departamento = new Departamento();
            departamento.Nombre = departamentoDTO.Nombre;
            departamento.Descripcion = departamentoDTO.Descripcion;

            try
            {
                _context.Departamentos.Add(departamento);
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
                message = "Departamento agregado.",
                result = ""
            });
        }

        // DELETE: api/departamentos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartamento(int id)
        {
            var departamento = _context.Departamentos.FirstOrDefault(e => e.IdDepartamento == id);
            if (departamento == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Departamento no encontrado",
                    result = ""
                });
            }

            try
            {
                _context.Departamentos.Remove(departamento);
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
                message = "Departamento eliminado.",
                result = ""
            });
        }
    }
}
