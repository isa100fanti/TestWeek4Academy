using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Week4.Esercitazione.WebServices.CoreEF.Repository;
using Week4.EsercitazioneWebServices.Core;
using Week4.EsercitazioneWebServices.Core.MainBusinessLayer;
using Week4.EsercitazioneWebServices.Core.Models;
using Week4.EsercitazioneWebServices.Core.Repository;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ShopService : IShopService
    {

        private MainBusinessLayer mainBL;

        public ShopService()
        {
            //// Configurazione DI
            //DependencyContainer.Register<IMainBusinessLayer, MainBusinessLayer>();
            //DependencyContainer.Register<IClientRepository, EFClientRepository>();
            //DependencyContainer.Register<IOrderRepository, EFOrderRepository>();

            //// Risoluzione
            //this.mainBL = DependencyContainer.Resolve<IMainBusinessLayer>();

            mainBL = new MainBusinessLayer(new EFClientRepository());

        }

        public bool AddClient(Client newClient)
        {
            if (newClient == null)
                return false;

            return this.mainBL.AddClient(newClient);
        }

        public bool DeleteClientById(int idClient)
        {
            if (idClient == null)
                return false;

            return this.mainBL.DeleteClientById(idClient);
        }

        public bool EditClient(Client editClient)
        {
            if (editClient == null)
                return false;

            return this.mainBL.EditClient(editClient);
        }

        public IEnumerable<Client> FetchClients()
        {
            return this.mainBL.FetchClients();
        }
    }
}
