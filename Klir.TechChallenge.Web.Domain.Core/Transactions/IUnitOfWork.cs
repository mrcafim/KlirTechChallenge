using System;
using System.Collections.Generic;
using System.Text;

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
