using Microsoft.AspNetCore.Mvc;
using ProefExamen2.Data;

namespace ProefExamen2.ViewComponents
{
    public class BeschikbaarViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public BeschikbaarViewComponent(AppDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var boeken = _context.Boeken.ToList();
            foreach (var boek in boeken)
            {
                var fileName = boek.Titel + ".jpg";
                var imageFile = Path.Combine(_environment.WebRootPath, "images", fileName);

                boek.Afbeelding = $"/Afbeelding/{fileName}";
            }
            return View(boeken);
        }


    }
}
