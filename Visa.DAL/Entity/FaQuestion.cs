using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    [Table("FaQuestion")]
    public class FaQuestion
    {

        public int Id { get; set; }
        [Required]
        public string QuestionAr { get; set; }
        [Required]

        public string QuestionEn { get; set; }
        [Required]

        public string AnswerAr { get; set; }
        [Required]

        public string AnswerEn { get; set; }
        [Required]

        [ForeignKey("Landing")]
        public int LandingId { get; set; }

        public bool? IsDeleted { get; set; }

        //NavigationProperty

        public Landing Landing { get; set; }
    }
}
