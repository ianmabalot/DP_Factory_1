using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DP_Factory_1.Cores
{
    public interface IRegister
    {
        Task Register(string customer);
    }
}
