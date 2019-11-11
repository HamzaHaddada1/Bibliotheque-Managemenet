using Domain.Entities;
using GestionBibliotheque.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Etudiantservice: Service<Etudiant> ,IEtudiantService
    {
        public static IDatabaseFactory dbFactory = new DatabaseFactory();
        public static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public Etudiantservice():base(uow)
        {

        }




        public int GetnombreEtudiant()

        {
            return GetAll().Count();
        }


        // public void AddBib(Bibliotheque bibliotheque)
        //{
        // uow.getRepository<Bibliotheque>().Add(bibliotheque);
        // uow.Commit();
        // }
    }
}
