using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Visa.BL.Models
{
    public class AboutVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Arabic title required")]
        public string Title_Ar { get; set; }

        [Required(ErrorMessage = "English title required")]
        public string Title_En { get; set; }

        [Required(ErrorMessage = "Image required")]
        public string ImageName { get; set; }
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Arabic header required")]
        public string Header_Ar { get; set; }

        [Required(ErrorMessage = "English header required")]
        public string Header_En { get; set; }

        [Required(ErrorMessage = "Arabic description required")]
        public string Description_Ar { get; set; }

        [Required(ErrorMessage = "English description required")]
        public string Description_En { get; set; }

    }
}
