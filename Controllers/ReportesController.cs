using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using Trasportistas_vista.Models;

namespace Trasportistas_vista.Controllers
{
    public class ReportesController : Controller
    {
        private readonly BD_TRASPORTISTASContext _context;
        public ReportesController(BD_TRASPORTISTASContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Clientes()
        {
            // Define la URL de la Cabecera 
            string _headerUrl = Url.Action("HeaderPDF", "Reportes", null, "https");
            // Define la URL del Pie de página
            string _footerUrl = Url.Action("FooterPDF", "Reportes", null, "https");

            return new ViewAsPdf("Clientes", await _context.Clientes.ToListAsync())
            {
                // Establece la Cabecera y el Pie de página
                CustomSwitches = "--header-html " + _headerUrl + " --header-spacing 13 " +
                             "--footer-html " + _footerUrl + " --footer-spacing 0"
            ,
                PageMargins = new Margins(70, 10, 12, 10)
            };
        }
        public async Task<IActionResult> Articulos()
        {
            // Define la URL de la Cabecera 
            string _headerUrl = Url.Action("HeaderPDF", "Reportes", null, "https");
            // Define la URL del Pie de página
            string _footerUrl = Url.Action("FooterPDF", "Reportes", null, "https");

            return new ViewAsPdf("Articulos", await _context.ArticuloCustodia.ToListAsync())
            {
                // Establece la Cabecera y el Pie de página
                CustomSwitches = "--header-html " + _headerUrl + " --header-spacing 13 " +
                             "--footer-html " + _footerUrl + " --footer-spacing 0"
            ,
                PageMargins = new Margins(70, 10, 12, 10)
            };
        }
        public IActionResult HeaderPDF()
        {
            return View("HeaderPDF");
        }

        public IActionResult FooterPDF()
        {
            return View("FooterPDF");
        }
    }
}
