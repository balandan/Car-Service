using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.DetaliiComandaRepository
{
    public class DetaliiComandaRepository : IDetaliiComandaRepository
    {
        private readonly AtelierAutoEntities Context;

        public DetaliiComandaRepository(AtelierAutoEntities context)
        {
            Context = context;
        }

        public void AddDetaliiComandaPentruComannda(DetaliiComanda detaliiComanda)
        {
            if (detaliiComanda == null) return;
            Context.DetaliiComandas.Add(detaliiComanda);
            Context.SaveChanges();
        }

        public void DeleteDetaliiComandaPentruComanda(Comanda comanda, DetaliiComanda detaliiComanda)
        {
            if (detaliiComanda == null) return;
            var detaliiComandaGasit = Context.DetaliiComandas.FirstOrDefault(m => m.ComandaId == detaliiComanda.ComandaId);

            if (detaliiComandaGasit == null) return;
            Context.DetaliiComandas.Remove(detaliiComanda);
            Context.SaveChanges();
        }

        public List<DetaliiComanda> GetAllDetaliiComandaForComand(int autoId)
        {

            var query = from detalii in Context.DetaliiComandas
                where detalii.AutoId == autoId
                select detalii;

            var detaliiPentruMasina = new List<DetaliiComanda>();
            foreach (var i in query.ToList())
            {
                detaliiPentruMasina.Add(i);
            }

            return detaliiPentruMasina == null ? null : detaliiPentruMasina;
        }


        public void UpdateDetaliiComandaPentruComanda(DetaliiComanda detaliiComanda1, DetaliiComanda detaliiComanda2)
        {
            if (detaliiComanda1 == null || detaliiComanda2 == null) return;

            var foundDetails =
                Context.DetaliiComandas.FirstOrDefault(m => m.DetaliiComandaId == detaliiComanda1.DetaliiComandaId);

            if (foundDetails != null)
            {
                foundDetails.AutoId = detaliiComanda2.AutoId;
                foundDetails.MecanicId = detaliiComanda2.MecanicId;
                foundDetails.OperatieId = detaliiComanda2.OperatieId;
                foundDetails.ImagineId = detaliiComanda2.ImagineId;
                foundDetails.ComandaId = detaliiComanda2.ComandaId;

            }
            else return;
            Context.DetaliiComandas.AddOrUpdate(foundDetails);
            Context.SaveChanges();
        }
    }
}
