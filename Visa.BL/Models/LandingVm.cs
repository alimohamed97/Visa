using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visa.DAL.Entity;

namespace Visa.BL.Models
{
    public class LandingVm
    {
        public int Id { get; set; }
        [Required]

        public string TitleAr { get; set; }
        [Required]

        public string TitleEn { get; set; }
        [Required]

        public string DescriptionAr { get; set; }
        [Required]

        public string DescriptionEn { get; set; }

        public string? ImageName { get; set; }
        [Required]

        public string VideoTitleAr { get; set; }
        

        public string VideoTitleEn { get; set; }
        public string VedioUrl { get; set; }


        public bool? IsDeleted { get; set; }

        [Required]
        public int CountryId { get; set; }

        public IFormFile Image { get; set; }

        public List<FaQuestionVm>? FaQuestion { get; set; }
        public List<StampedVisaVM>? StampedVisa { get; set; }
    }
}
