using SupplyWinApp.Domain.Entities;

namespace SupplyWinApp.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByCredentialsAsync(string username, string password);
}
