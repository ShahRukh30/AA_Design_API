using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto
{
    public class RoleDto
    {
        [Required] 
        public required string Rolename { get; set; }
    }
}
