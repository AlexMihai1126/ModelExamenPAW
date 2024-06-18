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
        private readonly ILogger<IndexModel> _logger;
        private readonly ProiectDBContext _dbcontext;
        public Zbor[] Zboruri { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Zboruri = _dbcontext.Zboruri.Include(zbor => zbor.Pilot).ToArray();
        }
    }
}
