using Klir.TechChallenge.Web.Domain.User.Queries.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.User.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<UserQueryResult> GetUser();
        Entities.User GetById(Guid id);
        UserQueryResult GetByUser(Guid id);
        bool EmailExists(string name);
        bool UserExists(string email, Guid id);
        void Add(Entities.User user);
        void Update(Entities.User user);
        void Delete(Entities.User user);
    }
}
