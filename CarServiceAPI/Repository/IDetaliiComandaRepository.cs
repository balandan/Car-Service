using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.DetaliiComandaRepository
{
    public interface IDetaliiComandaRepository
    {
        void AddDetaliiComandaPentruComannda(DetaliiComanda detaliiComanda);

        void UpdateDetaliiComandaPentruComanda(DetaliiComanda detaliiComanda1, DetaliiComanda detaliiComanda2);

        void DeleteDetaliiComandaPentruComanda(Comanda comanda, DetaliiComanda detaliiComanda);

        List<DetaliiComanda> GetAllDetaliiComandaForComand(int autoId);
    }
}
