namespace _07.Andrey_and_Billiard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var shop = new Dictionary<string, double>();
            var clientList = new List<Customers>();

            ReadShopItems(shop);

            GetOrders(shop, clientList);

            GetBill(shop, clientList);

            var sortedCustomer = clientList.OrderBy(x => x.Name).ThenBy(x => x.Bill).ToList();

            PrintBills(sortedCustomer);
        }

        private static void PrintBills(List<Customers> sortedCustomer)
        {
            foreach (var client in sortedCustomer)
            {
                var name = client.Name;
                var shopList = client.Orders;
                var bill = client.Bill;

                Console.WriteLine($"{name}");

                foreach (var order in shopList)
                {
                    Console.WriteLine($"-- {order.Key} - {order.Value}");
                }

                Console.WriteLine($"Bill: {bill:f2}");
            }

            Console.WriteLine("Total bill: {0:F2}", sortedCustomer.Sum(c => c.Bill));
        }

        private static void GetOrders(Dictionary<string, double> shop, List<Customers> clientList)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of clients")
                {
                    break;
                }

                var token = input.Split('-', ',').ToArray();
                var clientName = token[0];
                var product = token[1];
                var quantity = int.Parse(token[2]);

                if (shop.ContainsKey(token[1]))
                {
                    var client = new Customers();
                    client.Name = token[0];
                    client.Orders = new Dictionary<string, int>();
                    client.Orders.Add(product, quantity);

                    if (clientList.Any(c => c.Name == clientName))
                    {
                        var existingCustomer = clientList.First(c => c.Name == clientName);
                        if (existingCustomer.Orders.ContainsKey(product))
                        {
                            existingCustomer.Orders[product] += quantity;
                        }
                        else
                        {
                            existingCustomer.Orders[product] = quantity;
                        }
                    }
                    else
                    {
                        clientList.Add(client);
                    }
                }
            }
        }

        private static void GetBill(Dictionary<string, double> shop, List<Customers> clientList)
        {
            foreach (var client in clientList)
            {
                foreach (var item in client.Orders)
                {

                    foreach (var product in shop)
                    {
                        if (item.Key == product.Key) { client.Bill += item.Value * product.Value; }
                    }
                }
            }
        }

        private static void ReadShopItems(Dictionary<string, double> shop)
        {
            var numberOfGoods = int.Parse(Console.ReadLine());

            for (var i = 0; i < numberOfGoods; i++)
            {
                var input = Console.ReadLine().Split('-').ToArray();

                shop[input[0]] = double.Parse(input[1]);
            }
        }
    }

    class Customers
    {
        public double Bill { get; set; }

        public string Name { get; set; }

        public Dictionary<string, int> Orders { get; set; }
    }
}