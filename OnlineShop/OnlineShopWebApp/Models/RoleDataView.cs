using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RoleDataView
    {
        public string UserId { get; set; }
        public string CurrentName { get; set; }
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Введите корректное описание")]
        public string Description { get; set; }
        public List<SelectListItem> RoleSelectListItems { get; set; }
    }
}
