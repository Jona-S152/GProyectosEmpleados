using System;
using System.Collections.Generic;

namespace GProyectosEmpleados.Models;

public partial class Competencia
{
    public int IdCompetencia { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? EmpleadoIdEmpleado { get; set; }

    public virtual Empleado? EmpleadoIdEmpleadoNavigation { get; set; }
}
