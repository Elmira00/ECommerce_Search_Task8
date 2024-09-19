using ECommerce.Entities.Models;

namespace ECommerce.WebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category>? Categories { get; set; }
        public int CurrentCategory { get; set; }
        public bool IsAdmin { get; internal set; }
    }
}