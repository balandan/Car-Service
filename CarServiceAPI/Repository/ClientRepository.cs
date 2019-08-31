using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.ClientRepositoryData
{
    public class ClientRepository : IClientRepository
    {

        private readonly AtelierAutoEntities Context;

        public ClientRepository(AtelierAutoEntities context)
        {
            Context = context;
        }

        public void Add(Client client)
        {
            if (client == null) return;
            Context.Clients.Add(client);
            Context.SaveChanges();
        }

        public void Delete(Client client)
        {
            if (client == null) return;
            var foundClient = Context.Clients.FirstOrDefault(m => m.ClientId == client.ClientId);

            Context.Clients.Remove(foundClient);
            Context.SaveChanges();
        }

        public Client FindClientById(int id)
        {
            return Context.Clients.FirstOrDefault(m => m.ClientId == id);
        }

        public Client FindClientByName(string nume, string prenume)
        {
            return Context.Clients.FirstOrDefault(m => m.Nume == nume && m.Prenume == prenume);
        }

        public List<Client> GetAllClients()
        {
            return Context.Clients.ToList();
        }

        public List<Automobil> GetAutomobilsForClient(int idClient)
        {
            if (idClient == null) return null;
            var query = from o in Context.Automobils
                where o.ClientId == idClient
                select o;
 
            return query.Any() ? query.ToList() : null;
        }

        public void Update(Client client1)
        {
            if (client1 == null) return;

            var foundClient = Context.Clients.FirstOrDefault(m => m.ClientId == client1.ClientId);

            if (foundClient != null)
            {
                foundClient.Nume = client1.Nume;
                foundClient.Prenume = client1.Prenume;
                foundClient.Adresa = client1.Adresa;
                foundClient.Email = client1.Email;
                foundClient.Judet = client1.Judet;
                foundClient.Localitate = client1.Localitate;
                foundClient.Telefon = client1.Telefon;
            }
            else return;
            Context.Clients.AddOrUpdate(foundClient);
            Context.SaveChanges();
        }
    }
}
