using Event_Management.Business.Dtos.RequestDto;
using Event_Management.Business.Dtos.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.Business.Services.IServices
{
    public interface IAuthService
    {
       Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
