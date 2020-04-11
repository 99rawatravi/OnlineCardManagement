using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShoppingCardmanagement.Models;
using OnlineShoppingCardmanagement.DAL;

namespace OnlineShoppingCardmanagement.Controllers
{
    [RoutePrefix("Api/Card")]
    public class CardController : ApiController
    {
        [HttpGet]
        [Route("CardDetails")]
        public IQueryable<CardDetail> GetCardDetails()
        {
            try
            {
                CardDataManager cardDataManager = new CardDataManager();
                return cardDataManager.GetCardDetails();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetCardDetailsById/{cardID}")]
        public IHttpActionResult GetCardById(string cardID)
        {
            CardDataManager cardDataManager = new CardDataManager();
            var cardDetail = cardDataManager.GetCardbyId(cardID);
            try
            {
                if (cardDetail == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(cardDetail);
        }

        [HttpPost]
        [Route("InsertCardDetails")]
        public IHttpActionResult PostCard(CardDetail CardData)
        {
            CardDataManager cardDataManager = new CardDataManager();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                cardDataManager.AddCard(CardData);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCardDetails")]
        public IHttpActionResult PutCardDetail(CardDetail CardData)
        {
            CardDataManager cardDataManager = new CardDataManager();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                cardDataManager.UpdateCard(CardData);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteCardDetails")]
        public IHttpActionResult DeleteCardDetails(int id)
        {
            CardDataManager cardDataManager = new CardDataManager();
            bool isDeleted = cardDataManager.DeleteCard(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
