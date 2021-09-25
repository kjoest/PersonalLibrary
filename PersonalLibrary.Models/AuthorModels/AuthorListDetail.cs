using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Models.AuthorModels
{
    public class AuthorListDetail
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { var fullName = FirstName + LastName; return fullName; } }
        //   public virtual List<Book> Books { get; set; }
    }
}
