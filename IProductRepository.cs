﻿using System;
using System.Collections.Generic;



namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);

        public Product GetProduct(int id);

        public void UpdateProduct(Product product);

        public void DeleteProduct(int id);


    }
}

