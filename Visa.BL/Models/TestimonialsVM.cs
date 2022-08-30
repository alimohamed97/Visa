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
    public class TestimonialsVM
    {
        public int Id { get; set; }

       
        public string Title_Ar { get; set; }

        
        public string Title_En { get; set; }
        
        public string ImageName { get; set; }
        public IFormFile ?Image { get; set; }
      
        public string CustomerName { get; set; }
    }
}
