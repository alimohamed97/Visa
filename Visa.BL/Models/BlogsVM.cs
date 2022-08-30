using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visa.DAL.Entity;

namespace Visa.BL.Models
{
    public class BlogsVM
    {
        public int Id { get; set; }


        public string Title_Ar { get; set; }


        public string Title_En { get; set; }
        public string Text_Ar { get; set; }


        public string Text_En { get; set; }
        public string ImageName { get; set; }
        public IFormFile? Image { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
