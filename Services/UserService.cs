using UserManagementAPI.Models;

namespace UserManagementAPI.Services;

public class UserService : IUserService
{
    private static List<User> _users = new();
    private static int _nextId = 1;

    public UserService()
    {
        _users.Add(new User { Id = 1, Name = "Alice Johnson", Email = "alice@example.com", Age = 20 });
        _users.Add(new User { Id = 2, Name = "Bob Singh", Email = "bob@example.com", Age = 22 });
        _nextId = 3;
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User Create(User user)
    {
        var newUser = new User
        {
            Id = _nextId++,
            Name = user.Name,
            Email = user.Email,
            Age = user.Age
        };

        _users.Add(newUser);
        return newUser;
    }

    public bool Update(int id, User user)
    {
        var existing = _users.FirstOrDefault(u => u.Id == id);
        if (existing == null) return false;

        existing.Name = user.Name;
        existing.Email = user.Email;
        existing.Age = user.Age;
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _users.FirstOrDefault(u => u.Id == id);
        if (existing == null) return false;

        _users.Remove(existing);
        return true;
    }
}
