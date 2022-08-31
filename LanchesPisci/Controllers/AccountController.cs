using LanchesPisci.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LanchesPisci.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManeger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManeger = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            //Se o model state n estiver válido, retorno para a page de login com os erros.
            if(!ModelState.IsValid)
                return View(loginVM);

            //tentando localizar o usuário, para ver se ele já foi registrado na tabela de usuários do Identity.
            var user = await _userManeger.FindByNameAsync(loginVM.UserName);

            //se o usuário não for nulo eu tento fazer o login.
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Falha ao tentar realizar o login!");

            return View(loginVM.ReturnUrl);
        }
    }
}
