using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proiect1;

namespace Proiect3WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private readonly AtelierAutoEntities Context;
        Initialize init;

        public Service1()
        {
            Context = new AtelierAutoEntities();
            init = new Initialize(Context);
        }
        public List<Client> GetClients()
        {
            return init.clnRep.GetAllClients();
        }
        
        public void AddClient(Client client)
        {
            init.clnRep.Add(client);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void UpdateClient(Client client)
        {
            init.clnRep.Update(client);
        }

        public void DeleteClient(Client client)
        {
            init.cmdRep.DeleteComandsForAClient(client.ClientId);
            init.autoRep.DeleteCars(client.ClientId);
            init.clnRep.Delete(client);
        }

        public List<Automobil> GetAutomobils(int clientId)
        {
            return init.clnRep.GetAutomobilsForClient(clientId);
        }

        public void AddCar(Automobil auto)
        {
            init.autoRep.Add(auto);
        }

        public void UpdateCar(Automobil auto)
        {
            init.autoRep.Update(auto);
        }

        public void DeleteCar(Automobil auto)
        {
            init.cmdRep.DeleteComandsForACar(auto.AutoId);
            init.autoRep.Delete(auto);
        }


        Client IService1.GetClientbyName(string nume, string prenume)
        {
            return init.clnRep.FindClientByName(nume, prenume);
        }
    }
}
