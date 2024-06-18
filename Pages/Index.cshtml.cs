using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelExamen.ContextModels;
using ModelExamen.Models;
using System.Drawing;

namespace ModelExamen.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProiectDBContext _dbcontext;
        public Zbor[] Zboruri { get; set; }

        public IndexModel(ProiectDBContext DbContext)
        {
            _dbcontext = DbContext;
            Zboruri = Array.Empty<Zbor>();
        }

        public void OnGet()
        {
            Zboruri = _dbcontext.Zboruri.Include(zbor => zbor.Pilot).ToArray();
        }
    }
}
