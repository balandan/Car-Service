using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.AutomobilRepositoryData
{
    interface IAutomobilRepository
    {
        void Add(Automobil auto);
        void Update(Automobil auto1);
        void Delete(Automobil auto);
        void DeleteCars(int ClientId);
        List<Automobil> GetAllAutomobils();
        Automobil GetAutomobilById(int autoId);
        Automobil GetAutomobilBySerieNumber(int clientId, string numarAuto);
    }
}
