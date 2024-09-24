using Bogus;
using CUBOOLAP.Data;
using CUBOOLAP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Administrador")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Vista del panel de administración
    public IActionResult Dashboard()
    {
        var datos = _context.Servicios_Transporte.ToList();
        return View(datos);
    }

    // Acción para generar datos falsos
    public async Task<IActionResult> GenerateFakeData()
    {
        var faker = new Faker<ServiciosTransporte>()
            .RuleFor(d => d.ID_Cliente, f => f.Random.Int(1, 100))
            .RuleFor(d => d.ID_Vehiculo, f => f.Random.Int(1, 50))
            .RuleFor(d => d.ID_Conductor, f => f.Random.Int(1, 30))
            .RuleFor(d => d.ID_Ruta, f => f.Random.Int(1, 10))
            .RuleFor(d => d.Fecha_Salida, f => f.Date.Past())
            .RuleFor(d => d.Fecha_Llegada, f => f.Date.Soon())
            .RuleFor(d => d.Estado, f => f.Random.ListItem(new List<string> { "Activo", "Completado", "En Progreso" }))
            .RuleFor(d => d.Costo, f => f.Finance.Amount(100, 10000))
            .RuleFor(d => d.Peso_Carga, f => f.Random.Decimal(500, 20000))
            .RuleFor(d => d.Descripcion_Carga, f => f.Lorem.Sentence());

        List<ServiciosTransporte> fakeData = new List<ServiciosTransporte>();

        for (int i = 0; i < 10; i++)
        {
            fakeData.Add(faker.Generate());
        }

        _context.Servicios_Transporte.AddRange(fakeData);
        await _context.SaveChangesAsync();

        return RedirectToAction("Dashboard");
    }

    // Vista para editar un dato
    public IActionResult EditData(int id)
    {
        var data = _context.Servicios_Transporte.FirstOrDefault(d => d.ID_Servicio == id);
        if (data == null) return NotFound();
        return View(data);
    }

    // POST: Actualizar un dato
    [HttpPost]
    public async Task<IActionResult> EditData(ServiciosTransporte data)
    {
        if (ModelState.IsValid)
        {
            var existingData = await _context.Servicios_Transporte.FirstOrDefaultAsync(d => d.ID_Servicio == data.ID_Servicio);
            if (existingData != null)
            {
                existingData.ID_Cliente = data.ID_Cliente;
                existingData.ID_Vehiculo = data.ID_Vehiculo;
                existingData.ID_Conductor = data.ID_Conductor;
                existingData.ID_Ruta = data.ID_Ruta;
                existingData.Fecha_Salida = data.Fecha_Salida;
                existingData.Fecha_Llegada = data.Fecha_Llegada;
                existingData.Estado = data.Estado;
                existingData.Costo = data.Costo;
                existingData.Peso_Carga = data.Peso_Carga;
                existingData.Descripcion_Carga = data.Descripcion_Carga;

                _context.Update(existingData);
                await _context.SaveChangesAsync();

                return RedirectToAction("Dashboard");
            }
        }

        return View(data);
    }
}
