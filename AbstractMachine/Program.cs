using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new MappingAbstractMachineBuilder<Integer, Integer, Integer>().AddRangeToInputDomain(0, 1)
                                                                                        .AddRangeToOutputDomain(0, 1)
                                                                                        .AddRangeToStateDomain(0, 1)
                                                                                        .AddRow((0, 0), (0, 0))
                                                                                        .AddRow((0, 1), (1, 0))
                                                                                        .AddRow((1, 0), (1, 1))
                                                                                        .SetInitialState(1);

            var abstractMachine = builder.CreateInstance();
            var inputDomain = builder.GetInputDomainInstance();

            Console.WriteLine($"a(0) = {abstractMachine.Process(new Information<Integer>(0, inputDomain))}");
            Console.WriteLine($"a.CS = {abstractMachine.CurrentState}");

            //.AddRow((1, 1), (0, 1))

            var am2 = new MappingAbstractMachineBuilder<Integer, Integer, Integer>(abstractMachine).AddRow((1, 1), (0, 1)).CreateInstance();

            Console.WriteLine($"a(0) = {am2.Process(new Information<Integer>(1, inputDomain))}");
            Console.WriteLine($"a.CS = {am2.CurrentState}");
            Console.ReadLine();
        }
    }
}
