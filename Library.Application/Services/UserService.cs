using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Application.Interfaces.InterfaceRepository;
using Library.Application.Interfaces.InterfaceService;
using Library.Entities;

namespace Library.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> CreateAsync(UserCreateDTO userDTO)
        {
            var emailExist = await _userRepository.GetByEmailAsync(userDTO.email);
            if (emailExist != null) return false;
            
            var user = new User
            {
                first_name = userDTO.first_name,
                second_name = userDTO.second_name,
                first_lastname = userDTO.first_lastname,
                second_lastname = userDTO.second_lastname,
                email = userDTO.email,
                phone_number = userDTO.phone_number
            };
            await _userRepository.CreateAsync(user);
            return true;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDTO
            {
                id_user = user.id,
                first_name = user.first_name,
                second_name = user.second_name,
                first_lastname = user.first_lastname,
                second_lastname = user.second_lastname,
                email = user.email,
                phone_number = user.phone_number,
                register_date = user.register_date
            });
        }

        public async Task<UserDTO?> GetByEmailAsync(string mail)
        {
            var user = await _userRepository.GetByEmailAsync(mail);
            if (user == null) return null;
            return new UserDTO
            {
                id_user = user.id,
                first_name = user.first_name,
                second_name = user.second_name,
                first_lastname = user.first_lastname,
                second_lastname = user.second_lastname,
                email = user.email,
                phone_number = user.phone_number,
                register_date = user.register_date
            };
        }

        public async Task<UserDTO?> GetByIdAsync(int id_user)
        {
            var user = await _userRepository.GetByIdAsync(id_user);
            if (user == null) return null;
            return new UserDTO
            {
                id_user = user.id,
                first_name = user.first_name,
                second_name = user.second_name,
                first_lastname = user.first_lastname,
                second_lastname = user.second_lastname,
                email = user.email,
                phone_number = user.phone_number,
                register_date = user.register_date
            };
        }

        public async Task<bool> UpdateAsync(UserUpdateDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(userDTO.id);
            if (user == null) return false;

            user.first_name = userDTO.first_name;
            user.second_name = userDTO.second_name;
            user.first_lastname = userDTO.first_lastname;
            user.second_lastname = userDTO.second_lastname;
            user.phone_number = userDTO.phone_number;
            user.email = userDTO.email;

            var email_exits = await _userRepository.GetByEmailAsync(userDTO.email);
            if (email_exits != null && email_exits.id != userDTO.id) return false;

            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
