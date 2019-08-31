using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.MecanicRepositoryData
{

   public class MecanicRepository : IMecanicRepository
   {
       private readonly AtelierAutoEntities Context;

       public MecanicRepository(AtelierAutoEntities context)
       {
           Context = context;
       }
        public void Add(Mecanic mecanic)
        {
            if (mecanic == null) return;
            Context.Mecanics.Add(mecanic);
            Context.SaveChanges();
        }

        public void Delete(Mecanic mecanic)
        {
            if (mecanic == null) return;
            var foundMecanic = Context.Mecanics.FirstOrDefault(m => m.MecanicId == mecanic.MecanicId);

            if (foundMecanic != null)
            {
                Context.Mecanics.Remove(foundMecanic);
                Context.SaveChanges();
            }
        }

        public List<Mecanic> GetAllMechanics()
        {
            var rezult = Context.Mecanics.ToList();
            return rezult;
        }

        public Mecanic GetMechanicByFullName(string firstName, string secondName)
        {
            var rezult = Context.Mecanics.FirstOrDefault(m => m.Nume == firstName && m.Prenume == secondName);
            return rezult;
        }

        public Mecanic GetMechanicById(int id)
        {
            var foundMechanic = Context.Mecanics.FirstOrDefault(m => m.MecanicId == id);
            return foundMechanic;
        }

        public void Update(Mecanic mecanic, Mecanic mecanic2)
        {
            if (mecanic == null && mecanic2 == null) return;

            var foundMechanic = Context.Mecanics.FirstOrDefault(m => m.MecanicId == mecanic.MecanicId);

            if (foundMechanic != null)
            {
                foundMechanic.Prenume = mecanic2.Prenume;
                foundMechanic.Nume = mecanic2.Nume;

                Context.Mecanics.AddOrUpdate(foundMechanic);
                Context.SaveChanges();
            }
        }

    }
}
