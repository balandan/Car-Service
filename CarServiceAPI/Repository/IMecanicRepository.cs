using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.MecanicRepositoryData
{
    public interface IMecanicRepository
    {
        void Add(Mecanic mecanic);
        void Update(Mecanic mecanic, Mecanic mecanic2);
        void Delete(Mecanic mecanic);
        Mecanic GetMechanicById(int id);
        List<Mecanic> GetAllMechanics();
        Mecanic GetMechanicByFullName(string firstName, string secondName);
    }
}
