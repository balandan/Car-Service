using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.AutomobilRepositoryData
{
    public class AutomobilRepository : IAutomobilRepository
    {

        private readonly AtelierAutoEntities Context;

        public AutomobilRepository(AtelierAutoEntities context)
        {
            Context = context;
        }

        public void Add(Automobil auto)
        {
            if (auto == null) return;
            Context.Automobils.Add(auto);
            Context.SaveChanges();
        }

        public void Delete(Automobil auto)
        {
            if (auto == null) return;
            var foundCar = Context.Automobils.FirstOrDefault(m => m.AutoId == auto.AutoId);
            Context.Automobils.Remove(foundCar);
            Context.SaveChanges();
        }

        public void DeleteCars(int ClientId)
        {
            var query = from o in Context.Automobils
                        where o.ClientId == ClientId
                        select o;

            var rezultat = query.Any() ? query.ToList() : null;
            foreach (Automobil i in rezultat)
            {
                Context.Automobils.Remove(i);
            }
            Context.SaveChanges();
        }

        public List<Automobil> GetAllAutomobils()
        {
            var rezult = Context.Automobils.ToList();
            return rezult;
        }

        public Automobil GetAutomobilById(int autoId)
        {
            return Context.Automobils.FirstOrDefault(m => m.AutoId == autoId);
        }

        public Automobil GetAutomobilBySerieNumber(int clientId, string numarAuto)
        {
            return Context.Automobils.FirstOrDefault(m => m.ClientId == clientId && m.NumarAuto == numarAuto);
        }


        public void Update(Automobil auto1)
        {
            if (auto1 == null) return;

            var foundCar = Context.Automobils.FirstOrDefault(m => m.AutoId == auto1.AutoId);

            if (foundCar != null)
            {
                foundCar.ClientId = auto1.ClientId;
                foundCar.NumarAuto = auto1.NumarAuto;
                foundCar.SerieSasiu = auto1.SerieSasiu;
                foundCar.SasiuId = auto1.SasiuId;
            }
            else return;
            Context.Automobils.AddOrUpdate(foundCar);
            Context.SaveChanges();
        }
    }
}
