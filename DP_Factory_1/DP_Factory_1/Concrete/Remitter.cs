using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DP_Factory_1.Cores;

namespace DP_Factory_1.Concrete
{
    public class Remitter : IRegister
    {
        public Task Register(string customer)
        {
            return Task.Run(() => Console.WriteLine(customer));
        }
    }
}
