using System;

namespace BookHouseApp.BuisnessLogic.DTOS.Author
{
    public class UpdateAuthorDTO
    {
        public string AuthorName { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
