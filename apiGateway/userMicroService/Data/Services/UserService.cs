using AutoMapper;
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

        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUserManager userManager, IIdentityService identityService, IMapper mapper)
        {
            _userManager = userManager;
            _identityService = identityService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int userId)
        {
            User user = await _userRepository.FindById(userId);
            return user;
        }

        public async Task<UserRead> SignIn(SignInModel userLogin)
        {
            try
            {
                User fetchedUser = await _userRepository.FindByEmail(userLogin.Email) ?? throw new Exception("Utilisateur Non trouvé");
                bool comparedPassword = _userManager.VerifyPassword(userLogin.Password, fetchedUser.Password);

                if(comparedPassword)
                {
                    UserRead convertedUser = _mapper.Map<UserRead>(fetchedUser);
                    return convertedUser;
                } else
                {
                    throw new Exception("Mot de passe incorrect");
                }
            }   catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Missing test
        public User UpdateUser(User user)
        {
            try
            {
                return _userRepository.Update(user);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        //Missing test
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
