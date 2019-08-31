using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.MaterialRepositoryData
{
    public interface IMaterialRepository
    {
        void Add(Material material);
        void Update(Material material1, Material material2);
        void Delete(Material material);
        Material GetMaterialById(int id);
        List<Material> GetAllMaterials();
        Material GetMaterialByName(string denumire);
    }
}
