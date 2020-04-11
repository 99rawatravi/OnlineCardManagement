using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingCardmanagement.Models;

namespace OnlineShoppingCardmanagement.DAL
{
    public class CardDataManager
    {
        OnlineCardManagementEntities objEntity = new OnlineCardManagementEntities();

        public IQueryable<CardDetail> GetCardDetails()
        {
            try
            {
                return objEntity.CardDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CardDetail GetCardbyId(string CardId)
        {
            int Id = Convert.ToInt32(CardId);
            CardDetail objCard = new CardDetail();
            objCard = objEntity.CardDetails.Find(Id);
            return objCard;
        }

        public void AddCard(CardDetail objCard)
        {
            objEntity.CardDetails.Add(objCard);
            objEntity.SaveChanges();
        }

        public void UpdateCard(CardDetail objCard)
        {
            CardDetail obj = new CardDetail();
            obj = objEntity.CardDetails.Find(objCard.Id);
            if(obj != null)
            {
                obj.CardName = objCard.CardName;
                obj.Description = objCard.Description;
                obj.Price = objCard.Price;
            }

            objEntity.SaveChanges();
        }

        public bool DeleteCard(int id)
        {
            CardDetail objCard = objEntity.CardDetails.Find(id);
            if(objCard == null)
            {
                return false;
            }
            objEntity.CardDetails.Remove(objCard);
            return true;
        }
    }
}