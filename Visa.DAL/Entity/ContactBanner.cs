using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{

    [Table("ContactBanner")]
    public class ContactBanner
    {
        public int Id { get; set; }

        [Required]
        public string Title_Ar { get; set; }

        [Required]
        public string Title_En { get; set; }

        [Required]
        public string ImageName { get; set; }
    }
}
