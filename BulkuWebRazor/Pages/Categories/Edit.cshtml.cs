using BulkuWebRazor.Data;
using BulkyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkuWebRazor.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            _db.Categories.Update(Category);
            _db.SaveChanges();

            TempData["success"] = "Category updated successfully";

            return RedirectToPage("Index");
        }
    }
}
