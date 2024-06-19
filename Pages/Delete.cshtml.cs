using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelExamen.ContextModels;
using ModelExamen.Models;

namespace ModelExamen.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Zbor Zbor { get; set; }
        private readonly ProiectDBContext _dbContext;

        public DeleteModel(ProiectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(int zborId)
        {
            Zbor = _dbContext.Zboruri.Include(zbor => zbor.Pilot).FirstOrDefault(zbor => zbor.ZborId == zborId);
            if (Zbor == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost(int zborId)
        {
            var zborToDelete = _dbContext.Zboruri.Find(zborId);
            if (zborToDelete == null)
            {
                return RedirectToPage("/Error");
            }

            _dbContext.Zboruri.Remove(zborToDelete);
            _dbContext.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
