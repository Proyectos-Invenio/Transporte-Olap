using CUBOOLAP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Authorize(Roles = "AnalistaDeDatos")]
public class AnalistaController : Controller
{
    private readonly ApplicationDbContext _context;

    public AnalistaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Panel del Analista
    public IActionResult AnalystDashboard()
    {
        return View();
    }

    // Acción para crear reportes
    public IActionResult CreateReport()
    {
        var reportData = _context.Servicios_Transporte.ToList();
        return View(reportData);
    }

    // Acción para generar gráficos filtrados por estado
    public IActionResult GenerateChart(string estado)
    {
        if (string.IsNullOrEmpty(estado))
        {
            estado = "Completado"; // Si no se selecciona un estado, por defecto usamos 'Completado'
        }

        var chartData = _context.Servicios_Transporte
            .Where(s => s.Estado == estado)
            .GroupBy(s => s.ID_Cliente)
            .Select(g => new {
                Cliente = g.Key,
                TotalCosto = g.Sum(s => s.Costo)
            }).ToList();

        return Json(chartData);
    }

    // Acción para buscar reportes por ID del servicio
    public IActionResult SearchByServiceId(int? idServicio)
    {
        if (idServicio.HasValue)
        {
            var reportes = _context.Servicios_Transporte
                .Where(s => s.ID_Servicio == idServicio)
                .ToList();

            return View("CreateReport", reportes);
        }

        return RedirectToAction("CreateReport");
    }
}
