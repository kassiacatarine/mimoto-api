using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mimoto.Application.ViewModels.Common;
using Mimoto.Domain.Common;
using Mimoto.Infrastructure.Data;
using MongoDB.Driver;

namespace Mimoto.Application.Services.Common
{
    public class UserService
    {
        private readonly IMimotoContext _context;
        private readonly IMapper _mapper;

        public UserService(IMimotoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public User Create(UserProfileViewModel model)
        {
            var user = _mapper.Map<User>(model);
            _context.Users.InsertOne(user);
            return user;
        }

        public User Singup(UserSingupViewModel model)
        {
            var user = _mapper.Map<User>(model);
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
