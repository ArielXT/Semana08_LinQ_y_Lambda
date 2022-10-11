using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana08_Linq
{
    internal class Program
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            Joining();
            Console.Read();
        }

        static void IntroToLINQ()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            Func<int, bool> EsPar = i => i % 2 == 0;

            //var numQuery = from num in numbers where (num % 2) == 0 select num;

            var lambdanumQuery = numbers.Where(EsPar);

            foreach (int num in lambdanumQuery)
            {
                Console.Write("{0,1} ", num);
            }

        }

        static void DataSource()
        {
            //var queryAllCustomers = from cust in context.clientes select cust;

            var LambdaAllCustomers = context.clientes.Select(x=>x);

            foreach (var item in LambdaAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }

            //var queryAllCustomers2 = context.clientes.foreach()
        }

        static void Filtering()
        {
            //var queryLondonCustomers = from cust in context.clientes where cust.Ciudad == "Londres" select cust;

            var LambdaLondonCustomers = context.clientes.Where(x => x.Ciudad == "Londres");

            foreach (var item in LambdaLondonCustomers)
            {
                Console.WriteLine(item.Ciudad);
            }
        }

        static void Ordering()
        {
            //var queryLondonCustomers3 = from cust in context.clientes
                                        where cust.Ciudad == "London"
                                        orderby cust.NombreCompañia ascending
                                        select cust;

            var LambdaLondonCustomers3 = context.clientes.Where(x=> x.Ciudad == "London").OrderBy(x=> x.NombreCompañia);

            foreach (var item in LambdaLondonCustomers3)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void Grouping()
        {
            //var queryCustomerByCity = from cust in context.clientes group cust by cust.Ciudad;

            var LambdaCustomerByCity = context.clientes.GroupBy(x => x.Ciudad);

            foreach (var customerGroup in LambdaCustomerByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (clientes customer in customerGroup)
                {
                    Console.WriteLine("      {0}", customer.NombreCompañia);
                }
            }
        }

        static void Grouping2()
        {
            //var custQuery = from cust in context.clientes group cust by cust.Ciudad into custGroup where custGroup.Count() > 2 orderby custGroup.Key select custGroup;

            var LambdacustQuery = context.clientes.GroupBy(x => x.Ciudad).Where(y => y.Count() > 2).OrderBy(z => z.Key);

            foreach (var item in LambdacustQuery)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Joining()
        {
            //var innerJoinQuery = from cust in context.clientes join dist in context.Pedidos on cust.idCliente equals dist.IdCliente select new { CustomerName = cust.NombreCompañia, DistributorName = dist.PaisDestinatario };

            var LambdainnerJoinQuery = context.clientes.Join(context.Pedidos, cliente=> cliente.idCliente, pedido => pedido.IdCliente,
                (clientes, Pedidos) => new { CustomerName = clientes.NombreCompañia, DistributorName = Pedidos.PaisDestinatario});

            foreach (var item in LambdainnerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }
    }
}
