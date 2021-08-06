using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsercitazioneWebServices.Core.Models;
using Week4.EsercitazioneWebServices.Core.Repository;

namespace Week4.Esercitazione.WebServices.CoreEF.Repository
{
    public class EFClientRepository : IClientRepository
    {
        private readonly ShopContext ctx;

        public EFClientRepository() : this(new ShopContext()) { }

        public EFClientRepository(ShopContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Client client)
        {
            if (client == null)
                return false;

            try
            {

                ctx.Clients.Add(client);
                ctx.SaveChanges();
                return true;
            }catch(Exception ex)
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
            }catch(Exception ex)
            {
                return false;
            }

        }

        public List<Client> Fetch()
        {
            try
            {
                return ctx.Clients.Include(b => b.Orders).ToList();
            }
            catch (Exception ex)
            {
                return new List<Client>();
            }
        }

        public Client GetById(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                var client = ctx.Clients.Find(id);
                return client;
            }catch(Exception ex )
            {
                return null;
            }


        }

        public bool Update(Client clientUp)
        {
            if (clientUp == null)
                return false;

            try
            {
                ctx.Clients.Update(clientUp);
                ctx.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }

        }
    }
}
