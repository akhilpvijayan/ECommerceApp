using ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Repositories
{
    public interface IProductRepository
    {
            //--- get product by id ---//
            Task<Products> GetProductById(int id);
            //--- get products ---//
            Task<List<Products>> GetProducts();
            //--- add product ---//
            Task<Products> AddProduct(Products patient);

            //--- update product ---//
            Task<Products> UpdateProduct(Products patient);
            //
            Task<Products> UpdateProductByActive(int id);
    }
}
