using System;
using System.Collections.Generic;
using System.Text;
using Week4.EsercitazioneWebServices.Core.Models;

namespace Week4.EsercitazioneWebServices.Core.Repository
{
    public interface IMainBusinessLayer
    {
        bool AddClient(Client client);
        bool EditClient(Client editClient);
        IEnumerable<Client> FetchClients();
        Client FetchClientById(int id);
        bool DeleteClientById(int idClient);


        #region ORDER

        bool CreateOrder(Order newOrder);
        bool EditOrder(Order editOrder);

        IEnumerable<Order> FetchOrders();
        Order FetchOrderById(int id);

        bool DeleteOrderById(int idClient);

        #endregion
    }
}