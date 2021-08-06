using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week4.EsercitazioneWebServices.Core.Models;
using Week4.EsercitazioneWebServices.Core.Repository;

namespace Week4.EsercitazioneWebServices.Core.MainBusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IClientRepository clientRepo;

        private readonly IOrderRepository orderRepo;
        

        public MainBusinessLayer(IClientRepository clientR)
        {
            //this.clientRepo = DependencyContainer.Resolve<IClientRepository>();
            this.clientRepo = clientR;
            //this.orderRepo = DependencyContainer.Resolve<IOrderRepository>();
        }

        public MainBusinessLayer(IOrderRepository orderR, IClientRepository clientR)
        {
            this.orderRepo = orderR;
            this.clientRepo = clientR;
        }

        #region CLIENT
        public bool AddClient(Client newClient)
        {
            if (newClient == null)
                return false;

            return clientRepo.Add(newClient);
        }
        public bool EditClient(Client editedClient)
        {
            if (editedClient == null)
                return false;

            return clientRepo.Update(editedClient);
        }

        public IEnumerable<Client> FetchClients()
        {
            return clientRepo.Fetch();
        }

        public Client FetchClientById(int id)
        {
            if (id <= 0)
                return null;

            return clientRepo.GetById(id);
        }

        public bool DeleteClientById(int idClient)
        {
            if (idClient <= 0)
                return false;

            //?????? controlla se va
                clientRepo.Delete(idClient);
            return true;

            
        }


        #endregion

        #region ORDER

        public bool CreateOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;

            return orderRepo.Add(newOrder);
        }
        public bool EditOrder(Order editOrder)
        {
            if (editOrder == null)
                return false;

            return orderRepo.Update(editOrder);
        }

        public IEnumerable<Order> FetchOrders()
        {
            return orderRepo.Fetch();
        }

        public Order FetchOrderById(int id)
        {
            if (id <= 0)
                return null;

            return orderRepo.GetById(id);
        }

        public bool DeleteOrderById(int idClient)
        {
            if (idClient <= 0)
                return false;

            //?????? controlla se va
            orderRepo.Delete(idClient);
            return true;


        }
        #endregion


    }
}
