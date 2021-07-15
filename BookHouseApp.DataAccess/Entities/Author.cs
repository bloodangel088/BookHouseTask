using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHouseApp.DataAccess.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string AuthorName { get; set; }
        [MaxLength(128)]
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> Books { get; set; }
    }
}
