using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trasportistas_vista.Models
{
    public partial class Trasportistum
    {
        public int Id { get; set; }
        [MaxLength(3)]
        [Display(Name = "Código de transportista")]
        public string? Codigo { get; set; } = null!;
        [Display(Name = "Nombre de la empresa")]
        [MaxLength(30)]
        public string Nombre { get; set; } = null!;
    }
}
