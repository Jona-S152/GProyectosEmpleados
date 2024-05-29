using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GProyectosEmpleados.Models;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFinalizacion { get; set; }

    public int? DptoIdDpto { get; set; }

    [JsonIgnore]
    public virtual Departamento? DptoIdDptoNavigation { get; set; }

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
