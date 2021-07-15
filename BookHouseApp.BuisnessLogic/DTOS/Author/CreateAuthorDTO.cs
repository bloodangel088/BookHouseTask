using System;

namespace BookHouseApp.BuisnessLogic.DTOS.Author
{
    public class CreateAuthorDTO
    {
        public string AuthorName { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
