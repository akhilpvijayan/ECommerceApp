using ECommerce_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Repositories
{
    public class OfferRepository : IOfferRepository
    {

        ECommerceAppContext _db;

        public OfferRepository(ECommerceAppContext db)
        {
            _db = db;
        }
        //get offers
        public async Task<List<Offers>> GetOffers()
        {
            if (_db != null)
            {
                return await _db.Offers.ToListAsync();
            }
            return null;
        }
        //getofferbyid
        public async Task<Offers> GetOfferById(int id)
        {
            var user = await _db.Offers.SingleOrDefaultAsync(u => u.Offerid == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}