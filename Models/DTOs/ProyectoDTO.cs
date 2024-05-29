namespace GProyectosEmpleados.Models.DTOs
{
    public class ProyectoDTO
    {
        public string? Nombre { get; set; }

        public DateOnly? FechaInicio { get; set; }

        public DateOnly? FechaFinalizacion { get; set; }

        public int? DptoIdDpto { get; set; }
    }
}
