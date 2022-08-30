using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    [Table("Landing")]
    public class Landing
    {
        public int Id { get; set; }

        public string TitleAr { get; set; }

        public string TitleEn { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }

        public string ImageName { get; set; }

        public string VideoTitleAr { get; set; }


        public string VideoTitleEn { get; set; }

        public string VedioUrl { get; set; }
        public bool? IsDeleted { get; set; }

     
        public int CountryId { get; set; }


        public ICollection<FaQuestion>? FaQuestion { get; set; }
        public ICollection<StampedVisa>? StampedVisa { get; set; }
    }
}
