using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TokenBusiness.Abstract;
using TokenDAL.Context;
using TokenDAL.Security.Entity;
using TokenDAL.Security.Helper;
using TokenEntity.Dto.User;
using TokenEntity.Entity;

namespace TokenBusiness.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ITokenDbContext _context;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(ITokenDbContext context, ITokenHelper tokenHelper)
        {
            _context = context;
            _tokenHelper = tokenHelper;
        }

        public async Task<int> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var currentTime = DateTime.Now;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                IdentityNumber = userRegisterDto.IdentityNumber,
                Gender = userRegisterDto.Gender,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CDate = currentTime,
                UserRoles = new List<UserRole>
                {
                    new() {RoleId = userRegisterDto.UserRole, CDate = currentTime}
                }
            };
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<User> GetLoginUserAsync(UserLoginDto userLoginDto)
        {
            var currentUser = await _context.Users
                .Where(p => !p.IsDeleted && p.IdentityNumber == userLoginDto.IdentityNumber).FirstOrDefaultAsync();
            if (currentUser == null) return null;

            var passwordMatchResult = HashingHelper.VerifyPasswordHash(userLoginDto.Password, currentUser.PasswordHash,
                currentUser.PasswordSalt);
            //Pilot result for user result. Worked...
            return passwordMatchResult ? currentUser : new User();
        }

        public async Task<AccessToken> CreateAccessTokenAsync(User user)
        {
            var currentUserRoles = await GetUserRolesByUserIdAsync(user.Id);
            return currentUserRoles == null ? null : _tokenHelper.CreateToken(user, currentUserRoles);
        }

        private async Task<IEnumerable<Role>> GetUserRolesByUserIdAsync(int userId)
        {
            return await _context.UserRoles.Where(p => !p.IsDeleted && p.UserId == userId)
                .Include(p => p.RoleFk)
                .Select(p => p.RoleFk)
                .ToListAsync();
        }
    }
}