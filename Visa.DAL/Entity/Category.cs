using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visa.DAL.Entity
{
    [Table("Category")]

    public class Category
    {
        public int Id { get; set; }


        public string Title_Ar { get; set; }


        public string Title_En { get; set; }
    }
}
