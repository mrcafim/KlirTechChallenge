﻿using Klir.TechChallenge.Web.Domain.Cart.Queries.Results;
using System;

namespace Klir.TechChallenge.Web.Domain.Cart.Repositories
{
    public interface ICartRepository : IDisposable
    {
        Entities.Cart GetById(Guid id);
        void Add(Entities.Cart cart);
        void Update(Entities.Cart product);
        CartQueryResult GetByCart(Guid id);
    }
}
