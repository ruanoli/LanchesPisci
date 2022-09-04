using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesPisci.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();   
        }
    }
}
