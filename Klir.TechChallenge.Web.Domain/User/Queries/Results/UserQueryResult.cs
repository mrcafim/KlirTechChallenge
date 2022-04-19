using Klir.TechChallenge.Web.Domain.User.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.User.Queries.Results
{
    public class UserQueryResult
    {
        public Guid Id { get; set; }
        public UserRole Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? CartId { get; set; }
    }
}
