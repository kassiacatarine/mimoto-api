using System.Collections.Generic;
using System.Linq;
using Mimoto.Domain.Common;
using Mimoto.Infrastructure;
using Mimoto.Infrastructure.Data;
using MongoDB.Driver;

namespace Mimoto.Application.Services.Common
{
    public class UserService
    {
        private readonly IMimotoContext _context;

        public UserService(IMimotoContext context) {
            _context = context;
        }

        public List<User> Get()
        {
            return _context.Users.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _context.Users.Find<User>(user => user.Id == id).FirstOrDefault();
        }

        public User VerifySignIn(string email, string pass)
        {
            return _context.Users.Find<User>(user => user.Email == email &&
                user.Password == pass).FirstOrDefault();    
        }

        public User Create(User user)
        {
            _context.Users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            _context.Users.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(User userIn)
        {
            _context.Users.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            _context.Users.DeleteOne(user => user.Id == id);
        }
    }
}
