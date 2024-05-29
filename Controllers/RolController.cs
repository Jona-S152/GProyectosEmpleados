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
    public class RolController : ControllerBase
    {
        private readonly DataContext _context;

        public RolController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _context.Rols.ToList();

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Listado de roles.",
                result = roles
            });
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public IActionResult GetRol(int id)
        {
            var rol = _context.Rols.FirstOrDefault(e => e.IdRol == id);

            if (rol == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Rol no encontrado",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Rol encontrado",
                result = rol
            });
        }

        // PUT: api/Competencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutRol(int id, [FromBody] RolDTO rolDTO)
        {
            var rol = _context.Rols.FirstOrDefault(e => e.IdRol == id);

            try
            {
                if (rol != null)
                {
                    rol.Nombre = rolDTO.Nombre;
                    rol.Descripcion = rolDTO.Descripcion;
                    rol.EmpleadoIdEmpleado = rolDTO.EmpleadoIdEmpleado;
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
                message = "Rol actualizado",
                result = ""
            });
        }

        // POST: api/Competencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostRol(RolDTO rolDTO)
        {
            Rol rol = new Rol();
            rol.Nombre = rolDTO.Nombre;
            rol.Descripcion = rolDTO.Descripcion;
            rol.EmpleadoIdEmpleado = rolDTO.EmpleadoIdEmpleado;

            try
            {
                _context.Rols.Add(rol);
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
                message = "Rol agregado.",
                result = ""
            });
        }

        // DELETE: api/Competencias/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRol(int id)
        {
            var rol = _context.Rols.FirstOrDefault(e => e.IdRol == id);
            if (rol == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Rol no encontrado",
                    result = ""
                });
            }

            try
            {
                _context.Rols.Remove(rol);
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
                message = "Rol eliminado.",
                result = ""
            });
        }
    }
}
