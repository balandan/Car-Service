using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.MaterialRepositoryData
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AtelierAutoEntities Context;
        public MaterialRepository(AtelierAutoEntities context)
        {
            Context = context;
        }

        public void Add(Material material)
        {
            if (material == null) return;
            Context.Materials.Add(material);
            Context.SaveChanges();
        }

        public void Delete(Material material)
        {
            if (material == null) return;
            Context.Materials.Remove(material);
            Context.SaveChanges();
        }

        public List<Material> GetAllMaterials()
        {
            return Context.Materials.ToList();
        }

        public Material GetMaterialById(int id)
        {
            return Context.Materials.FirstOrDefault(m => m.MaterialId == id);
        }

        public Material GetMaterialByName(string denumire)
        {
            return Context.Materials.FirstOrDefault(m => m.Denumire == denumire);
        }

        public void Update(Material material1, Material material2)
        {
            if (material1 == null || material2 == null) return;

            var foundMaterial = Context.Materials.FirstOrDefault(m => m.MaterialId == material1.MaterialId);

            if (foundMaterial != null)
            {
                foundMaterial.Denumire = material2.Denumire;
                foundMaterial.Cantitate = material2.Cantitate;
                foundMaterial.Pret = material2.Pret;
                foundMaterial.DataAprovizionare = material2.DataAprovizionare;
            }

            Context.Materials.AddOrUpdate(foundMaterial);
            Context.SaveChanges();
        }
    }
}
