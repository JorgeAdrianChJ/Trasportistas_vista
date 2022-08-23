using System;
using System.Collections.Generic;

namespace Trasportistas_vista.Models
{
    public partial class ArticuloRetirado
    {
        public int Id { get; set; }
        public string? TrasportistaCodigo { get; set; }
        public string? TrakingId { get; set; }
        public string? Descripcion { get; set; }
        public string? ClienteCodigo { get; set; }
        public DateTime? FechaRetiro { get; set; }
    }
}
