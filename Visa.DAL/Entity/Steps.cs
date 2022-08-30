using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    public class Steps
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
