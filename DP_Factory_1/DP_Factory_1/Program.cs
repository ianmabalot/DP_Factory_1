using System;
using DP_Factory_1.Factory;
using DP_Factory_1.Cores;
using DP_Factory_1.Concrete;
using System.Threading.Tasks;

namespace DP_Factory_1
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                FactoryRegister factory = new FactoryRegister();

                //To register remitter customer
                IRegister registerRemitter = await factory?.ExecuteTask(CustomerType.Remitter);
                await registerRemitter.Register("Hello Customer Remitter!");

                //To register beneficiary customer
                IRegister registerBeneficiary = await factory?.ExecuteTask(CustomerType.Beneficiary);
                await registerBeneficiary.Register("Hello Customer Beneficiary!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
