using Microsoft.AspNetCore.Mvc;
using CUBOOLAP.Data;
using CUBOOLAP.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ServiciosTransporteController : Controller
{
    private readonly ApplicationDbContext _context;

    public ServiciosTransporteController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var servicios = await _context.Servicios_Transporte.ToListAsync();  // Usar el DbSet correcto
        return View(servicios);
    }
}
