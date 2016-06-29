﻿using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine cartLine = lineCollection.FirstOrDefault(x => x.Product.ProductID == product.ProductID);

            if (cartLine == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Product.Price * x.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> CartLines
        {
            get
            {
                return lineCollection;
            }
        }
    }

    public class CartLine 
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
