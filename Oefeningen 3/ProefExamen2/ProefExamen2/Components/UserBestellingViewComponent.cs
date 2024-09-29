using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProefExamen2.Data;


namespace ProefExamen2.Components
{
    public class UserBestellingViewComponent : ViewComponent
    {
        private SignInManager<IdentityUser> _signInManager;
        private AppDbContext _context;

        public UserBestellingViewComponent(SignInManager<IdentityUser> signInManager, AppDbContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
            var bestellingen = _context.Bestellingen.Where(b => b.IdentityUserId == user.Id).ToList();
            return View(bestellingen);
        }
    }
}
