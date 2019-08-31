using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Proiect1.ComandaRepository
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly AtelierAutoEntities Context;

        public ComandaRepository(AtelierAutoEntities context)
        {
            Context = context;
        }

        public Comanda Add(Comanda comanda)
        {
            if (comanda == null) return null;
            var comandaGasita = Context.Comandas.FirstOrDefault(c => c.ComandaId == comanda.ComandaId);

            if (comandaGasita != null) return null;
            Context.Comandas.Add(comanda);
            Context.SaveChanges();
            return comanda;
        }


        public void DeleteComanda(Comanda comanda)
        {
            if (comanda == null) return;
            var comandaGasita = Context.Comandas.FirstOrDefault(c => c.ComandaId == comanda.ComandaId);
            if (comandaGasita == null) return;
            Context.Comandas.Remove(comandaGasita);
            Context.SaveChanges();
        }

        public void DeleteComandsForACar(int AutoId)
        {
            var query = from o in Context.Comandas
                        where o.AutoId == AutoId
                        select o;

            var rezultat = query.Any() ? query.ToList() : null;
            if (rezultat != null)
            {
                foreach (Comanda i in rezultat)
                {
                    Context.Comandas.Remove(i);
                }
            }
            Context.SaveChanges();
        }

        public void DeleteComandsForAClient(int ClientId)
        {

            var query = from o in Context.Comandas
                        where o.ClientId == ClientId
                        select o;

            var rezultat = query.Any() ? query.ToList() : null;

            if (rezultat != null)
            {
                foreach (Comanda i in rezultat)
                {
                    Context.Comandas.Remove(i);
                }
                Context.SaveChanges();
            }
        }

        public List<Comanda> GetAllComands()
        {
            return Context.Comandas.ToList();
        }

        public List<Comanda> GetComandaByAutoId(int autoId)
        {
            var query = from o in Context.Comandas
                        where o.AutoId == autoId
                        select o;
            if (query != null)
            {
                return query.ToList();
            }
            return null;
        }

        public Comanda GetComandaById(int id)
        {
            return Context.Comandas.FirstOrDefault(m => m.ComandaId == id);
        }

        public List<Imagine> ObtineImaginiPentruComanda(Comanda comanda)
        {
            if (comanda == null) return null;
            var query = from detalii in Context.DetaliiComandas
                where detalii.ComandaId == comanda.ComandaId
                select detalii;

            List<Imagine> imaginiPentruComanda = new List<Imagine>();
            foreach (var i in query.ToList())
            {
                imaginiPentruComanda.Add(i.Imagine);
            }

            return imaginiPentruComanda == null ? null : imaginiPentruComanda;

        }

        public List<Mecanic> ObtineMecaniciPentruComanda(Comanda comanda)
        {
            if (comanda == null) return null;
            var query = from detalii in Context.DetaliiComandas
                where detalii.ComandaId == comanda.ComandaId
                select detalii;

            List<Mecanic> mecaniciPentruComanda = new List<Mecanic>();
            foreach (var i in query.ToList())
            {
                mecaniciPentruComanda.Add(i.Mecanic);
            }

            return mecaniciPentruComanda == null ? null : mecaniciPentruComanda;
        }

        public List<Operatie> ObtineOperatiiPentruComanda(Comanda comanda)
        {
            if (comanda == null) return null;
            var query = from detalii in Context.DetaliiComandas
                where detalii.ComandaId == comanda.ComandaId
                select detalii;

            var operatiiPentruComanda = new List<Operatie>();
            foreach (var i in query.ToList())
            {
                operatiiPentruComanda.Add(i.Operatie);
            }

            return operatiiPentruComanda == null ? null : operatiiPentruComanda;
        }

        public void UpdateComanda(Comanda comanda1)
        {
            if (comanda1 == null) return;

            var foundComand = Context.Comandas.FirstOrDefault(m => m.ComandaId == comanda1.ComandaId);

            if (foundComand != null)
            {
                foundComand.AutoId = comanda1.AutoId;
                foundComand.ClientId = comanda1.ClientId;
                foundComand.DataFinalizare = comanda1.DataFinalizare;
                foundComand.DataProgramare = comanda1.DataProgramare;
                foundComand.Descriere = comanda1.Descriere;
                foundComand.StareComanda = comanda1.StareComanda;
                foundComand.KmBord = comanda1.KmBord;
                foundComand.DataSystem = comanda1.DataSystem;
                foundComand.ValoarePiese = comanda1.ValoarePiese;

            }
            else return;
            Context.Comandas.AddOrUpdate(foundComand);
            Context.SaveChanges();
        }
    }
}
