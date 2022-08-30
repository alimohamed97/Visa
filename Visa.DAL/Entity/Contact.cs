using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visa.DAL.Entity
{

    [Table("Contact")]
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Title_Ar { get; set; }

        [Required]
        public string Title_En { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string Branch_Name_Ar { get; set; }

        [Required]
        public string Branch_Name_En { get; set; }

        [Required]
        public string Branch_Address_Ar { get; set; }

        [Required]
        public string Branch_Address_En { get; set; }

        [Required]
        public string Branch_Phone { get; set; }

        [Required]
        public string Branch_Mail { get; set; }

    }
}
