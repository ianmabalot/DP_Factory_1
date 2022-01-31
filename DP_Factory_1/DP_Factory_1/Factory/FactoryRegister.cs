using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using DP_Factory_1.Cores;
using System.Threading.Tasks;
using DP_Factory_1.Concrete;

namespace DP_Factory_1.Factory
{
    public enum CustomerType
    {
        Remitter = 0,
        Beneficiary = 1
    }

    public sealed class FactoryRegister
    {
        private readonly ConcurrentDictionary<CustomerType, Lazy<IRegister>> keyValuePairs = new ConcurrentDictionary<CustomerType, Lazy<IRegister>>();

        private readonly Task initializingTask = null;

        public FactoryRegister() => initializingTask = SetFactoriesAsync();

        private Task SetFactoriesAsync()
        {
            return Task.Run(() => {
                keyValuePairs.TryAdd(CustomerType.Remitter, new Lazy<IRegister>(() => new Remitter()));
                keyValuePairs.TryAdd(CustomerType.Beneficiary, new Lazy<IRegister>(() => new Beneficiary()));
            });
        }

        public async Task<IRegister> ExecuteTask(CustomerType customerType)
        {
            await initializingTask;

            return keyValuePairs[customerType].Value;
        }
    }
}
