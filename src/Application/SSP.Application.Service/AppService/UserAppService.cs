using SSP.Application.Service.Util;
using SSP.Domain;
using SSP.Domain.AppService;
using SSP.Domain.Repository;

namespace SSP.Application.Service.AppService
{
    public class UserAppService : IUserAppService
    {
        private IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        public UserDomain GetUserByLogin(string email, string password)
            => this._userRepository.GetUserByLogin(email, Encryption.MD5Encode(password));
    }
}