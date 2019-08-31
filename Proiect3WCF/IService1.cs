using Proiect1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Proiect3WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);


        [OperationContract]
        List<Client> GetClients();

        [OperationContract]
        void AddClient(Client client);

        [OperationContract]
        void UpdateClient(Client client);

        [OperationContract]
        void DeleteClient(Client client);

        [OperationContract]
        List<Automobil> GetAutomobils(int clientId);

        [OperationContract]
        void AddCar(Automobil auto);

        [OperationContract]
        void UpdateCar(Automobil auto);

        [OperationContract]
        void DeleteCar(Automobil auto);

        [OperationContract]
        Client GetClientbyName(String nume, String prenume);
        
    }
}
