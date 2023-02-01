using System;
using TaskSystem.Models;

namespace TaskSystem.Repositories.interfaces
{
	public interface IUserRepository
	{
		Task<List<UserModel>> GetAllUsers();

		Task<UserModel> GetById(int id);

		Task<UserModel> UpdateUser(UserModel user, int id);

		Task<UserModel> AddUser(UserModel user);

		Task<bool> DeleteUser(int id);
	}
}

