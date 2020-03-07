using Freelancer.UnitOfwork.Base;
using System.Data.Entity;

namespace Freelancer.UnitOfwork
{
    public class UnitOfWork : UnitOfWorkBase
    {
        public UnitOfWork(DbContext _db) : base(_db)
        {

        }
    }
}
