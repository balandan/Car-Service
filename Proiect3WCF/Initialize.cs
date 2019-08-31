using Proiect1.AutomobilRepositoryData;
using Proiect1.ClientRepositoryData;
using Proiect1.ComandaRepository;
using Proiect1.DetaliiComandaRepository;
using Proiect1.ImagineRepositoryData;
using Proiect1.MaterialRepositoryData;
using Proiect1.MecanicRepositoryData;
using Proiect1.OperatieRepositoryData;
using Proiect1.SasiuRepositoryData;
using Proiect1;

namespace Proiect3WCF
{
  
        public class Initialize
        {
            public ClientRepository clnRep;
            public AutomobilRepository autoRep;
            public ComandaRepository cmdRep;
            public DetaliiComandaRepository detRep;
            public ImagineRepository imgRep;
            public MaterialRepository matRep;
            public MecanicRepository mecRep;
            public OperatieRepository opeRep;
            public SasiuRepository sasRep;

            public Initialize(AtelierAutoEntities Context)
            {
                clnRep = new ClientRepository(Context);
                autoRep = new AutomobilRepository(Context);
                cmdRep = new ComandaRepository(Context);
                detRep = new DetaliiComandaRepository(Context);
                imgRep = new ImagineRepository(Context);
                matRep = new MaterialRepository(Context);
                mecRep = new MecanicRepository(Context);
                opeRep = new OperatieRepository(Context);
                sasRep = new SasiuRepository(Context);
            }

        }
}
