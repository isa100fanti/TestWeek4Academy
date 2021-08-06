using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsercitazioneWebServices.Core.Models;
using Week4.EsercitazioneWebServices.Core.Repository;

namespace Week4.Esercitazione.WebServices.CoreEF.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ShopContext ctx;

        public EFOrderRepository() : this(new ShopContext()) { }

        public EFOrderRepository(ShopContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order order)
        {
            if (order == null)
                return false;

            try
            {

                ctx.Orders.Add(order);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {

            if (id <= 0)
                return false;

            try
            {
                var clientD = ctx.Clients.Find(id);
                ctx.Clients.Remove(clientD);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Order> Fetch()
        {
            return ctx.Orders.ToList();
        }

        public Order GetById(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                var order = ctx.Orders.Find(id);
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public bool Update(Order orderUP)
        {
            if (orderUP == null)
                return false;

            try
            {
                ctx.Orders.Update(orderUP);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
