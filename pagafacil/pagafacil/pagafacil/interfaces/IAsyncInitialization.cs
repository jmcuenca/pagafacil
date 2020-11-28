using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pagafacil.interfaces
{
    public interface IAsyncInitialization
    {
        Task Initialization { get; }
    }
}
