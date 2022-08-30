using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    [Table("Author")]

    public class Author
    {
        public int Id { get; set; }


        public string Name_Ar { get; set; }


        public string Name_En { get; set; }

        public string ImageName { get; set; }


        public string Brief_Ar { get; set; }
        public string Brief_En { get; set; }


    }
}
