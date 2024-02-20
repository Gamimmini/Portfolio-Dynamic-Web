using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Pages.Admin.Projects
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProjectDto ProjectDto { get; set; } = new ProjectDto();

        public Project Project { get; set; } = new Project();
        public string errorMessage = "";
        public string successMessage = "";
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if(id == null)
            {
                Response.Redirect("/Admin/Projects");
                return;
            }
            var project = context.Projects.Find(id);
            if(project == null)
            {
                Response.Redirect("/Admin/Projects");
                return;
            }

            ProjectDto.Name = project.Name;
            ProjectDto.Description = project.Description;
            ProjectDto.Category = project.Category.ToString();
            ProjectDto.LinkReview = project.LinkReview;
            ProjectDto.LinkPlay = project.LinkPlay;
            ProjectDto.IsHighlighted = project.IsHighlighted;

            Project = project;
        }

        public void OnPost(int? id)
        {
            if(id == null)
            {
                Response.Redirect("/Admin/Projects");
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }
            var project = context.Projects.Find(id);
            if(project == null)
            {
                Response.Redirect("/Admin/Projects");
                return;
            }

            string newFileName = project.ImageFileName;
            if(ProjectDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(ProjectDto.ImageFile!.FileName);

                string imageFullPath = environment.WebRootPath + "/Project/" + newFileName;

                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    ProjectDto.ImageFile.CopyTo(stream);
                }

                string oldImageFullPath = environment.WebRootPath + "/Projects/" + project.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }

            project.Name = ProjectDto.Name;
            project.Description = ProjectDto.Description ?? "";
            project.Category = ProjectDto.Category;
            project.LinkReview = ProjectDto.LinkReview ?? "";
            project.LinkPlay = ProjectDto.LinkPlay ?? "";
            project.ImageFileName = newFileName;
            project.IsHighlighted = ProjectDto.IsHighlighted;

            context.SaveChanges();

            Project = project;

            successMessage = "Project updated successfully";

            Response.Redirect("/Admin/Projects");


        }

    }
}
