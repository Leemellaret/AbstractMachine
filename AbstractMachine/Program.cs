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
            RangeDomain<int> domain = new RangeDomain<int>(0, 1);

            var tableBuilder = new TableMappingBuilder<int, int, int>();
            tableBuilder.AddRow((0, 0), (0, 0));
            tableBuilder.AddRow((0, 1), (1, 0));
            tableBuilder.AddRow((1, 0), (1, 1));
            tableBuilder.AddRow((1, 1), (0, 1));

            var table = new TableMapping<int, int, int>(tableBuilder);

            var abstractMachine = new AbstractMachine<int, int, int>(domain, domain, domain, table, new Information<int>(1, domain));

            Console.WriteLine($"a(0) = {abstractMachine.Process(new Information<int>(1, domain))}");
            Console.WriteLine($"a.CS = {abstractMachine.CurrentState}");
            Console.ReadLine();
        }
    }
}
