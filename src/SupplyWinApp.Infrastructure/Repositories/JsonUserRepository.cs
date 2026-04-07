using System.Text.Json;
using SupplyWinApp.Domain.Entities;
using SupplyWinApp.Domain.Interfaces;

namespace SupplyWinApp.Infrastructure.Repositories;

public class JsonUserRepository : IUserRepository
{
    private readonly string _filePath;
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

    public JsonUserRepository(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<User?> GetByCredentialsAsync(string username, string password)
    {
        var json = await File.ReadAllTextAsync(_filePath);
        var users = JsonSerializer.Deserialize<List<User>>(json, JsonOptions) ?? [];

        return users.FirstOrDefault(u =>
            string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);
    }
}
