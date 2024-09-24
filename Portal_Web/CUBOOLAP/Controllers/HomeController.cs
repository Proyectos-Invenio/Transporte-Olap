using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Acción para mostrar la vista de inicio a todos
    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated) // Si el usuario está autenticado
        {
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);

            ViewBag.IsAdmin = roles.Contains("Administrador");
            ViewBag.IsGerente = roles.Contains("Gerente");
            ViewBag.IsAnalista = roles.Contains("AnalistaDeDatos");
        }

        return View(); // Carga el Home (Index) para todos los usuarios
    }
}
