
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.ComandaRepository
{
    public interface IComandaRepository
    {
        Comanda Add(Comanda comanda);

        void UpdateComanda(Comanda comanda1);

        void DeleteComanda(Comanda comanda);

        List<Mecanic> ObtineMecaniciPentruComanda(Comanda comanda);

        List<Operatie> ObtineOperatiiPentruComanda(Comanda comanda);

        List<Imagine> ObtineImaginiPentruComanda(Comanda comanda);

        List<Comanda> GetComandaByAutoId(int autoId);

        List <Comanda> GetAllComands();

        void DeleteComandsForAClient(int ClientId);

        void DeleteComandsForACar(int AutoId);



    }
}
