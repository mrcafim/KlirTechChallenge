using System;

namespace Klir.TechChallenge.Web.Domain.Core.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
        bool InTransaction { get; }
        void Begin();
        bool Commit();
        void Rollback();
    }
}
