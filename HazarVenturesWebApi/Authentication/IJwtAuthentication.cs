using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Authentication
{
    public interface IJwtAuthentication
    {
        string GenerateToken(UserDto user);
    }
}
