using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    [Table("StampedVisa")]
    public class StampedVisa
    {
        public int Id { get; set; }
        [Required]

        public string TitleAr { get; set; }
        [Required]

        public string TitleEn { get; set; }
        [Required]

        public string ImageName { get; set; }
        [Required]


        public int LandingId { get; set; }

        [Required]

        public int StepId { get; set; }

        public bool? IsDeleted { get; set; }

        //navigationProperty
        public Landing Landing { get; set; }

        [ForeignKey("StepId")]
        public LookUpValue LookUpValue { get; set; }

    }
}
