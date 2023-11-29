using userMicroService.Data.Contract.Repository;
using userMicroService.Data.Contract.Services;
using userMicroService.Data.Dto.Incomming;
using userMicroService.Data.Dto.Outcomming;
using userMicroService.Data.Managers;
using userMicroService.Entities;


namespace userMicroService.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IUserManager _userManager;

        private readonly IIdentityService _identityService;

        public UserService(IUserRepository userRepository, IUserManager userManager, IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserRead> SignIn(SignInModel userLogin)
        {
            try
            {
                User fetchedUser = await _userRepository.FindByEmail(userLogin.Email) ?? throw new Exception("Utilisateur Non trouvé");
                bool comparedPassword = _userManager.VerifyPassword(userLogin.Password, fetchedUser.Password);

                if(comparedPassword)
                {
                    UserRead convertedUser = _userManager.ConvertToRead(fetchedUser, _identityService.GenerateToken(fetchedUser));
                    return convertedUser;
                } else
                {
                    throw new Exception("Mot de passe incorrect");
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Create(SignUpModel userCreate)
        {
            SignUpModel cryptedPasswordUser = _userManager.CryptPassword(userCreate);
            try
            {
                User createdUser = await _userRepository.Insert(cryptedPasswordUser);
                return createdUser;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
