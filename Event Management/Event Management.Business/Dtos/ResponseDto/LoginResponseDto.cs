using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Business.Dtos.ResponseDto
{
    public class LoginResponseDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JwtToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public List<string> Roles { get; set; }
    }
}
