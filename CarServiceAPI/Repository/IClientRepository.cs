using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.ClientRepositoryData
{
    public interface IClientRepository
    {
        void Add(Client client);
        void Update(Client client1);
        void Delete(Client client);
        List<Client> GetAllClients();
        List<Automobil> GetAutomobilsForClient(int idClient);
        Client FindClientById(int id);
        Client FindClientByName(string nume, string prenume);
    }
}
