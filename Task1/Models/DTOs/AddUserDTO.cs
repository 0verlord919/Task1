using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Models.DTOs
{
    public class AddUserDTO
    {
        [Required(ErrorMessage ="FullName Required!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "GroupName Required!")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "Age Required!")]
        public int Age { get; set; }
    }
}
