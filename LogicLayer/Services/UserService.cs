using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Infrastructure;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await _database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName };
                var result = await _database.UserManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");

                // Add role
                await _database.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                // Create client profile
                ClientProfile clientProfile = new ClientProfile { ClientId = user.Id, Email = userDto.Email, UserName = userDto.UserName };
                _database.ClientManager.Create(clientProfile);

                await _database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // Find user
            ApplicationUser user = await _database.UserManager.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
                claim = await _database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await _database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await _database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}