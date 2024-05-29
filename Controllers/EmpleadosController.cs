using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GProyectosEmpleados.Models;
using GProyectosEmpleados.Models.DTOs;

namespace GProyectosEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpleadosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public IActionResult GetEmpleados()
        {
            var empleados = _context.Empleados.ToList();

            List<EmpleadoDTO> empleadosDTO = new List<EmpleadoDTO>();

            foreach (var empDTO in empleados)
            {
                EmpleadoDTO empleadoDTO = new EmpleadoDTO();
                empleadoDTO.NombreCompleto = empDTO.NombreCompleto;
                empleadoDTO.CorreoElectronico = empDTO.CorreoElectronico;
                empleadoDTO.FechaNacimiento = empDTO.FechaNacimiento;
                empleadoDTO.NumeroTelefono = empDTO.NumeroTelefono;
                empleadoDTO.DptoIdDpto = empDTO.DptoIdDpto;
                empleadoDTO.FechaContratación = empDTO.FechaContratación;
                empleadoDTO.Cargo = empDTO.Cargo;
                empleadoDTO.Salario = empDTO.Salario;

                empleadosDTO.Add(empleadoDTO);
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Listado de empleados.",
                result = empleadosDTO
            });
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public IActionResult GetEmpleado(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);

            if (empleado == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Empleado no encontrado",
                    result = ""
                });
            }

            EmpleadoDTO empleadoDTO = new EmpleadoDTO();
            empleadoDTO.NombreCompleto = empleado.NombreCompleto;
            empleadoDTO.CorreoElectronico = empleado.CorreoElectronico;
            empleadoDTO.FechaNacimiento = empleado.FechaNacimiento;
            empleadoDTO.NumeroTelefono = empleado.NumeroTelefono;
            empleadoDTO.DptoIdDpto = empleado.DptoIdDpto;
            empleadoDTO.FechaContratación = empleado.FechaContratación;
            empleadoDTO.Cargo = empleado.Cargo;
            empleadoDTO.Salario = empleado.Salario;

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Empleado encontrado",
                result = empleadoDTO
            });
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEmpleado(int id, [FromBody] EmpleadoDTO empleadoDTO)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);

            try
            {
                if (empleado != null)
                {
                    empleado.NombreCompleto = empleadoDTO.NombreCompleto;
                    empleado.CorreoElectronico = empleadoDTO.CorreoElectronico;
                    empleado.FechaNacimiento = empleadoDTO.FechaNacimiento;
                    empleado.NumeroTelefono = empleadoDTO.NumeroTelefono;
                    empleado.DptoIdDpto = empleadoDTO.DptoIdDpto;
                    empleado.FechaContratación = empleadoDTO.FechaContratación;
                    empleado.Cargo = empleadoDTO.Cargo;
                    empleado.Salario = empleadoDTO.Salario;
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
                message = "Empleado actualizado",
                result = ""
            });
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostEmpleado(EmpleadoDTO empleadoDTO)
        {
            Empleado empleado = new Empleado();
            empleado.NombreCompleto = empleadoDTO.NombreCompleto;
            empleado.CorreoElectronico = empleadoDTO.CorreoElectronico;
            empleado.FechaNacimiento = empleadoDTO.FechaNacimiento;
            empleado.NumeroTelefono = empleadoDTO.NumeroTelefono;
            empleado.DptoIdDpto = empleadoDTO.DptoIdDpto;
            empleado.FechaContratación = empleadoDTO.FechaContratación;
            empleado.Cargo = empleadoDTO.Cargo;
            empleado.Salario = empleadoDTO.Salario;

            try
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrio un error inesperado.",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Empleado agregado.",
                result = ""
            });
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    message = "Empleado no encontrado",
                    result = ""
                });
            }

            try
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Ocurrio un error inesperado.",
                    result = ""
                });
            }

            return StatusCode(StatusCodes.Status200OK, new
            {
                message = "Empleado eliminado.",
                result = ""
            });
        }
    }
}
