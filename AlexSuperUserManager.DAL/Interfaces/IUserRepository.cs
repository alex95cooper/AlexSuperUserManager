using AlexSuperUserManager.DAL.Models;

namespace AlexSuperUserManager.DAL.Interfaces;

public interface IUserRepository
{
    Task<User> FindAsync(string nickName);

    Task<List<User>> GetAllAsync();

    Task CreateAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(User user);
}