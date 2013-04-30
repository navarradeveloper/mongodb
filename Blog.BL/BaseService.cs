using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DA;

namespace Blog.BL
{
    public class BaseService : IDisposable
    {

        private IDAContext _context;

        protected IDAContext Context { get { return this._context; } }

        public BaseService(IDAContext da) {
            _context = da;
        }

        public void Dispose() {
            if (_context != null)
                _context.Dispose();
        }

    }
}
