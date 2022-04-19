using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.Core.Transactions;
using Klir.TechChallenge.Web.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Klir.TechChallenge.Web.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IBus _bus;
        private IDbContextTransaction _transaction;

        public bool InTransaction => _transaction != null;

        public UnitOfWork(DataContext context, IBus bus)
        {
            _context = context;
            _bus = bus;
        }

        public void Begin()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            try
            {
                var success = _context.SaveChanges() > 0;

                _transaction?.Commit();

                return success;
            }
            catch (Exception e)
            {
                _transaction?.Rollback();
                _bus.RaiseEvent(new DomainNotification("CommitChanges", e.InnerException != null ? e.InnerException.Message : e.Message));
                return false;
            }
            finally
            {
                _transaction = null;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction = null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
