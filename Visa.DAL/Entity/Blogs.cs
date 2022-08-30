using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{

    [Table("Blogs")]
    public class Blogs
    {
        public int Id { get; set; }


        public string Title_Ar { get; set; }


        public string Title_En { get; set; }
        public string Text_Ar { get; set; }


        public string Text_En { get; set; }
        public string ImageName { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
