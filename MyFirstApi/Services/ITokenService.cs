namespace MyFirstApi.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}