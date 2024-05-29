namespace GProyectosEmpleados.Models.DTOs
{
    public class EmpleadoDTO
    {
        public string? NombreCompleto { get; set; }

        public string? CorreoElectronico { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public string? NumeroTelefono { get; set; }

        public int? DptoIdDpto { get; set; }

        public DateOnly? FechaContratación { get; set; }

        public string? Cargo { get; set; }

        public decimal? Salario { get; set; }
    }
}
