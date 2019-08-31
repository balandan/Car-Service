using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.OperatieRepositoryData
{
    public interface IOperatieRepository
    {
        void Add(Operatie operatie);
        void Update(Operatie operatie1, Operatie operatie2);
        void Delete(Operatie operatie);
        Operatie GetOperatieById(int id);
        List<Operatie> GetAlloOperaties();
        Operatie GetOperatieByName(string denumire);
    }
}
