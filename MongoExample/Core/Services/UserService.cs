using MongoExample.Core.Models;
using MongoExample.Core.Repositories;

namespace MongoExample.Core.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    
    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User GetUser(string id){
        return _userRepository.GetById(id);
    }
    
    public List<User> GetUsers(){
        return _userRepository.GetUsers();
    }
    
    public void SaveUser(User user){
        _userRepository.InsertOne(user);
    }
    
    public void SaveUsers(IEnumerable<User> users){
        _userRepository.InsertMany(users);
    }
    
    public User DeleteUser(string id)
    {
        return _userRepository.DeleteOne(id);
    }
}