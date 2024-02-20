using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Models;
using Portfolio.Services;
using static Portfolio.Models.Project;

namespace Portfolio.Pages.Admin.Projects
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProjectDto ProjectDto { get; set; } = new ProjectDto();

        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet()
        {

        }

        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {
            if (ProjectDto.ImageFile == null)
            {
                ModelState.AddModelError("ProjectDto.ImageFile", "The image File is required");
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(ProjectDto.ImageFile!.FileName);
            string imageFullPath = environment.WebRootPath + "/Project/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                ProjectDto.ImageFile.CopyTo(stream);
            }
            Project project = new Project()
            {
                Name = ProjectDto.Name,
                Description = ProjectDto.Description ?? "",
                Category = ProjectDto.Category,
                LinkReview = ProjectDto.LinkReview ?? "",
                LinkPlay = ProjectDto.LinkPlay ?? "",
                ImageFileName = newFileName,
                IsHighlighted = ProjectDto.IsHighlighted,
            };
            context.Projects.Add(project);
            context.SaveChanges();

            ProjectDto.Name = "";
            ProjectDto.Description = "";
            ProjectDto.Category = "";
            ProjectDto.LinkReview = "";
            ProjectDto.LinkPlay = "";
            ProjectDto.ImageFile = null;
            ProjectDto.IsHighlighted = false;
            ModelState.Clear();

            successMessage = "Project Created Succesfully";

            Response.Redirect("/Admin/Projects");


        }
    }
}
