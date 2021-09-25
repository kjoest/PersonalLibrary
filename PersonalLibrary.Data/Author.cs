using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { var fullName = FirstName + " " + LastName; return fullName; } }

        public DateTime BirthDate { get; set; }

        //public virtual List<Book> Books { get; set; }
    }
}
