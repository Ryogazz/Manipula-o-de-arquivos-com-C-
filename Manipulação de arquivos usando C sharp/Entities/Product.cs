using System;
using System.Collections.Generic;
using System.Text;

namespace Manipulação_de_arquivos.Entities
{
    class Product
    {
        public string Name { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; }

        Product()
        {
        }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double total()
        {
            return Price * Quantity;
        }
    }
}
