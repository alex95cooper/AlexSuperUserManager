using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexSuperUserManager.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<User> FindAsync(string nickName)
    {
        return await _db.User.FirstOrDefaultAsync(
            user => user.NickName == nickName);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _db.User.ToListAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _db.User.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _db.User.Update(user);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _db.User.Remove(user);
        await _db.SaveChangesAsync();
    }
}