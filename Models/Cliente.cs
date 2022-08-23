using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trasportistas_vista.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        [Display(Name = "Código de cliente")]
        [MaxLength(5)]
        public string? Codigo { get; set; } = null!;
        [Display(Name = "Nombre completo")]
        [MaxLength(30)]
        public string? Nombre { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }
        [Display(Name = "Número de identificación")]
        [MaxLength(9)]
        public string? Identificacion { get; set; }
    }
}
