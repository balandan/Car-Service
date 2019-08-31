using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.ImagineRepositoryData
{
   public interface IImagineRepository
    {
        void Add(Imagine imagine);
        void Update(Imagine imagine1, Imagine imagine2);
        void Delete(Imagine imagine);
        Imagine GetImagineById(int id);
        List<Imagine> GetAllImagines();
        Imagine GetImagineByName(string denumire);
    }
}
