using System;
using System.ComponentModel.DataAnnotations;

namespace EgyptExcavation.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
