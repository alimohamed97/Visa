using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Visa.DAL.Entity
{

    [Table("Header")]
    public class Header
    {
        public int Id { get; set; }

        [Required]
        public string Title_Ar { get; set; }

        [Required]
        public string Title_En { get; set; }

        [Required]
        public string Description_Ar { get; set; }

        [Required]
        public string Description_En { get; set; }
        //[Required]
        //public string TESTIMONIALS_En { get; set; }

        //[Required]
        //public string TESTIMONIALS_Ar { get; set; }


        [Required]
        public string ImageName { get; set; }
    }
}
