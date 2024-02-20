using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Pages.Admin.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public List<Project> Projects { get; set; } = new List<Project>();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void OnGet()
        {
            Projects = context.Projects.OrderByDescending(p => p.Id).ToList();
        }
    }
}
