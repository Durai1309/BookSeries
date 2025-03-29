using BookSeries.Web.Models;
using BookSeries.Web.Service.IService;
using BookSeries.Web.Utility;

namespace BookSeries.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> AssignRoleAsync(RegistrationRequest registrationRequest)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequest,
                Url = SD.AuthAPIBase + "/api/auth/AssignRole"
            });
        }

        public async Task<Response?> LoginAsync(LoginRequest loginRequestDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/login"
            }, withBearer: false);
        }

        public async Task<Response?> RegisterAsync(RegistrationRequest registrationRequestDto)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}