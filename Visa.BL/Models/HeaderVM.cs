using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Visa.BL.Models
{
    public class HeaderVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Arabic title required")]
        public string Title_Ar { get; set; }

        [Required(ErrorMessage = "English title required")]
        public string Title_En { get; set; }

        [Required(ErrorMessage = "Arabic description required")]
        public string Description_Ar { get; set; }

        [Required(ErrorMessage = "English description required")]
        public string Description_En { get; set; }

        //[Required(ErrorMessage = "English TESTIMONIALS required")]
        //public string TESTIMONIALS_En { get; set; }
        //[Required(ErrorMessage = " Arabic TESTIMONIALS required")]
        //public string TESTIMONIALS_Ar { get; set; }


        public string? ImageName { get; set; }

        public IFormFile? Image { get; set; }

    }
}
