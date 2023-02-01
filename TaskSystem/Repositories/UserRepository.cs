using System;
using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.interfaces;

namespace TaskSystem.Repositories
{
	public class UserRepository : IUserRepository
	{
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
		{
            _dbContext = taskSystemDBContext;
		}

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel storedUser = await GetById(id);

            if (storedUser == null)
            {
                throw new Exception($"User from Id: {id} not found in database");
            }

            _dbContext.Users.Remove(storedUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel storedUser = await GetById(id);

            if (storedUser == null)
            {
                throw new Exception($"User from Id: {id} not found in database");
            }

            storedUser.Email = user.Email;
            storedUser.Name = user.Name;

            _dbContext.Users.Update(storedUser);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}

