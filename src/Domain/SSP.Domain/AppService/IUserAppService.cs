namespace SSP.Domain.AppService
{
    public interface IUserAppService
    {
        UserDomain GetUserByLogin(string email, string password);
    }
}