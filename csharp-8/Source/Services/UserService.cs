using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Candidates
                .Where(candidate => candidate.Acceleration.Name == name)
                .Select(candidate => candidate.User)
                .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _context.Users
                .Where(user => user.Candidates.Any(candidate => candidate.CompanyId == companyId))
                .ToList();
        }

        public User FindById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Save(User user)
        {
            if (user.Id == 0)
            {
                _context.Add(user);
            }
            else
            {
                _context.Update(user);
            }

            _context.SaveChanges();
            return user;
        }
    }
}