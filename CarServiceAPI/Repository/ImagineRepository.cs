using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.ImagineRepositoryData
{
    public class ImagineRepository : IImagineRepository
    {
        private readonly AtelierAutoEntities Context;
        public ImagineRepository(AtelierAutoEntities context)
        {
            Context = context;
        }

        public void Add(Imagine imagine)
        {
            if (imagine == null) return;
            Context.Imagines.Add(imagine);
            Context.SaveChanges();
        }

        public void Delete(Imagine imagine)
        {
            if (imagine == null) return;
            Context.Imagines.Remove(imagine);
            Context.SaveChanges();
        }

        public List<Imagine> GetAllImagines()
        {
            return Context.Imagines.ToList();
        }

        public Imagine GetImagineById(int id)
        {
            return Context.Imagines.FirstOrDefault(m => m.ImagineId == id);
        }

        public Imagine GetImagineByName(string denumire)
        {
            return Context.Imagines.FirstOrDefault(m => m.Titlu == denumire);
        }

        public void Update(Imagine imagine1, Imagine imagine2)
        {
            if (imagine1 == null || imagine2 == null) return;

            var foundImage = Context.Imagines.FirstOrDefault(m => m.ImagineId == imagine1.ImagineId);
            if (foundImage != null)
            {
                foundImage.DetaliiComandas = imagine2.DetaliiComandas;
                foundImage.Titlu = imagine2.Titlu;
                foundImage.DataImagine = imagine2.DataImagine;
                foundImage.Descriere = imagine2.Descriere;
                foundImage.Foto = imagine2.Foto;
            }
            Context.Imagines.AddOrUpdate(foundImage);
            Context.SaveChanges();
        }
    }
}
