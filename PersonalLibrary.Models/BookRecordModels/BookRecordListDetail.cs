using PersonalLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Models.BookRecordModels
{
    public class BookRecordListDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
