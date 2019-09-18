using BillingSystem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BillingSystem2.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        public object GetAllProducts()
        {
            PractiseEntities db = new PractiseEntities();

            return (from prod in db.eProducts
                   select new {
                       Id = prod.Id,
                       Name = prod.Name
                   }).ToList();
            //return lseProduct;
        }

        [HttpGet]
        public int GetProductPrice(int nId)
        {
            PractiseEntities db = new PractiseEntities();

            int nPrice = -1;

            nPrice = (from prod in db.eProducts
                      where prod.Id == nId
                      select prod).Single().Price;

            return nPrice;
        }

        [HttpPost]
        public bool SaveRec(eOrderMaster oeOrderMaster)
        {
            bool bOk = true;
            PractiseEntities db = new PractiseEntities();

            oeOrderMaster.CrtDt = DateTime.Now;

            try
            {
                db.eOrderMasters.Add(oeOrderMaster);
                db.SaveChanges();
                return bOk = true;
            }

            catch(Exception ex)
            {
                var msg = ex.Message;
                return bOk = false;
            }            
          
        }

       [HttpGet]
       public List<Models.OrderDetV>  GetOrderDets(long Id)
        {
            PractiseEntities db = new PractiseEntities();

            List<Models.OrderDetV> lsOrderDetV;

            lsOrderDetV = (from prod in db.eProducts
                           join ordt in db.eOrderDets on prod.Id equals ordt.ProductId
                           select new OrderDetV
                           {
                               Name = prod.Name,
                               Price = prod.Price,
                               Total = ordt.Total,
                               GrantTotal = prod.Price * ordt.Total,
                           }).ToList();

            return lsOrderDetV;
        }
    }
}
