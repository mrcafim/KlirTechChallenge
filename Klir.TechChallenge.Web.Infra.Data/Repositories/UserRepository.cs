using Klir.TechChallenge.Web.Domain.User.Entities;
using Klir.TechChallenge.Web.Domain.User.Queries.Results;
using Klir.TechChallenge.Web.Domain.User.Repositories;
using Klir.TechChallenge.Web.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klir.TechChallenge.Web.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public User GetById(Guid id)
        {
            return _context
                .Users
                .Include(x => x.Cart)
                .FirstOrDefault(x => x.Id == id);
        }

        public bool EmailExists(string email)
        {
            return _context
                .Users
                .Any(x => x.Email == email && !x.Deleted);
        }

        public bool UserExists(string email, Guid id)
        {
            return _context
                .Users
                .Any(x => x.Email == email && x.Id != id && !x.Deleted);
        }
        public IEnumerable<UserQueryResult> GetUser()
        {
            return _context
                .Users
                .AsNoTracking()
                .Include(x => x.Cart)
                .Where(x => x.Active == true && !x.Deleted)
                .Select(x => new UserQueryResult
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    Email = x.Email,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,

                })
                .ToList();
        }

        public UserQueryResult GetByUser(Guid id)
        {
            var user = _context
                .Users
                .AsNoTracking()
                .Include(x => x.Cart)
                .ThenInclude(x => x.Items)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Promotion)
                .Where(x => !x.Deleted)
                .Select(x => new UserQueryResult
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    Email = x.Email,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    CartId = x.CartId,
                })
                .FirstOrDefault(x => x.Id == id);

            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
