using ECommerce_App.Models;
using ECommerce_App.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        IOfferRepository offerRepository;
        public OffersController(IOfferRepository _p)
        {
            offerRepository = _p;
        }

        #region get offers
        [HttpGet]
        [ProducesResponseType(typeof(Offers), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetOffers()
        {
            var offers = await offerRepository.GetOffers();
            if (offers == null)
            {
                return NotFound();
            }
            return Ok(offers);
        }
        #endregion

        #region get offer details by id
        [HttpGet]
        [ProducesResponseType(typeof(Offers), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<IActionResult> GetOfferById(int id)
        {
            var exp = await offerRepository.GetOfferById(id);
            if (exp == null)
            {
                return NotFound();
            }
            return Ok(exp);
        }
        #endregion
    }
}
