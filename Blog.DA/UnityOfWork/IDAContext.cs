using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DA
{
    public interface IDAContext : IDisposable
    {
        IPostRepository Post { get; }
        IUserRepository User { get; }
    }
}
