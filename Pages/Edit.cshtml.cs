using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelExamen.ContextModels;
using ModelExamen.Models;
using System.Drawing;

namespace ModelExamen.Pages
{
 
    public class EditModel : PageModel
    {
        [BindProperty]
        public Zbor Zbor { get; set; }
        public List<SelectListItem> Piloti { get; set; }
        public ProiectDBContext _dbContext { get; set; }
        public EditModel(ProiectDBContext dbContext)
        {
            _dbContext = dbContext;
            Piloti = _dbContext.Piloti.Select(pilot => new SelectListItem { Text = pilot.Nume, Value = pilot.Id.ToString() }).ToList();
        }

        public IActionResult OnGet(int zborId)
        {
            Zbor = new Zbor();
            Zbor = _dbContext.Zboruri.Include(zbor => zbor.Pilot).FirstOrDefault(zbor => zbor.ZborId == zborId);
            if(Zbor != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _dbContext.Zboruri.Update(Zbor);
            _dbContext.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
