using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Visa.BL.Models
{
    public class ContactVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Arabic title required")]
        public string Title_Ar { get; set; }

        [Required(ErrorMessage = "English title required")]
        public string Title_En { get; set; }

        [Required(ErrorMessage = "Image required")]
        public string ImageName { get; set; }
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Arabic branch name required")]
        public string Branch_Name_Ar { get; set; }

        [Required(ErrorMessage = "English branch name required")]
        public string Branch_Name_En { get; set; }

        [Required(ErrorMessage = "Arabic branch address required")]
        public string Branch_Address_Ar { get; set; }

        [Required(ErrorMessage = "English branch address required")]
        public string Branch_Address_En { get; set; }

        [Required(ErrorMessage = "Branch phone required")]
        public string Branch_Phone { get; set; }

        [Required(ErrorMessage = "Branch email required")]
        [EmailAddress(ErrorMessage = "invalid email address")]
        public string Branch_Mail { get; set; }

    }
}
