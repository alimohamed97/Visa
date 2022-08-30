using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    [Table("Testimonials")]
    public class Testimonials
    {
        public int Id { get; set; }

       
        public string Title_Ar { get; set; }

       
        public string Title_En { get; set; }
       
        public string ImageName { get; set; }
      

        public string CustomerName { get; set; }

    }
}
