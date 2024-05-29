using System;
using System.Collections.Generic;

namespace GProyectosEmpleados.Models;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public int? EmpleadoIdEmpleado { get; set; }

    public int? ProyectoIdProyecto { get; set; }

    public virtual Empleado? EmpleadoIdEmpleadoNavigation { get; set; }

    public virtual Proyecto? ProyectoIdProyectoNavigation { get; set; }
}
