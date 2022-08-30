using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.BL.Models
{
    public class AuthorVM
    {
        public int Id { get; set; }


        public string Name_Ar { get; set; }


        public string Name_En { get; set; }

        public string ImageName { get; set; }
        public IFormFile? Image { get; set; }

        public string Brief_Ar { get; set; }
        public string Brief_En { get; set; }
    }
}
