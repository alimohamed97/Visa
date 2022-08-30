using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.BL.Models
{
    public class StepsVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Arabic title required")]
        public string Title_Ar { get; set; }

        [Required(ErrorMessage = "English title required")]
        public string Title_En { get; set; }

        [Required(ErrorMessage = "Image required")]
        public string ImageName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
