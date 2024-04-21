using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.User
{
    public class RegisterDto
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Passwordhash { get; set; }

    }
}
