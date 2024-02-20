using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Pages.Admin.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Projects/Index");
                return;
            }
            var project = context.Projects.Find(id);
            if (project == null)
            {
                Response.Redirect("/Admin/Projects/Index");
                return;
            }

            string imageFullPath = environment.WebRootPath + "/Project/" + project.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            context.Projects.Remove(project);
            context.SaveChanges();

            Response.Redirect("/Admin/Projects/Index");
        }
    }
}
