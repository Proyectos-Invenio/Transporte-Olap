using CUBOOLAP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;

[Authorize(Roles = "Gerente")]
public class GerenteController : Controller
{
    private readonly ApplicationDbContext _context;

    public GerenteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Panel del gerente
    public IActionResult ManagerDashboard()
    {
        return View();
    }

    // Ver reportes
    public IActionResult ViewReports()
    {
        var reportes = _context.Servicios_Transporte.ToList();
        return View(reportes);
    }

    // Ver gráficos basados en datos predefinidos
    public IActionResult ViewCharts()
    {
        var costosPorCliente = _context.Servicios_Transporte
            .GroupBy(s => s.ID_Cliente)
            .Select(g => new
            {
                ClienteId = g.Key,
                CostoTotal = g.Sum(s => s.Costo)
            })
            .ToList();

        ViewBag.ClienteIds = costosPorCliente.Select(c => "Cliente " + c.ClienteId).ToArray();
        ViewBag.Costos = costosPorCliente.Select(c => c.CostoTotal).ToArray();

        return View();
    }

    // Descargar informes
    public IActionResult DownloadReports()
    {
        var reportes = _context.Servicios_Transporte.ToList();
        var csv = new StringBuilder();
        csv.AppendLine("ID_Servicio,ID_Cliente,ID_Vehiculo,ID_Conductor,ID_Ruta,Fecha_Salida,Fecha_Llegada,Estado,Costo,Peso_Carga,Descripcion_Carga");

        foreach (var reporte in reportes)
        {
            csv.AppendLine($"{reporte.ID_Servicio},{reporte.ID_Cliente},{reporte.ID_Vehiculo},{reporte.ID_Conductor},{reporte.ID_Ruta},{reporte.Fecha_Salida},{reporte.Fecha_Llegada},{reporte.Estado},{reporte.Costo},{reporte.Peso_Carga},{reporte.Descripcion_Carga}");
        }

        return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "InformeTransporte.csv");
    }

    // Buscar reportes por estado
    public IActionResult SearchByStatus(string estado)
    {
        var reportes = _context.Servicios_Transporte
            .Where(s => s.Estado == estado)
            .ToList();

        return View("ViewReports", reportes);
    }

    // Buscar reportes por ID del servicio
    public IActionResult SearchByServiceId(int? idServicio)
    {
        if (idServicio.HasValue)
        {
            var reportes = _context.Servicios_Transporte
                .Where(s => s.ID_Servicio == idServicio)
                .ToList();

            return View("ViewReports", reportes);
        }

        return RedirectToAction("ViewReports");
    }
}
