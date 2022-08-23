using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trasportistas_vista.Models
{
    public partial class ArticuloCustodium
    {
        public int Id { get; set; }
        [Display(Name = "Código de transportista")]
        public string? TrasportistaCodigo { get; set; }
        [Display(Name = "Tracking ID")]
        [StringLength(18)]
        public string? TrakingId { get; set; }
        [Display(Name = "Descripción del artículo")]
        [StringLength(100)]
        public string? Descripcion { get; set; }
        [Display(Name = "Peso")]
        public decimal? Peso { get; set; }
        [Display(Name = "Precio del artículo")]
        public decimal? Precio { get; set; }
        [Display(Name = "Código de cliente")]
        public string? ClienteCodigo { get; set; }
        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        public DateTime? FechaIngreso { get; set; }
    }
}
