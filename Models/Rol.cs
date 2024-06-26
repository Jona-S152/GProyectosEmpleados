﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GProyectosEmpleados.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? EmpleadoIdEmpleado { get; set; }

    [JsonIgnore]
    public virtual Empleado? EmpleadoIdEmpleadoNavigation { get; set; }
}
