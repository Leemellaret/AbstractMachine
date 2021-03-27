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
            var domain = DomainBuilder<Integer>.CreateEmptyBuilder()
                                               .AddRange(0, 1)
                                               .Build();


            var table = TableMappingBuilder<Integer, Integer, Integer>.CreateEmptyBuilder()
                                                                      .AddRow((0, 0), (0, 0))
                                                                      .AddRow((0, 1), (1, 0))
                                                                      .AddRow((1, 0), (1, 1))
                                                                      .AddRow((1, 1), (0, 1))
                                                                      .Build();


            var abstractMachine = new MappingAbstractMachine<Integer, Integer, Integer>(domain, domain, domain, table, new Information<Integer>(1, domain));

            Console.WriteLine($"a(0) = {abstractMachine.Process(new Information<Integer>(1, domain))}");
            Console.WriteLine($"a.CS = {abstractMachine.CurrentState}");
            Console.ReadLine();
        }
    }
}
