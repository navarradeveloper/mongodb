using System;

namespace Blog.DA
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
