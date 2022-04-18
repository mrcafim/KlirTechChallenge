using Klir.TechChallenge.Web.Domain.Core.Entities;
using Klir.TechChallenge.Web.Domain.User.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.User.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(UserRole type, string name, string email, string password)
        {
            Type = type;
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Active = true;
            Deleted = false;
        }

        public UserRole Type { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Guid? CartId { get; protected set; }
        public virtual Cart.Entitities.Cart Cart { get; protected set; }

        public void Deactivate()
        {
            Active = false;
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            Deleted = true;
            UpdatedAt = DateTime.Now;
        }

        public void SetCartId(Guid? cartId)
        {
            CartId = cartId;
        }

        public void UpdateUser(UserRole type, string name, string email, string password)
        {
            Type = type;
            Name = name;
            Email = email;
            Password = password;
            UpdatedAt = DateTime.Now;
        }

        public void EmptyCart()
        {
            CartId = null;
        }

    }
}
