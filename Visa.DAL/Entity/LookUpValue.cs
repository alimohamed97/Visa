using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    [Table("LookUpValue")]
    public class LookUpValue
    {
        public int Id { get; set; }

        [Required]
        public string Name_Ar { get; set; }

        [Required]
        public string Name_En { get; set; }
        [Required]
        [ForeignKey("LookUp")]
        public int ParentId { get; set; }
        public  LookUp LookUp { get; set; }
    }
}
