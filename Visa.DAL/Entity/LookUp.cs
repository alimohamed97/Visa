using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{

    [Table("LookUp")]

    public class LookUp
    {
            public int Id { get; set; }

            [Required]
            public string Name_En { get; set; }
    }
}
