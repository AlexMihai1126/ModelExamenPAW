using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelExamen.ContextModels;
using ModelExamen.Models;
using System.Drawing;

namespace ModelExamen.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Zbor Zbor { get; set; }
        public List<SelectListItem> Piloti { get; set; }
        public ProiectDBContext _dbContext { get; set; }
        public AddModel(ProiectDBContext dbContext)
        {
            _dbContext = dbContext;
            Piloti = _dbContext.Piloti.Select(pilot => new SelectListItem { Text = pilot.Nume, Value = pilot.Id.ToString() }).ToList();
        }
        public void OnGet()
        {
            Zbor = new Zbor();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _dbContext.Zboruri.Add(Zbor);
            _dbContext.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
