using ECommerce_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ECommerceAppContext _db;

        public ProductRepository(ECommerceAppContext db)
        {
            _db = db;
        }
        //get products
        public async Task<List<Products>> GetProducts()
        {
            if (_db != null)
            {
                return await _db.Products.ToListAsync();
            }
            return null;
        }
        //getproductbyid
        public async Task<Products> GetProductById(int id)
        {
            var user = await _db.Products.SingleOrDefaultAsync(u => u.ProductId == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        //Add product
        public async Task<Products> AddProduct(Products product)
        {
            //--- member function to add product ---//
            if (_db != null)
            {
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return product;
            }
            return null;

        }
        //Update product
        public async Task<Products> UpdateProduct(Products product)
        {
            //member function to update product
            if (_db != null)
            {
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return product;
            }
            return null;
        }
        //Delete product
        public async Task<Products> UpdateProductByActive(int id)
        {
            //member function to delete product
            if (_db != null)
            {
                Products product = await _db.Products.FirstOrDefaultAsync(em => em.ProductId == id);
                product.Isactive = false;
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return product;
            }
            return null;
        }

    }
}
