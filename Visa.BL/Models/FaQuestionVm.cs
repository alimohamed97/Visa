using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visa.DAL.Entity;

namespace Visa.BL.Models
{
    public class FaQuestionVm
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

        public int LandingId { get; set; }

        public bool? IsDeleted { get; set; }

        //NavigationProperty

        public Landing? Landing { get; set; }
    }
}
