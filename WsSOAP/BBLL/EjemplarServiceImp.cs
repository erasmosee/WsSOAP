using WsSOAP.BBLL.interfaces;
using System.Collections.Generic;
using WsSOAP.Models;
using WsSOAP.DAL.interfaces;
using WsSOAP.DAL;
using System;

namespace WsSOAP.BBLL {
    public class EjemplarServiceImp : EjemplarService {

        private EjemplarRepository eRepo = new EjemplarRepositoryImp();

        public Ejemplar create(Ejemplar ejemplar) {
            return eRepo.create(ejemplar);
        }

        public void delete(int codEjemplar) {
            eRepo.delete(codEjemplar);
        }

        public IList<Ejemplar> getAll() {
            return eRepo.getAll();
        }

        public IList<Ejemplar> getAllBorrados() {
            return eRepo.getAllBorrados();
        }

        public IList<Ejemplar> getAllEjemplaresByEditorial(int codEditorial) {
            return eRepo.getAllEjemplaresByEditorial(codEditorial);
        }

        public IList<Ejemplar> getAllNoBorrados() {
            return eRepo.getAllNoBorrados();
        }



        public Ejemplar getById(int codEjemplar) {
            return eRepo.getById(codEjemplar);
        }

        public IList<Ejemplar> getEjemplaresByLibro(int codLibro) {
            return eRepo.getEjemplaresByLibro(codLibro);
        }

        public Ejemplar update(Ejemplar ejemplar) {
            return eRepo.update(ejemplar);
        }
    }
}