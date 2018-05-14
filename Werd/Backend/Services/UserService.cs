using System.Collections.Generic;
using Backend.Entities;
using Backend.Repositories;

namespace Backend.Services
{
    public class UserService
    {
        private readonly WerdRepository _repository;

        public UserService()
        {
            _repository = new WerdRepository();
        }

        public IEnumerable<User> Get()
        {
            var users = _repository.GetUsers();

            return users;
        }

        public User Get(int id)
        {
            return _repository.GetUser(id);
        }
    }
}