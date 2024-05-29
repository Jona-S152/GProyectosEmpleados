using System;
using System.Collections.Generic;

namespace GProyectosEmpleados.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NombreCompleto { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? NumeroTelefono { get; set; }

    public int? DptoIdDpto { get; set; }

    public DateOnly? FechaContratación { get; set; }

    public string? Cargo { get; set; }

    public decimal? Salario { get; set; }

    public virtual ICollection<Competencia> Competencia { get; set; } = new List<Competencia>();

    public virtual Departamento? DptoIdDptoNavigation { get; set; }

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
