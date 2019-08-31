using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.OperatieRepositoryData
{
    public class OperatieRepository : IOperatieRepository
    {
        private readonly AtelierAutoEntities Context;

        public OperatieRepository(AtelierAutoEntities context)
        {
            Context = context;
        }

        public void Add(Operatie operatie)
        {
            if (operatie == null) return;
            Context.Operaties.Add(operatie);
            Context.SaveChanges();
        }

        public void Delete(Operatie operatie)
        {
            if (operatie == null) return;
            Context.Operaties.Remove(operatie);
            Context.SaveChanges();
        }

        public List<Operatie> GetAlloOperaties()
        {
            return Context.Operaties.ToList();
        }

        public Operatie GetOperatieById(int id)
        {
            return Context.Operaties.FirstOrDefault(m => m.OperatieId == id);
        }

        public Operatie GetOperatieByName(string denumire)
        {
            return Context.Operaties.FirstOrDefault(m => m.Denumire == denumire);
        }

        public void Update(Operatie operatie1, Operatie operatie2)
        {
            if (operatie1 == null || operatie2 == null) return;

            var foundOperatie = Context.Operaties.FirstOrDefault(m => m.OperatieId == operatie1.OperatieId);
            if (foundOperatie != null)
            {
                foundOperatie.Denumire = operatie2.Denumire;
                foundOperatie.TimpExecutie = operatie2.TimpExecutie;
            }

            Context.Operaties.AddOrUpdate(foundOperatie);
            Context.SaveChanges();
        }
    }
}
