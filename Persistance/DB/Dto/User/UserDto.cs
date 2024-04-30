using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.User
{
    public class UserDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required long PostalCode { get; set;}

        public required string Country { get; set;}

        public required string State {  get; set;}
        public required string City {  get; set;}

        public required string Street { get; set;}

        public required string Address {  get; set;}


    }
}
