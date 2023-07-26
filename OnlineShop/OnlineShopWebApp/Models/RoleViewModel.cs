using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CurrentName { get; set; }

        [Required(ErrorMessage = "Не указано Имя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Введите корректное название")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Введите корректное описание")]
        public string Description { get; set; }

        public List<SelectListItem> RoleSelectListItems { get; set; }
    }
}
