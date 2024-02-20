using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Services;

namespace Portfolio.Pages.Admin.Account
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public string errorMessage = "";
        public string successMessage = "";
        public LoginModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string userName, string password)
        {
            var adminAccount = context.AdminAccounts
                .FirstOrDefault(a => a.UserName == userName && a.Password == password);

            if (adminAccount != null)
            {
                successMessage = "Login Succesfully";
                return RedirectToPage("/Admin/Projects/Index");
            }
            else
            {
                errorMessage = "Username or Password is incorrect.";
                return Page();
            }
        }
    }
}
