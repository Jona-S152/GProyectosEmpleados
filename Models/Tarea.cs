using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GProyectosEmpleados.Models;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public int? EmpleadoIdEmpleado { get; set; }

    public int? ProyectoIdProyecto { get; set; }
    
    [JsonIgnore]
    public virtual Empleado? EmpleadoIdEmpleadoNavigation { get; set; }

    [JsonIgnore]
    public virtual Proyecto? ProyectoIdProyectoNavigation { get; set; }
}
