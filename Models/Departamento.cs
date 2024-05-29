using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GProyectosEmpleados.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [JsonIgnore]
    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
