using ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Repositories
{
    public interface IOfferRepository
    {
        //--- get offer by id ---//
        Task<Offers> GetOfferById(int id);
        //--- get offers ---//
        Task<List<Offers>> GetOffers();
    }
}
