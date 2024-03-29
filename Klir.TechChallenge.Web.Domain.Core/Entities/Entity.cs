﻿using System;

namespace Klir.TechChallenge.Web.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
